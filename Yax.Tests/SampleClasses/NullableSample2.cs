namespace Yax.Tests.SampleClasses
{
    [ShowInDemoApplication]

    [Comment(@"This example shows how nullable fields 
        may not be serialized in their expected location")]
    public class NullableSample2
    {
        [AttributeForClass]
        public int? Number { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static NullableSample2 GetSampleInstance()
        {
            return new NullableSample2() { Number = 10 };
        }
    }
}
