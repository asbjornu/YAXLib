namespace Yax.Tests.SampleClasses
{
    public class AudioSample
    {
        [ErrorIfMissed(ExceptionTypes.Ignore)]
        public string Audio { get; set; }
        
        [SerializeAs("FileName")]
        [AttributeFor("Audio")]
        [ErrorIfMissed(ExceptionTypes.Ignore, DefaultValue = "")]
        public string AudioFileName { get; set; }
        
        [ErrorIfMissed(ExceptionTypes.Ignore)]
        public string Image { get; set; }

        [SerializeAs("FileName")]
        [AttributeFor("Image")]
        [ErrorIfMissed(ExceptionTypes.Ignore, DefaultValue = "")]
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
