using ScriptEngine;

namespace Bracker
{
	[EnumerationType("ТипУзлаСкобаря", "BrackerNodeType")]
	public enum BrackerNodeTypeEnum
	{
		[EnumItem("НачалоЭлемента", "StartElement")]
		StartElement,

		[EnumItem("Текст", "Text")]
		Text,

		[EnumItem("КонецЭлемента", "EndElement")]
		EndElement
	}

}
