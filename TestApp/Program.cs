using System;
using ScriptEngine.HostedScript;

namespace TestApp
{
	class MainClass : IHostApplication
	{

		public static HostedScriptEngine StartEngine()
		{
			var engine = new HostedScriptEngine();
			engine.Initialize();

			engine.AttachAssembly(System.Reflection.Assembly.GetAssembly(typeof(Bracker.BrackerWriterImpl)));

			return engine;
		}

		public static void Main(string[] args)
		{

			const string SCRIPT = @"
	З = Новый ЗаписьСкобаря;
	З.ЗаписатьНачалоЭлемента();
	З.ЗаписатьЗначение(""""""#"""""");
	З.ЗаписатьЗначение(""Array"");
	З.ЗаписатьЗначение(2);

	З.ЗаписатьНачалоЭлемента();
	З.ЗаписатьЗначение(""""""N"""""");
	З.ЗаписатьЗначение(15);
	З.ЗаписатьКонецЭлемента();

	З.ЗаписатьНачалоЭлемента();
	З.ЗаписатьЗначение(""""""D"""""");
	З.ЗаписатьЗначение(Формат(ТекущаяДата(), ""ДФ=ггггММддЧЧммсс""));
	З.ЗаписатьКонецЭлемента();

	З.ЗаписатьКонецЭлемента();
	Сообщить(З.Закрыть());
			";

			var engine = StartEngine();
			var script = engine.Loader.FromString(SCRIPT);
			var process = engine.CreateProcess(new MainClass(), script);

			var result = process.Start();

			Console.WriteLine("Result = {0}", result);
			Console.ReadLine();
		}

		public void Echo(string str, EchoStatus status = EchoStatus.Undefined)
		{
			Console.WriteLine(str);
		}

		public void ShowExceptionInfo(Exception exc)
		{
			Console.WriteLine(exc.ToString());
		}

		public bool InputString(out string result, int maxLen)
		{
			throw new NotImplementedException();
		}

		public string[] GetCommandLineArguments()
		{
			return new string[] { "1", "2", "3" }; // Здесь можно зашить список аргументов командной строки
		}
	}
}
