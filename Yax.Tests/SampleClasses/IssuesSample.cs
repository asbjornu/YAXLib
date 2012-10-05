using System;
using System.Collections.Generic;

namespace Yax.Tests.SampleClasses
{
    [SerializeAs("issues")]
    public class IssuesSample
    {
        [Collection(CollectionSerializationTypes.RecursiveWithNoContainingElement, EachElementName="issue")]
        public List<Issue> Issues { get; set; }

        [SerializeAs("type")]
        [AttributeForClass]
        public string Type { get; set; }

        [SerializeAs("count")]
        [AttributeForClass]
        public int Count { get; set; }

        public static IssuesSample GetSampleInstance()
        {
            List<Issue> issues = new List<Issue>();

            Issue issue1 = new Issue()
            {
                IssueID = 425,
                ProjectName = "Tech Pubs Box",
                ProjectId = 141,
                TrackerName = "Bug",
                TrackerId = 1,
                Subject = "::project::Platform test",
                Description = "",
                StartDate = new DateTime(2010, 5, 20),
                DueDate = new DateTime(2010, 5, 20),
                CreatedOn = new DateTime(2010, 5, 20, 14, 19, 59, 700),
                UpdatedOn = new DateTime(2010, 5, 20, 14, 20, 37, 700),
                CustomFields = new List<CustomField>() 
                { 
                    new CustomField("Provided Steps to Reproduce", 69, "0"),
                    new CustomField("Steps to Reproduce", 71, ""),
                    new CustomField("Browser", 1, ""),
                    new CustomField("Platform", 77, "n/a"),
                    new CustomField("Workaround", 49, ""),
                    new CustomField("Customer", 47, ""),
                }
            };

            issues.Add(issue1);
            return new IssuesSample()
            {   Type = "array",
                Count = 22,
                Issues = issues
            };
        }
    }

    public class Issue
    {
        [SerializeAs("id")]
        public int IssueID { get; set; }

        [SerializeAs("name")]
        [AttributeFor("project")]
        public string ProjectName { get; set; }

        [SerializeAs("id")]
        [AttributeFor("project")]
        public int ProjectId { get; set; }

        [SerializeAs("name")]
        [AttributeFor("tracker")]
        public string TrackerName { get; set; }

        [SerializeAs("id")]
        [AttributeFor("tracker")]
        public int TrackerId { get; set; }

             // do the same for status, priority, author

        [SerializeAs("subject")]
        public string Subject { get; set; }

        [SerializeAs("description")]
        public string Description { get; set; }

        [SerializeAs("start_date")]
        [Format("yyyy-MM-dd")]
        public DateTime StartDate { get; set; }

        [SerializeAs("due_date")]
        [Format("yyyy-MM-dd")]
        public DateTime DueDate { get; set; }

        // and so on

        [Collection(CollectionSerializationTypes.Recursive, EachElementName="custom_field")]
        [SerializeAs("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        [SerializeAs("created_on")]
        [Format("R")]
        public DateTime CreatedOn { get; set; }

        [SerializeAs("updated_on")]
        [Format("R")]
        public DateTime UpdatedOn { get; set; }
    }

    public class CustomField
    {
        [SerializeAs("name")]
        [AttributeForClass]
        public string Name { get; set; }

        [SerializeAs("id")]
        [AttributeForClass]
        public int ID { get; set; }

        [SerializeAs("value")]
        [AttributeForClass]
        public string Value { get; set; }

        public CustomField(string name, int id, string value)
        {
            this.Name = name;
            this.ID = id;
            this.Value = value;
        }
    }
}
