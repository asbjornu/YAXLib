﻿using System.Collections.Generic;
using System.Drawing;

namespace Yax.Tests.SampleClasses.Namespace
{
    [Namespace("http://namespace.org/nsmain")]
    public class CellPhone_DictionaryNamespace
    {
        [SerializeAs("TheName")]
        [Namespace("x1", "http://namespace.org/x1")]
        public string DeviceBrand { get; set; }

        public string OS { get; set; }

        [Namespace("p1", "namespace/for/prices/only")]
        public Dictionary<Color, double> Prices { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static CellPhone_DictionaryNamespace GetSampleInstance()
        {
            var prices = new Dictionary<Color, double> { { Color.Red, 120 }, { Color.Blue, 110 }, { Color.Black, 140 } };

            return new CellPhone_DictionaryNamespace
            {
                DeviceBrand = "HTC",
                OS = "Windows Phone 8",
                Prices = prices
            };
        }
    }
}
