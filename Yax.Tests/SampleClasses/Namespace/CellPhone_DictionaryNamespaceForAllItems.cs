using System.Collections.Generic;
using System.Drawing;

namespace Yax.Tests.SampleClasses.Namespace
{
    public class CellPhone_DictionaryNamespaceForAllItems
    {
        [SerializeAs("{http://namespace.org/brand}Brand")]
        public string DeviceBrand { get; set; }

        public string OS { get; set; }

        [SerializeAs("{http://namespace.org/prices}ThePrices")]
        [Dictionary(EachPairName="{http://namespace.org/pricepair}PricePair",
            KeyName="{http://namespace.org/color}TheColor", 
            ValueName="{http://namespace.org/pricevalue}ThePrice")]
        public Dictionary<Color, double> Prices { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static CellPhone_DictionaryNamespaceForAllItems GetSampleInstance()
        {
            var prices = new Dictionary<Color, double> { { Color.Red, 120 }, { Color.Blue, 110 }, { Color.Black, 140 } };
            return new CellPhone_DictionaryNamespaceForAllItems 
            { 
                DeviceBrand = "Samsung Galaxy Nexus",
                OS = "Android",
                Prices = prices,
            };
        }
    }
}
