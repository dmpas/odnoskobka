using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.IO;
using System.Text;

namespace Bracker
{
	[ContextClass("ЧтениеСкобаря", "BrackerReader")]
	public sealed class BrackerReaderImpl : AutoContext<BrackerReaderImpl>
	{

		private TextReader reader;
		private int currentChar = -1;

		public BrackerReaderImpl()
		{
		}

		[ContextMethod("УстановитьСтроку", "SetString")]
		public void SetString(string text)
		{
			reader = new StringReader(text);
			currentChar = reader.Read();
		}

		private string ReadStringValue(char startCharacter)
		{

			var sb = new StringBuilder();
			currentChar = reader.Read();
			var c = (char)currentChar;
			while (currentChar != -1)
			{
				if (c == startCharacter)
				{
					currentChar = reader.Read();
					var nextC = (char)currentChar;
					if (nextC != startCharacter)
					{
						break;
					}
				}
				sb.Append(c);
				currentChar = reader.Read();
				c = (Char)currentChar;
			}

			return sb.ToString();
		}

		private IValue ReadValue()
		{
			while (currentChar != -1)
			{
				var c = (Char)currentChar;
				if (c == ',')
				{
					currentChar = reader.Read();
					break;
				}
				if (c == '}')
				{
					break;
				}

				if (c == '"')
				{
					return ValueFactory.Create(ReadStringValue(c));
				}

				if (c >= '0' && c <= '9' || c >= 'a' && c <= 'f' || c == '-')
				{
					
					var sb = new StringBuilder();
					sb.Append(c);
					currentChar = reader.Read();
					c = (char)currentChar;

					bool isGuid = false;
					while (c >= '0' && c <= '9' || c >= 'a' && c <= 'f' || c == '-')
					{
						if (c == '-')
						{
							// встретили "-" внутри значения - это определённо гуид							isGuid = true;
						}

						sb.Append(c);
						currentChar = reader.Read();
						c = (char)currentChar;
					}

					if (isGuid)
					{
						return new ScriptEngine.HostedScript.Library.GuidWrapper(sb.ToString());
					}
					return ValueFactory.Create(decimal.Parse(sb.ToString()));
				}

				currentChar = reader.Read();
			}
			return ValueFactory.Create();
		}

		[ContextMethod("Прочитать", "Read")]
		public bool Read()
		{
			if (currentChar == -1)
				return false;

			var c = (Char)currentChar;
			while (Char.IsWhiteSpace(c))
			{
				currentChar = reader.Read();
				if (currentChar == -1)
					return false;
				c = (Char)currentChar;
			}

			if (c == '{')
			{
				ElementType = ContextValuesMarshaller.ConvertReturnValue(BrackerNodeTypeEnum.StartElement);
				Value = ValueFactory.Create();
				currentChar = reader.Read();
			}
			else if (c == '}')
			{
				ElementType = ContextValuesMarshaller.ConvertReturnValue(BrackerNodeTypeEnum.EndElement);
				Value = ValueFactory.Create();
				currentChar = reader.Read();
			}
			else
			{
				ElementType = ContextValuesMarshaller.ConvertReturnValue(BrackerNodeTypeEnum.Value);
				Value = ReadValue();
				if ((char)currentChar == ',')
				{
					currentChar = reader.Read();
				}
			}

			return true;
		}

		[ContextProperty("ТипЭлемента", "ElementType")]
		public IValue ElementType { get; private set; }

		[ContextProperty("Значение")]
		public IValue Value { get; private set; }

		[ScriptConstructor]
		public static IRuntimeContextInstance Constructor()
		{
			return new BrackerReaderImpl();
		}
	}
}

