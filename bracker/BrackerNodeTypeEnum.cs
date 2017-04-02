using ScriptEngine;

namespace Bracker
{
	[EnumerationType("ТипУзлаСкобаря", "BrackerNodeType")]
	public enum BrackerNodeTypeEnum
	{
		[EnumItem("НачалоЭлемента")]
		StartElement,

		[EnumItem("Значение")]
		Value,

		[EnumItem("КонецЭлемента")]
		EndElement
	}

}
