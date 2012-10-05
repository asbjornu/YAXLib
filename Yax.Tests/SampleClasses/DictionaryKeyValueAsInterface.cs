using System.Collections.Generic;

// test class created to discuss:
// http://yaxlib.codeplex.com/discussions/287166
// reported by CodePlex User: GraywizardX

namespace Yax.Tests.SampleClasses
{
    [ShowInDemoApplication]

    public class DictionaryKeyValueAsInterface
    {
        [YAXComment("Values are serialized through a reference to their interface.")]
        [YAXErrorIfMissed(ExceptionTypes.Ignore)]
        [YAXDictionary(EachPairName = "attribute", KeyName = "key", SerializeKeyAs = NodeTypes.Attribute)]
        public Dictionary<string, IParameter> Attributes1 { get; set; }

        [YAXComment("Keys are serialized through a reference to their interface.")]
        [YAXErrorIfMissed(ExceptionTypes.Ignore)]
        [YAXDictionary(EachPairName = "Entry", ValueName = "value", SerializeValueAs = NodeTypes.Attribute)]
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

    [YAXSerializeAs("parameter")]
    public abstract class ParameterBase : IParameter
    {
        [YAXSerializeAs("name")]
        [YAXAttributeFor("..")]
        [YAXErrorIfMissed(ExceptionTypes.Error)]
        public string Name { get; set; }

        [YAXSerializeAs("type")]
        [YAXAttributeFor("..")]
        [YAXErrorIfMissed(ExceptionTypes.Ignore)]
        public string Type { get; set; }

        [YAXValueFor("..")]
        [YAXErrorIfMissed(ExceptionTypes.Ignore)]
        public string Body { get; set; }
    }

    public class GenericMessageParameter : ParameterBase
    {
    }

}
