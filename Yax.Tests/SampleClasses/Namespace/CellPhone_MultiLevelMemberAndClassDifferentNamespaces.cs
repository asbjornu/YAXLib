namespace Yax.Tests.SampleClasses.Namespace
{
    [Namespace("http://namespace.org/nsmain")]
    public class CellPhone_MultiLevelMemberAndClassDifferentNamespaces
    {
        [ElementFor("Level1/Level2")]
        [SerializeAs("TheName")]
        [Namespace("x1", "http://namespace.org/x1")]
        public string DeviceBrand { get; set; }

        public string OS { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static CellPhone_MultiLevelMemberAndClassDifferentNamespaces GetSampleInstance()
        {
            return new CellPhone_MultiLevelMemberAndClassDifferentNamespaces
            {
                DeviceBrand = "HTC",
                OS = "Windows Phone 8",
            };
        }

    }
}
