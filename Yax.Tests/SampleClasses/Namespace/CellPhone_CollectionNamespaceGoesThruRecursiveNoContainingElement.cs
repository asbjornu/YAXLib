using System.Collections.Generic;

namespace Yax.Tests.SampleClasses.Namespace
{
    [SerializeAs("MobilePhone")]
    public class CellPhone_CollectionNamespaceGoesThruRecursiveNoContainingElement
    {
        public string DeviceBrand { get; set; }
        public string OS { get; set; }

        [Namespace("app", "http://namespace.org/apps")]
        [Collection(CollectionSerializationTypes.RecursiveWithNoContainingElement)]
        public List<string> IntalledApps { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static CellPhone_CollectionNamespaceGoesThruRecursiveNoContainingElement GetSampleInstance()
        {
            return new CellPhone_CollectionNamespaceGoesThruRecursiveNoContainingElement
            {
                DeviceBrand = "Samsung Galaxy Nexus",
                OS = "Android",
                IntalledApps = new List<string> { "Google Map", "Google+", "Google Play" }
            };
        }
    }
}
