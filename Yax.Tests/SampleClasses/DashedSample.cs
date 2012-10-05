namespace Yax.Tests.SampleClasses
{
    [SerializeAs("dashed-sample")]
    public class DashedSample
    {
        [SerializeAs("dashed-name")]
        [AttributeForClass]
        public string DashedName { get; set; }
    }
}