using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections.Generic;
using System.Linq;

namespace Bracker
{
    enum BrackerNodeType
    {
        StartElement,
        Text,
        EndElement
    }

	[SystemEnum("ТипУзлаСкобаря", "BrackerNodeType")]
	public class BrackerNodeTypeEnum : EnumerationContext
	{

		public BrackerNodeTypeEnum(TypeDescriptor typeRepresentation, TypeDescriptor valuesType)
			: base(typeRepresentation, valuesType)
		{

		}

		[EnumValue("НачалоЭлемента", "StartElement")]
		public EnumerationValue StartElement { get { return this["StartElement"]; } }

		[EnumValue("Текст", "Text")]
		public EnumerationValue Text { get { return this["Text"]; } }

		[EnumValue("КонецЭлемента", "EndElement")]
		public EnumerationValue EndElement { get { return this["EndElement"]; } }

		public static BrackerNodeTypeEnum CreateInstance()
		{
			return EnumContextHelper.CreateEnumInstance<BrackerNodeTypeEnum>((t, v) => new BrackerNodeTypeEnum(t, v));
		}
	}
}

