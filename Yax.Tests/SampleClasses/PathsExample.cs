using System.Collections.Generic;

namespace Yax.Tests.SampleClasses
{
    [ShowInDemoApplication]

    [YAXComment(@"This example demonstrates how not to use 
      white spaces as separators while serializing 
      collection classes serially")]
    public class PathsExample
    {
        [YAXCollection(CollectionSerializationTypes.Serially, SeparateBy=";", IsWhiteSpaceSeparator=false)]
        public List<string> Paths { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static PathsExample GetSampleInstance()
        {
            List<string> paths = new List<string>();
            paths.Add(@"C:\SomeFile.txt");
            paths.Add(@"C:\SomeFolder\SomeFile.txt");
            paths.Add(@"C:\Some Folder With Space Such As\Program Files");

            return new PathsExample()
            {
                Paths = paths
            };
        }

    }
}
