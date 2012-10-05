namespace Yax.Tests.SampleClasses
{
    [SerializeAs("Pricing")]
    public class Request
    {
        public Request()
        { }

        [AttributeForClass()]
        public string id { get; set; }

        [AttributeFor("version")]
        public string major { get; set; }

        [AttributeFor("version")]
        public string minor { get; set; }

        [SerializeAs("value_date")]
        [ElementFor("input")]
        public string valueDate { get; set; }

        [SerializeAs("storage_date")]
        [ElementFor("input")]
        public string storageDate { get; set; }

        [SerializeAs("user")]
        [ElementFor("input")]
        public string user { get; set; }

        //[YAXElementFor("input")]
        //public string skylab_config { get; set; }

        //[YAXElementFor("skylab_config")]
        //public string job { get; set; }

        [ElementFor("input")]
        [SerializeAs("skylab_config")]
        public SkyLabConfig Config { get; set; }

        internal static Request GetSampleInstance()
        {
            return new Request()
            {
                id = "123",
                major = "1",
                minor = "0",
                valueDate = "2010-10-5",
                storageDate = "2010-10-5",
                user = "me",
                Config = new SkyLabConfig() { Config = "someconf", Job = "test" }
            };
        }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }
    }

    public class SkyLabConfig
    {
        [SerializeAs("SomeString")]
        public string Config { get; set; }

        [SerializeAs("job")]
        public string Job { get; set; }
    }
}
