﻿using System.Text;

namespace Yax.Tests.SampleClasses
{
    [ShowInDemoApplication]

    [YAXComment("This example shows how to choose the fields to be serialized")]
    [YAXSerializableType(FieldsToSerialize=YAXSerializationFields.AttributedFieldsOnly)]
    public class FieldSerializationExample
    {
        [YAXSerializableField]
        private int m_someInt;

        [YAXSerializableField]
        private double m_someDouble;

        [YAXSerializableField]
        private string SomePrivateStringProperty { get; set; }

        public string SomePublicPropertyThatIsNotSerialized { get; set; }

        public FieldSerializationExample()
        {
            this.m_someInt = 8;
            this.m_someDouble = 3.14;
            this.SomePrivateStringProperty = "Hi";
            this.SomePublicPropertyThatIsNotSerialized = "Public";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("m_someInt: " + this.m_someInt);
            sb.AppendLine("m_someDouble: " + this.m_someDouble);
            sb.AppendLine("SomePrivateStringProperty: " + this.SomePrivateStringProperty);
            sb.AppendLine("SomePublicPropertyThatIsNotSerialized: " + this.SomePublicPropertyThatIsNotSerialized);

            return sb.ToString();
        }

        public static FieldSerializationExample GetSampleInstance()
        {
            return new FieldSerializationExample();
        }
    }
}