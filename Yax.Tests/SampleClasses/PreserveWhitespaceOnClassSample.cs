using System.Collections.Generic;

namespace Yax.Tests.SampleClasses
{
    [PreserveWhitespace]
    public class PreserveWhitespaceOnFieldsSample
    {
        public string Str1 { get; set; }

        public string Str2 { get; set; }

        [ValueFor("SomeElem")]
        public string Str3 { get; set; }

        public string[] Strings { get; set; }

        public Dictionary<string, int> StringDic { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static PreserveWhitespaceOnFieldsSample GetSampleInstance()
        {
            return new PreserveWhitespaceOnFieldsSample
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
