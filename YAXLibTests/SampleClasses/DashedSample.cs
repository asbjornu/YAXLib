namespace Yax.Tests.SampleClasses
{
    [YAXSerializeAs("dashed-sample")]
    public class DashedSample
    {
        [YAXSerializeAs("dashed-name")]
        [YAXAttributeForClass]
        public string DashedName { get; set; }
    }
}