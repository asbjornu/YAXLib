using System;
using System.Xml.Linq;

namespace Yax.Tests.SampleClasses
{
    public class ClassContainingXElement
    {
        public XElement TheElement { get; set; }
        public XAttribute TheAttribute { get; set; }


        public override string ToString()
        {
            return String.Format("TheElement: {0}\r\nTheAttribute: {1}\r\n",
                this.TheElement, this.TheAttribute);
        }

        public static ClassContainingXElement GetSampleInstance()
        {
            var elem = new XElement("SomeElement", 
                new XElement("Child", "Content"),
                new XElement("Multi-level", 
                    new XElement("GrandChild", "Content")),
                new XAttribute("someattribute", "value"));

            var attrib = new XAttribute("attrib", "TheAttribValue");

            return new ClassContainingXElement {TheElement = elem, TheAttribute = attrib};
        }
    }
}
