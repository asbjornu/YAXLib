using System.Collections.Generic;

// test class created to discuss:
// http://yaxlib.codeplex.com/discussions/287166
// reported by CodePlex User: GraywizardX

namespace Yax.Tests.SampleClasses
{
    [ShowInDemoApplication]

    public class DictionaryKeyValueAsInterface
    {
        [Comment("Values are serialized through a reference to their interface.")]
        [ErrorIfMissed(ExceptionTypes.Ignore)]
        [Dictionary(EachPairName = "attribute", KeyName = "key", SerializeKeyAs = NodeTypes.Attribute)]
        public Dictionary<string, IParameter> Attributes1 { get; set; }

        [Comment("Keys are serialized through a reference to their interface.")]
        [ErrorIfMissed(ExceptionTypes.Ignore)]
        [Dictionary(EachPairName = "Entry", ValueName = "value", SerializeValueAs = NodeTypes.Attribute)]
        public Dictionary<IParameter, string> Attributes2 { get; set; }


        public DictionaryKeyValueAsInterface()
        {
            this.Attributes1 = new Dictionary<string, IParameter>();
            this.Attributes2 = new Dictionary<IParameter, string>();
        }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static DictionaryKeyValueAsInterface GetSampleInstance()
        {
            var test = new DictionaryKeyValueAsInterface();

            test.Attributes1.Add("test", new GenericMessageParameter { Name = "name1", Type = "int", Body = "27" });
            test.Attributes2.Add(new GenericMessageParameter { Name = "name2", Type = "str", Body = "30" }, "test");

            return test;
        }
    }

    public interface IParameter
    {
        string Name { get; set; }
        string Type { get; set; }
        string Body { get; set; }
    }

    [SerializeAs("parameter")]
    public abstract class ParameterBase : IParameter
    {
        [SerializeAs("name")]
        [AttributeFor("..")]
        [ErrorIfMissed(ExceptionTypes.Error)]
        public string Name { get; set; }

        [SerializeAs("type")]
        [AttributeFor("..")]
        [ErrorIfMissed(ExceptionTypes.Ignore)]
        public string Type { get; set; }

        [ValueFor("..")]
        [ErrorIfMissed(ExceptionTypes.Ignore)]
        public string Body { get; set; }
    }

    public class GenericMessageParameter : ParameterBase
    {
    }

}
