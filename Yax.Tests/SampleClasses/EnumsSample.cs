using System;
using System.Collections.Generic;

namespace Yax.Tests.SampleClasses
{
    [Flags]
    public enum Seasons
    {
        [Enum("Spring")]
        First = 1,

        [Enum("Summer")]
        Second = 2,

        [Enum(" Autumn or fall ")]
        Third = 4,

        [Enum("Winter")]
        Fourth = 8
    }

    [ShowInDemoApplication]
    [Comment("This example shows how to define aliases for enum members")]
    public class EnumsSample
    {
        [AttributeForClass]
        public Seasons OneInstance { get; set; }

        [Collection(CollectionSerializationTypes.Serially, SeparateBy=";", IsWhiteSpaceSeparator=false)]
        public Seasons[] TheSeasonSerially { get; set; }

        [Collection(CollectionSerializationTypes.Recursive)]
        public Seasons[] TheSeasonRecursive { get; set; }

        public Dictionary<Seasons, int> DicSeasonToInt { get; set; }

        public Dictionary<int, Seasons> DicIntToSeason { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static EnumsSample GetSampleInstance()
        {
            Dictionary<Seasons, int> dicSeas2Int = new Dictionary<Seasons, int>();
            dicSeas2Int.Add(Seasons.First, 1);
            dicSeas2Int.Add(Seasons.Second, 2);
            dicSeas2Int.Add(Seasons.Third, 3);
            dicSeas2Int.Add(Seasons.Fourth, 4);

            Dictionary<int, Seasons> dicInt2Seas = new Dictionary<int, Seasons>();
            dicInt2Seas.Add(1, Seasons.First);
            dicInt2Seas.Add(2, Seasons.Second | Seasons.First);
            dicInt2Seas.Add(3, Seasons.Third);
            dicInt2Seas.Add(4, Seasons.Fourth);

            return new EnumsSample()
            {
                OneInstance = Seasons.First | Seasons.Second,
                TheSeasonRecursive = new Seasons[] { Seasons.First, Seasons.Second, Seasons.Third, Seasons.Fourth },
                TheSeasonSerially = new Seasons[] { Seasons.First, Seasons.Second, Seasons.Third, Seasons.Fourth },
                DicSeasonToInt = dicSeas2Int,
                DicIntToSeason = dicInt2Seas
            };
        }
        
    }
}
