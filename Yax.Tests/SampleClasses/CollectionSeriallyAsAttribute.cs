﻿namespace Yax.Tests.SampleClasses
{
    [ShowInDemoApplication]

    public class CollectionSeriallyAsAttribute
    {
        [YAXAttributeFor("Info#names")]
        [YAXCollection(CollectionSerializationTypes.Serially, SeparateBy=",", IsWhiteSpaceSeparator = false)]
        public string[] Names { get; set; }

        [YAXValueFor("TheCities")]
        [YAXCollection(CollectionSerializationTypes.Serially, SeparateBy = ",", IsWhiteSpaceSeparator = false)]
        public string[] Cities { get; set; }

        [YAXElementFor("Location")]
        [YAXCollection(CollectionSerializationTypes.Serially, SeparateBy = ",", IsWhiteSpaceSeparator = false)]
        public string[] Countries { get; set; }

        public static CollectionSeriallyAsAttribute GetSampleInstance()
        {
            var names = new [] {"John Doe", "Jane", "Sina", "Mike", "Rich"};
            var cities = new[] {"Tehran", "Melbourne", "New York", "Paris"};
            var countries = new[] {"Iran", "Australia", "United States of America", "France"};

            return new CollectionSeriallyAsAttribute
                {
                    Names = names, Cities = cities, Countries = countries
                };
        }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }
    }
}
