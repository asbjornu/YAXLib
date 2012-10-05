namespace Yax.Tests.SampleClasses
{
    public class AudioSample
    {
        [YAXErrorIfMissed(ExceptionTypes.Ignore)]
        public string Audio { get; set; }
        
        [YAXSerializeAs("FileName")]
        [YAXAttributeFor("Audio")]
        [YAXErrorIfMissed(ExceptionTypes.Ignore, DefaultValue = "")]
        public string AudioFileName { get; set; }
        
        [YAXErrorIfMissed(ExceptionTypes.Ignore)]
        public string Image { get; set; }

        [YAXSerializeAs("FileName")]
        [YAXAttributeFor("Image")]
        [YAXErrorIfMissed(ExceptionTypes.Ignore, DefaultValue = "")]
        public string ImageFileName { get; set; }
        
        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static AudioSample GetSampleInstance()
        {
            return new AudioSample()
            {
                Audio = "base64",
                AudioFileName = "filesname.jpg",
                Image = "base64",
                ImageFileName = "filesname.jpg"
            };
        }
    }
}
