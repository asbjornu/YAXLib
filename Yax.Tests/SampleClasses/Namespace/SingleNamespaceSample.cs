namespace Yax.Tests.SampleClasses.Namespace
{
    [Comment("This example shows usage of a custom default namespace")]
    [Namespace("http://namespaces.org/default")]
    public class SingleNamespaceSample
    {
        public static SingleNamespaceSample GetInstance()
        {
            return new SingleNamespaceSample()
            {
                StringItem = "This is a test string",
                IntItem = 10
            };
        }

        public string StringItem
        { get; set; }

        public int IntItem
        { get; set; }
    }
}
