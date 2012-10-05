namespace Yax.Tests.SampleClasses
{
    [SerializableType(Options = SerializationOptions.DontSerializeNullObjects)]
    public class ClassWithOptionsSet
    {
        public string StrNotNull { get; set; }

        // the default value should not be used && no warning or errors should be reported
        [ErrorIfMissed(ExceptionTypes.Warning, DefaultValue="Salam")]
        public string StrNull { get; set; }

        [ErrorIfMissed(ExceptionTypes.Warning, DefaultValue = 123)]
        public int SomeValueType { get; set; }
    }

    [SerializableType(Options = SerializationOptions.SerializeNullObjects)]
    public class AnotherClassWithOptionsSet
    {
        public string StrNotNull { get; set; }
        public string StrNull { get; set; }
    }

    public class ClassWithoutOptionsSet
    {
        public string StrNotNull { get; set; }
        public string StrNull { get; set; }
    }

    [ShowInDemoApplication]

    public class SerializationOptionsSample
    {
        [Comment(@"Str2Null must NOT be serialized when it is null, even 
if the serialization options of the serializer is changed")]
        public ClassWithOptionsSet ObjectWithOptionsSet { get; set; }

        [Comment(@"Str2Null must be serialized when it is null, even 
if the serialization options of the serializer is changed")]
        public AnotherClassWithOptionsSet AnotherObjectWithOptionsSet { get; set; }

        [Comment(@"serialization of Str2Null must obey the options set 
in the serializer itself")]
        public ClassWithoutOptionsSet ObjectWithoutOptionsSet { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static SerializationOptionsSample GetSampleInstance()
        {
            return new SerializationOptionsSample()
            {
                ObjectWithOptionsSet = new ClassWithOptionsSet()
                {
                    StrNull = null,
                    StrNotNull = "SomeString"
                },

                AnotherObjectWithOptionsSet = new AnotherClassWithOptionsSet()
                {
                    StrNull = null,
                    StrNotNull = "Some other string"
                },

                ObjectWithoutOptionsSet = new ClassWithoutOptionsSet()
                {
                    StrNull = null,
                    StrNotNull = "Another string"
                }
            };
        }

    }
}
