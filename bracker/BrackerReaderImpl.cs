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

		private string ReadValue()
		{
			var sb = new StringBuilder();
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

					do
					{
						sb.Append(c);
						currentChar = reader.Read();
						c = (Char)currentChar;
					} while (currentChar != -1 && c != '"');

					if (currentChar != -1)
					{
						sb.Append(c);
						currentChar = reader.Read();
					}
				}
				else
				{
					sb.Append(c);
					currentChar = reader.Read();
				}
			}
			return sb.ToString();
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
				ElementType = BrackerNodeTypeEnum.StartElement;
				Text = "";
				currentChar = reader.Read();
			}
			else if (c == '}')
			{
				ElementType = BrackerNodeTypeEnum.EndElement;
				Text = "";
				currentChar = reader.Read();
			}
			else
			{
				ElementType = BrackerNodeTypeEnum.Text;
				Text = ReadValue();
			}

			return true;
		}

		[ContextProperty("ТипЭлемента", "ElementType")]
		public BrackerNodeTypeEnum ElementType { get; private set; }

		[ContextProperty("Текст", "Text")]
		public string Text { get; private set; }

		[ScriptConstructor]
		public static IRuntimeContextInstance Constructor()
		{
			return new BrackerReaderImpl();
		}
	}
}

