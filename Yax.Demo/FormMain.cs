using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using Yax.Tests;
using Yax.Tests.SampleClasses;

namespace Yax.Demo
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            InitListOfClasses();
            InitComboBoxes();
        }

        private void InitComboBoxes()
        {
            this.comboPolicy.Items.AddRange(Enum.GetNames(typeof(ExceptionHandlingPolicies)));
            this.comboErrorType.Items.AddRange(Enum.GetNames(typeof(ExceptionTypes)));
            this.comboOptions.Items.AddRange(Enum.GetNames(typeof(YAXSerializationOptions)));

            if (this.comboPolicy.Items.Count > 0)
                this.comboPolicy.Text = ExceptionHandlingPolicies.DoNotThrow.ToString();
            if(this.comboErrorType.Items.Count > 0)
                this.comboErrorType.Text = ExceptionTypes.Error.ToString();
            if (this.comboOptions.Items.Count > 0)
                this.comboOptions.Text = YAXSerializationOptions.SerializeNullObjects.ToString();
        }

        private ExceptionTypes GetSelectedDefaultExceptionType()
        {
            return (ExceptionTypes)Enum.Parse(typeof(ExceptionTypes), this.comboErrorType.Text);
        }

        private ExceptionHandlingPolicies GetSelectedExceptionHandlingPolicy()
        {
            return (ExceptionHandlingPolicies)Enum.Parse(typeof(ExceptionHandlingPolicies), this.comboPolicy.Text);
        }

        private YAXSerializationOptions GetSelectedSerializationOption()
        {
            return (YAXSerializationOptions)Enum.Parse(typeof(YAXSerializationOptions), this.comboOptions.Text);
        }

        private void InitListOfClasses()
        {
            var autoLoadTypes = typeof(Book).Assembly.GetTypes()
                .Where(t => t.GetCustomAttributes(typeof(ShowInDemoApplicationAttribute), false).Any())
                .OrderBy(t =>
                {
                    var attr = t.GetCustomAttributes(typeof(ShowInDemoApplicationAttribute), false)
                        .FirstOrDefault()
                        as ShowInDemoApplicationAttribute;

                    if (attr != null && !String.IsNullOrEmpty(attr.SortKey))
                        return attr.SortKey;
                    return t.Name;
                });

            var sb = new StringBuilder();
            foreach (Type type in autoLoadTypes)
            {
                try
                {
                    var method = type.GetMethod("GetSampleInstance", new Type[0]);
                    var instance = method.Invoke(null, null);
                    this.lstSampleClasses.Items.Add(new ClassInfoListItem(type, instance));
                }
                catch
                {
                    sb.AppendLine(type.FullName);
                }
            }

            if (sb.Length > 0)
            {
                MessageBox.Show("Please provide a parameterless public static method called \"GetSampleInstance\" for the following classes:"
                    + Environment.NewLine + sb.ToString());
            }
        }

        private void btnSerialize_Click(object sender, EventArgs e)
        {
            OnSerialize(false);
        }

        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            OnDeserialize(false);
        }

        private void lstSampleClasses_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnSerialize(false);
        }

        private void btnSerializeToFile_Click(object sender, EventArgs e)
        {
            OnSerialize(true);
        }

        private void btnDeserializeFromFile_Click(object sender, EventArgs e)
        {
            OnDeserialize(true);
        }

        private void OnDeserialize(bool openFromFile)
        {
            this.rtbParsingErrors.Text = "";
            object selItem = this.lstSampleClasses.SelectedItem;
            if (selItem == null || !(selItem is ClassInfoListItem))
                return;

            string fileName = null;
            if (openFromFile)
            {
                if (DialogResult.OK != this.openFileDialog1.ShowDialog())
                    return;
                fileName = this.openFileDialog1.FileName;
            }

            var info = selItem as ClassInfoListItem;
            ExceptionTypes defaultExType = GetSelectedDefaultExceptionType();
            ExceptionHandlingPolicies exPolicy = GetSelectedExceptionHandlingPolicy();
            YAXSerializationOptions serOption = GetSelectedSerializationOption();

            try
            {
                object deserializedObject = null;
                YAXSerializer serializer = new YAXSerializer(info.ClassType, exPolicy, defaultExType, serOption);

                if (openFromFile)
                    deserializedObject = serializer.DeserializeFromFile(fileName);
                else
                    deserializedObject = serializer.Deserialize(this.rtbXMLOutput.Text);

                this.rtbParsingErrors.Text = serializer.ParsingErrors.ToString();

                if (deserializedObject != null)
                {
                    this.rtbDeserializeOutput.Text = deserializedObject.ToString();

                    if (deserializedObject is List<string>)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var item in deserializedObject as List<string>)
                        {
                            sb.AppendLine(item.ToString());
                        }
                        MessageBox.Show(sb.ToString());
                    }
                }
                else
                    this.rtbDeserializeOutput.Text = "The deserialized object is null";
            }
            catch (YAXException ex)
            {
                this.rtbDeserializeOutput.Text = "";
                MessageBox.Show("YAXException handled:\r\n\r\n" + ex.ToString());
            }
            catch (Exception ex)
            {
                this.rtbDeserializeOutput.Text = "";
                MessageBox.Show("Other Exception handled:\r\n\r\n" + ex.ToString());
            }
        }

        private void OnSerialize(bool saveToFile)
        {
            object selItem = this.lstSampleClasses.SelectedItem;
            if (selItem == null || !(selItem is ClassInfoListItem))
                return;

            string fileName = null;
            if (saveToFile)
            {
                if (DialogResult.OK != this.saveFileDialog1.ShowDialog()) 
                    return;
                fileName = this.saveFileDialog1.FileName;
            }

            ClassInfoListItem info = selItem as ClassInfoListItem;
            ExceptionTypes defaultExType = GetSelectedDefaultExceptionType();
            ExceptionHandlingPolicies exPolicy = GetSelectedExceptionHandlingPolicy();
            YAXSerializationOptions serOption = GetSelectedSerializationOption();

            try
            {
                YAXSerializer serializer = new YAXSerializer(info.ClassType, exPolicy, defaultExType, serOption);

                if (saveToFile)
                    serializer.SerializeToFile(info.SampleObject, fileName);
                else
                    this.rtbXMLOutput.Text = serializer.Serialize(info.SampleObject);
                this.rtbParsingErrors.Text = serializer.ParsingErrors.ToString();
            }
            catch (YAXException ex)
            {
                MessageBox.Show("YAXException handled:\r\n\r\n" + ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Other Exception handled:\r\n\r\n" + ex.ToString());
            }
        }
    }
}
