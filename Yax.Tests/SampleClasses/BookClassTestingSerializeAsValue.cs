﻿using System.Collections.Generic;

namespace Yax.Tests.SampleClasses
{
    [SerializableType(Options= SerializationOptions.DontSerializeNullObjects)]
    public class SomeCollectionItem
    {
        public string Value { get; set; }

        public string SomeElement { get; set; }
    }

    [ShowInDemoApplication]
    public class BookClassTesgingSerializeAsValue
    {
        [ValueFor(".")]
        public double Price { get; set; }

        public int PublishYear { get; set; }

        [ValueFor(".")]
        public string Comments { get; set; }

        public string Author { get; set; }

        [Collection(CollectionSerializationTypes.RecursiveWithNoContainingElement)]
        public List<SomeCollectionItem> TheCollection { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static BookClassTesgingSerializeAsValue GetSampleInstance()
        {
            List<SomeCollectionItem> theCollection = new List<SomeCollectionItem>();

            theCollection.Add(new SomeCollectionItem() { Value = "value1", SomeElement = "elem1" });
            theCollection.Add(new SomeCollectionItem() { Value = "value2", SomeElement = "elem2" });
            theCollection.Add(new SomeCollectionItem() { Value = "value3", SomeElement = "elem3" });

            return new BookClassTesgingSerializeAsValue()
            {
                Author = "Tom Archer & Andrew Whitechapel",
                PublishYear = 2002,
                Price = 30.5,
                Comments = "SomeComment",
                TheCollection = theCollection
            };
        }
    }
}
