using System.Collections.Generic;

namespace Yax.Tests.SampleClasses
{
    [ShowInDemoApplication]
    [Comment(@"This example shows how dictionary objects can be serialized without
        their enclosing element")]
    public class WarehouseWithDictionaryNoContainer
    {
        [AttributeForClass]
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

        [Collection(CollectionSerializationTypes.RecursiveWithNoContainingElement)]
        [Dictionary(EachPairName = "ItemInfo", KeyName = "Item", ValueName = "Count",
                       SerializeKeyAs = NodeTypes.Attribute,
                       SerializeValueAs = NodeTypes.Attribute)]
        [SerializeAs("ItemQuantities")]
        public Dictionary<PossibleItems, int> ItemQuantitiesDic { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static WarehouseWithDictionaryNoContainer GetSampleInstance()
        {
            Dictionary<PossibleItems, int> dicItems = new Dictionary<PossibleItems, int>();
            dicItems.Add(PossibleItems.Item3, 10);
            dicItems.Add(PossibleItems.Item6, 120);
            dicItems.Add(PossibleItems.Item9, 600);
            dicItems.Add(PossibleItems.Item12, 25);

            WarehouseWithDictionaryNoContainer w = new WarehouseWithDictionaryNoContainer()
            {
                Name = "Foo Warehousing Ltd.",
                Address = "No. 10, Some Ave., Some City, Some Country",
                Area = 120000.50, // square meters
                Items = new PossibleItems[] { PossibleItems.Item3, PossibleItems.Item6, PossibleItems.Item9, PossibleItems.Item12 },
                ItemQuantitiesDic = dicItems,
            };

            return w;
        }
    }
}
