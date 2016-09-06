using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace Bracker
{
	[ContextClass("ЧтениеСкобаря", "BrackerReader")]
	public class BrackerReaderImpl : AutoContext<BrackerReaderImpl>
	{
		public BrackerReaderImpl()
		{
		}

		[ContextMethod("УстановитьСтроку", "SetString")]
		public void SetString(string text)
		{
		}

		[ContextMethod("Прочитать", "Read")]
		public bool Read()
		{
			return false;
		}

		public IValue Value
		{
			get
			{
				return ValueFactory.Create();
			}
		}

		[ScriptConstructor]
		public static IRuntimeContextInstance Constructor()
		{
			return new BrackerReaderImpl();
		}
	}
}

