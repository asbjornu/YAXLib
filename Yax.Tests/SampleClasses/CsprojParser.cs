using System.Collections.Generic;

namespace Yax.Tests.SampleClasses
{
    public class CsprojParser
    {
        public static ProjectBuildDefinition Parse(string xml)
        {
            var yaxSer = new Serializer(typeof(ProjectBuildDefinition),
                ExceptionHandlingPolicies.DoNotThrow,
                ExceptionTypes.Ignore,
                SerializationOptions.DontSerializeNullObjects);

            return yaxSer.Deserialize(xml) as ProjectBuildDefinition;
        }

        public static string ParseAndRegenerateXml(string xml)
        {
            var project = Parse(xml);

            var yaxSer = new Serializer(typeof(ProjectBuildDefinition),
                ExceptionHandlingPolicies.DoNotThrow,
                ExceptionTypes.Ignore,
                SerializationOptions.DontSerializeNullObjects);

            return yaxSer.Serialize(project);
        }
    }

    [Namespace("http://schemas.microsoft.com/developer/msbuild/2003")]
    [SerializeAs("Project")]
    public class ProjectBuildDefinition
    {
        [AttributeForClass]
        public string ToolsVersion { get; set; }

        [AttributeForClass]
        public string DefaultTargets { get; set; }

        [Collection(CollectionSerializationTypes.RecursiveWithNoContainingElement,
            EachElementName = "PropertyGroup")]
        public List<PropertyGroup> PropertyGroups { get; set; }

        [Collection(CollectionSerializationTypes.RecursiveWithNoContainingElement,
           EachElementName = "ItemGroup")]
        public List<ItemGroup> ItemGroups { get; set; }

        [Collection(CollectionSerializationTypes.RecursiveWithNoContainingElement,
           EachElementName = "Import")]
        public List<ImportItem> ImportItems { get; set; }
    }

    public class PropertyGroup
    {
        public string Configuration { get; set; }

        [SerializeAs("Condition")]
        [AttributeFor("Configuration")]
        public string ConfigCondition { get; set; }


        public string Platform { get; set; }

        [SerializeAs("Condition")]
        [AttributeFor("Platform")]
        public string PlatformCondition { get; set; }

        public string ProductVersion { get; set; }
        public string SchemaVersion { get; set; }
        public string ProjectGuid { get; set; }
        public string OutputType { get; set; }
        public string AppDesignerFolder { get; set; }
        public string RootNamespace { get; set; }
        public string AssemblyName { get; set; }
        public string TargetFrameworkVersion { get; set; }
        public string FileAlignment { get; set; }

        public bool DebugSymbols { get; set; }
        public string DebugType { get; set; }
        public bool Optimize { get; set; }
        public string OutputPath { get; set; }
        public string DefineConstants { get; set; }
        public string ErrorReport { get; set; }
        public int WarningLevel { get; set; }
        public string DocumentationFile { get; set; }
        public string PostBuildEvent { get; set; }
    }


    public class ItemGroup
    {
        [Collection(CollectionSerializationTypes.RecursiveWithNoContainingElement, 
            EachElementName = "Reference")]
        public List<ReferenceItem> ReferenceItems { get; set; }
    }


    [SerializeAs("Reference")]
    public class ReferenceItem
    {
        [AttributeForClass]
        public string Include { get; set; }

        public string HintPath { get; set; }
        public string RequiredTargetFramework { get; set; }
        public bool SpecificVersion { get; set; }
    }

    [SerializeAs("Import")]
    public class ImportItem
    {
        [AttributeForClass()]
        public string Project { get; set; }
    }

}
