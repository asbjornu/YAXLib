namespace Yax.Tests.SampleClasses
{
    [ShowInDemoApplication]

    public class PathAndAliasAssignmentSample
    {
        [AttributeFor("Title#value")]
        public string Title { get; set; }

        [AttributeFor("Price#value")]
        public double Price { get; set; }

        [AttributeFor("Publish#year")]
        public int PublishYear { get; set; }

        [AttributeFor("Notes/Comments#value")]
        public string Comments { get; set; }

        [AttributeFor("Author#name")]
        public string Author { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static PathAndAliasAssignmentSample GetSampleInstance()
        {
            return new PathAndAliasAssignmentSample
            {
                Title = "Inside C#",
                Author = "Tom Archer & Andrew Whitechapel",
                PublishYear = 2002,
                Price = 30.5,
                Comments = "SomeComment",
            };
        }
    }
}
