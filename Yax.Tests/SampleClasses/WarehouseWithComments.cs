using System.Collections.Generic;

namespace Yax.Tests.SampleClasses
{
    [ShowInDemoApplication]
    public class WarehouseWithComments
    {
        [Comment("Comment for name")]
        [ElementFor("foo/bar/one/two")]
        public string Name { get; set; }

        [Comment("Comment for OwnerName")]
        [ElementFor("foo/bar/one")]
        public string OwnerName { get; set; }

        [Comment("This will not be shown, because it is an attribute")]
        [SerializeAs("address")]
        [AttributeFor("SiteInfo")]
        public string Address { get; set; }

        [SerializeAs("SurfaceArea")]
        [ElementFor("SiteInfo")]
        public double Area { get; set; }

        [Collection(CollectionSerializationTypes.Serially, SeparateBy = ", ")]
        [SerializeAs("StoreableItems")]
        public PossibleItems[] Items { get; set; }

        [Comment("This dictionary is serilaized without container")]
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

        public static WarehouseWithComments GetSampleInstance()
        {
            Dictionary<PossibleItems, int> dicItems = new Dictionary<PossibleItems, int>();
            dicItems.Add(PossibleItems.Item3, 10);
            dicItems.Add(PossibleItems.Item6, 120);
            dicItems.Add(PossibleItems.Item9, 600);
            dicItems.Add(PossibleItems.Item12, 25);

            WarehouseWithComments w = new WarehouseWithComments()
            {
                Name = "Foo Warehousing Ltd.",
                OwnerName = "John Doe",
                Address = "No. 10, Some Ave., Some City, Some Country",
                Area = 120000.50, // square meters
                Items = new PossibleItems[] { PossibleItems.Item3, PossibleItems.Item6, PossibleItems.Item9, PossibleItems.Item12 },
                ItemQuantitiesDic = dicItems,
            };

            return w;
        }
    }
}
