namespace Yax.Tests.SampleClasses.Namespace
{
    public class XmlNamespaceElementNames
    {
        [SerializeAs("NoNs")]
        public string WithoutNamespace { get; set; }

        [SerializeAs("{xs}WithNs")]
        public string WithNamespace { get; set; }

        [SerializeAs("{xs}Another")]
        public string AnotherOne { get; set; }

        
        public static XmlNamespaceElementNames GetSampleInstance()
        {
            return new XmlNamespaceElementNames();
        }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }
    }
}
