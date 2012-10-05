using System;
using System.Collections.Generic;

namespace Yax.Tests.SampleClasses
{
    [ShowInDemoApplication]

    [Comment("This example shows how to apply format strings to a class properties")]
    public class FormattingExample
    {
        [Format("D")]
        public DateTime CreationDate { get; set; }

        [Format("d")]
        public DateTime ModificationDate { get; set; }

        [Format("F05")]
        public double PI { get; set; }

        [Format("F03")]
        public List<double> NaturalExp { get; set; }

        [Dictionary(KeyFormatString = "F02", ValueFormatString = "F05")]
        public Dictionary<double, double> SomeLogarithmExample { get; set; }


        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static FormattingExample GetSampleInstance()
        {
            List<double> lstNE = new List<double>();
            for (int i = 1; i <= 4; ++i)
                lstNE.Add(Math.Exp(i));

            Dictionary<double, double> dicLog = new Dictionary<double, double>();
            for (double d = 1.5; d <= 10; d *= 2)
                dicLog.Add(d, Math.Log(d));

            return new FormattingExample()
            {
                CreationDate = new DateTime(2007, 3, 14),
                ModificationDate = new DateTime(2007, 3, 18),
                PI = Math.PI,
                NaturalExp = lstNE,
                SomeLogarithmExample = dicLog
            };
        }
    }
}
