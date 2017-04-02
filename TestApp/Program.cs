using System;
using ScriptEngine.HostedScript;
using ScriptEngine.HostedScript.Library;

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

			var engine = StartEngine();

			var reader = new Bracker.BrackerReaderImpl();
			reader.SetString("{\"N\",15}");

			while (reader.Read())
			{
				Console.WriteLine(reader.ElementType);
				Console.WriteLine(reader.Value);
			}

			Console.ReadLine();
		}

		public void Echo(string str, MessageStatusEnum status = MessageStatusEnum.Ordinary)
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
