using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.IO;
using System.Collections.Generic;

namespace Bracker
{
	[ContextClass("ЗаписьСкобаря", "BrackerWriter")]
	public sealed class BrackerWriterImpl : AutoContext<BrackerWriterImpl>
	{
		private readonly StringWriter w = new StringWriter();
		private readonly Stack<int> _count = new Stack<int>();
		private bool hasOpenBracket = false;
		private bool hasCloseBracket = false;

		public BrackerWriterImpl()
		{
			_count.Push(0);
		}

		[ContextMethod("УстановитьСтроку", "SetString")]
		public void SetString(IValue encoding = null)
		{
		}

		private void WriteLine()
		{
			// TODO: Если пишем в строку, выводить \n. Если пишем в файл, выводить в зависимости от настроек.
			// w.WriteLine();
			w.Write('\n');
			hasOpenBracket = false;
			hasCloseBracket = false;
		}

		[ContextMethod("ЗаписатьНачалоЭлемента", "WriteStartElement")]
		public void WriteStartElement()
		{

			var currentCount = _count.Pop();
			if (currentCount != 0)
			{
				WriteText(",");
			}
			_count.Push(currentCount + 1);

			if (hasOpenBracket || hasCloseBracket)
			{
				WriteLine();
			}
			
			w.Write("{");
			hasOpenBracket = true;
			_count.Push(0);
		}

		[ContextMethod("ЗаписатьКонецЭлемента", "WriteEndElement")]
		public void WriteEndElement()
		{
			if (hasCloseBracket)
			{
				WriteLine();
			}

			w.Write("}");
			hasCloseBracket = true;
			_count.Pop();
		}

		[ContextMethod("ЗаписатьТекст", "WriteText")]
		public void WriteText(string text)
		{
			w.Write(text);
		}

		[ContextMethod("ЗаписатьЗначение", "WriteValue")]
		public void WriteValue(string value)
		{
			var currentCount = _count.Pop();
			if (currentCount != 0)
			{
				WriteText(",");
			}
			WriteText(value);
			_count.Push(currentCount + 1);
		}

		[ContextMethod("Закрыть", "Close")]
		public IValue Close()
		{
			w.Close();
			return ValueFactory.Create(w.ToString());
		}

		[ScriptConstructor()]
		public static IRuntimeContextInstance Constructor()
		{
			return new BrackerWriterImpl();
		}
	}
}

