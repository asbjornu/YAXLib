﻿namespace Yax.Tests.SampleClasses.Namespace
{
    [Namespace("xmain", "http://namespace.org/nsmain")]
    public class CellPhone_MemberAndClassDifferentNamespacePrefixes
    {
        [SerializeAs("TheName")]
        [Namespace("x1", "http://namespace.org/x1")]
        public string DeviceBrand { get; set; }

        public string OS { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static CellPhone_MemberAndClassDifferentNamespacePrefixes GetSampleInstance()
        {
            return new CellPhone_MemberAndClassDifferentNamespacePrefixes
            {
                DeviceBrand = "HTC",
                OS = "Windows Phone 8",
            };
        }

    }
}
