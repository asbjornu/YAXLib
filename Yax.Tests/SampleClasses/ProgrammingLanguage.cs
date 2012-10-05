namespace Yax.Tests.SampleClasses
{
    [ShowInDemoApplication]

    [YAXComment("This example is used in the article to show YAXLib exception handling policies")]
    public class ProgrammingLanguage
    {
        [YAXErrorIfMissed(ExceptionTypes.Error)]
        public string LanguageName { get; set; }

        [YAXErrorIfMissed(ExceptionTypes.Warning, DefaultValue = true)]
        public bool IsCaseSensitive { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static ProgrammingLanguage GetSampleInstance()
        {
            return new ProgrammingLanguage()
            {
                LanguageName = "C#",
                IsCaseSensitive = true
            };
        }
    }
}
