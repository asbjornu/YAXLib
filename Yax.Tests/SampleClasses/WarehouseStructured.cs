namespace Yax.Tests.SampleClasses
{
    [ShowInDemoApplication]

    [Comment("This example shows our hypothetical warehouse, a little bit structured")]
    public class WarehouseStructured
    {
        [AttributeForClass()]
        public string Name { get; set; }

        [SerializeAs("address")]
        [AttributeFor("SiteInfo")]
        public string Address { get; set; }

        [SerializeAs("SurfaceArea")]
        [ElementFor("SiteInfo")]
        public double Area { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static WarehouseStructured GetSampleInstance()
        {
            WarehouseStructured w = new WarehouseStructured()
            {
                Name = "Foo Warehousing Ltd.",
                Address = "No. 10, Some Ave., Some City, Some Country",
                Area = 120000.50, // square meters
            };

            return w;
        }

    }
}
