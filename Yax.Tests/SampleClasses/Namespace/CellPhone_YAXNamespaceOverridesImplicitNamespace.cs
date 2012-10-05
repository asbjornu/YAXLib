namespace Yax.Tests.SampleClasses.Namespace
{
    public class CellPhone_YAXNamespaceOverridesImplicitNamespace
    {
        [Namespace("http://namespace.org/explicitBrand")]
        [SerializeAs("{http://namespace.org/implicitBrand}Brand")]
        public string DeviceBrand { get; set; }

        [SerializeAs("{http://namespace.org/os}OperatingSystem")]
        public string OS { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static CellPhone_YAXNamespaceOverridesImplicitNamespace GetSampleInstance()
        {
            return new CellPhone_YAXNamespaceOverridesImplicitNamespace
            {
                DeviceBrand = "Samsung Galaxy S II",
                OS = "Android 2",
            };
        }
    }
}
