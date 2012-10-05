namespace Yax.Tests.SampleClasses
{
    public enum PossibleItems
    {
        Item1, Item2, Item3, Item4, Item5, Item6,
        Item7, Item8, Item9, Item10, Item11, Item12
    }

    [ShowInDemoApplication]
    [Comment("This example shows the serialization of arrays")]
    public class WarehouseWithArray
    {
        [AttributeForClass()]
        public string Name { get; set; }

        [SerializeAs("address")]
        [AttributeFor("SiteInfo")]
        public string Address { get; set; }

        [SerializeAs("SurfaceArea")]
        [ElementFor("SiteInfo")]
        public double Area { get; set; }

        [Collection(CollectionSerializationTypes.Serially, SeparateBy = ", ")]
        [SerializeAs("StoreableItems")]
        public PossibleItems[] Items { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static WarehouseWithArray GetSampleInstance()
        {
            WarehouseWithArray w = new WarehouseWithArray()
            {
                Name = "Foo Warehousing Ltd.",
                Address = "No. 10, Some Ave., Some City, Some Country",
                Area = 120000.50, // square meters
                Items = new PossibleItems[] { PossibleItems.Item3, PossibleItems.Item6, PossibleItems.Item9, PossibleItems.Item12 },
            };

            return w;
        }
    }
}
