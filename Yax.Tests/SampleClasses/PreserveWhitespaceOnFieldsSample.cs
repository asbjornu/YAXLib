using System.Collections.Generic;

namespace Yax.Tests.SampleClasses
{
    public class PreserveWhitespaceOnClassSample
    {
        [PreserveWhitespace]
        public string Str1 { get; set; }

        [PreserveWhitespace]
        public string Str2 { get; set; }

        [PreserveWhitespace]
        [ValueFor("SomeElem")]
        public string Str3 { get; set; }

        [PreserveWhitespace]
        public string[] Strings { get; set; }

        [PreserveWhitespace]
        public Dictionary<string, int> StringDic { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static PreserveWhitespaceOnClassSample GetSampleInstance()
        {
            return new PreserveWhitespaceOnClassSample
                       {
                           Str1 = "       ", 
                           Str2 = "  \t   ",
                           Str3 = "         ",
                           Strings = new [] {"abc", "     ", "efg"},
                           StringDic = new Dictionary<string, int> {{"abc", 1}, {"    ", 2}, {"efg", 3}}
                       };
        }
    }
}
