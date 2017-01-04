using System;
using NUnit.Framework;
using ScriptEngine.Machine;
using Bracker;

namespace NUnitTests
{
	[TestFixture]
	public class MainTestClass
	{

		private EngineHelpWrapper host;

		[OneTimeSetUp]
		public void Initialize()
		{
			host = new EngineHelpWrapper();
			host.StartEngine();
		}

		[Test]
		public void TestAsInternalObjects()
		{
			var w = new BrackerWriterImpl();
			w.SetString();

			w.WriteStartElement();
			w.WriteValue("\"N\"");
			w.WriteValue("15");
			w.WriteEndElement();

			var result = w.Close();

			Assert.AreEqual(result.DataType, DataType.String);
			Assert.AreEqual(result.AsString(), "{\"N\",15}");
		}

		[Test]
		public void TestAsExternalObjects()
		{
			host.RunTestScript("NUnitTests.Tests.external.os");
		}
	}
}
