using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Linq;

namespace Yax.Tests.SampleClasses
{
    //[ShowInDemoApplication]

    [SerializeAs("root")]
    public class Code4PublicThemesCollection : List<Theme>
    {
        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static Code4PublicThemesCollection GetSampleInstance()
        {
            var codeFont = new FontInfo(Color.Black, false, false);
            var headerBorder = new BorderInfo(true, false, true, true, Color.Blue);
            var headerFont = new FontInfo(Color.Black, true, false);

            var theme = new Theme
            {
                Name = "SampleTheme",
                CodeContentBackColor = Color.White,
                CodeContentFont = codeFont,
                HeaderBackColor = Color.Aqua,
                HeaderBorder = headerBorder,
                HeaderFont = headerFont,
                HeaderFontSize = 10,
                LineNumbersBackColor = Color.White,
                LineNumbersFont = codeFont,
                LineNumbersSeperatorLineColor = Color.Black,
                LineNumbersShowSeperatorLine = true,
                LineNumbersShowStringAfter = true,
                LineNumbersShowZeros = true,
                LineNumbersSpacesAfter = 2,
                LineNumbersSpacesBefore = 3,
                LineNumbersStringAfter = ":",
                MainContentBorder = headerBorder,
                MainContentFontSize = 9
            };

            var themeCol = new Code4PublicThemesCollection();
            themeCol.Add(theme);

            return themeCol;
        }
    }

    public class Theme
    {
        [AttributeFor(".#name")]
        public string Name { get; set; }

        [ElementFor("Header#Border")]
        public BorderInfo HeaderBorder { get; set; }

        [ElementFor("Header#Font")]
        public FontInfo HeaderFont { get; set; }

        [AttributeFor("Header/BackColor#value")]
        [CustomSerializer(typeof(ColorSerializer))]
        public Color HeaderBackColor { get; set; }

        [AttributeFor("Header/FontSize#value")]
        public int HeaderFontSize { get; set; }

        [ElementFor("MainContent#Border")]
        public BorderInfo MainContentBorder { get; set; }

        [AttributeFor("MainContent/FontSize#value")]
        public int MainContentFontSize { get; set; }

        [AttributeFor("LineNumbers/SeperatorLine#show")]
        public bool LineNumbersShowSeperatorLine { get; set; }

        [AttributeFor("LineNumbers/SeperatorLine#color")]
        [CustomSerializer(typeof(ColorSerializer))]
        public Color LineNumbersSeperatorLineColor { get; set; }

        [ElementFor("LineNumbers#Font")]
        public FontInfo LineNumbersFont { get; set; }

        [CustomSerializer(typeof(ColorSerializer))]
        [AttributeFor("LineNumbers/BackColor#value")]
        public Color LineNumbersBackColor { get; set; }

        [AttributeFor("LineNumbers/ShowZeros#value")]
        public bool LineNumbersShowZeros { get; set; }

        [AttributeFor("LineNumbers/CharAfterLineNo#show")]
        public bool LineNumbersShowStringAfter { get; set; }

        [AttributeFor("LineNumbers/CharAfterLineNo#value")]
        public string LineNumbersStringAfter { get; set; }

        [AttributeFor("LineNumbers/SpacesAfter#count")]
        public int LineNumbersSpacesAfter { get; set; }

        [AttributeFor("LineNumbers/SpacesBefore#count")]
        public int LineNumbersSpacesBefore { get; set; }

        [CustomSerializer(typeof(ColorSerializer))]
        [AttributeFor("CodeContent/BackColor#value")]
        public Color CodeContentBackColor { get; set; }

        [ElementFor("CodeContent#Font")]
        public FontInfo CodeContentFont { get; set; }

        
    }

    public class BorderInfo
    {
        public BorderInfo()
        {
            
        }

        public BorderInfo(bool top, bool bottom, bool left, bool right, Color color)
        {
            this.Top = top;
            this.Bottom = bottom;
            this.Left = left;
            this.Right = right;
            this.Color = color;
        }

        [AttributeFor(".#top")]
        public bool Top { get; set; }

        [AttributeFor(".#bottom")]
        public bool Bottom { get; set; }

        [AttributeFor(".#left")]
        public bool Left { get; set; }

        [AttributeFor(".#right")]
        public bool Right { get; set; }

        [AttributeFor(".#color")]
        [CustomSerializer(typeof(ColorSerializer))]
        public Color Color { get; set; }

    }

    public class FontInfo
    {
        public FontInfo()
        {
            
        }

        public FontInfo(Color color, bool bold, bool italic)
        {
            this.Bold = bold;
            this.Italic = italic;
            this.Color = color;
        }

        [AttributeFor(".#bold")]
        public bool Bold { get; set; }

        [AttributeFor(".#italic")]
        public bool Italic { get; set; }

        [CustomSerializer(typeof(ColorSerializer))]
        [AttributeFor(".#color")]
        public Color Color { get; set; }

    }

    internal class ColorSerializer : ICustomSerializer<Color>
    {
        public void SerializeToAttribute(Color objectToSerialize, XAttribute attrToFill)
        {
            attrToFill.Value = ColorTo6CharHtmlString(objectToSerialize);
        }

        public void SerializeToElement(Color objectToSerialize, XElement elemToFill)
        {
            elemToFill.Value = ColorTo6CharHtmlString(objectToSerialize);
        }

        public string SerializeToValue(Color objectToSerialize)
        {
            return ColorTo6CharHtmlString(objectToSerialize);
        }

        public Color DeserializeFromAttribute(XAttribute attrib)
        {
            Color color;
            if (TryParseColor(attrib.Value, out color))
                return color;

            throw new BadlyFormedInput(attrib.Name.ToString(), attrib.Value);
        }

        public Color DeserializeFromElement(XElement element)
        {
            Color color;
            if (TryParseColor(element.Value, out color))
                return color;

            throw new BadlyFormedInput(element.Name.ToString(), element.Value);
        }

        public Color DeserializeFromValue(string value)
        {
            Color color;
            if (TryParseColor(value, out color))
                return color;

            throw new BadlyFormedInput("[SomeValue]", value);
        }

                    public static string ColorTo8CharString(Color color)
        {
            string str = String.Format("{0:X}", color.ToArgb());

            var sb = new StringBuilder();
            for(int i = 0; i < 8 - str.Length; ++i)
            {
                sb.Append("0");
            }

            return sb + str;
        }

        public static string ColorTo6CharString(Color color)
        {
            return ColorTo8CharString(color).Substring(2);
        }

        public static string ColorTo6CharHtmlString(Color color)
        {
            return "#" + ColorTo6CharString(color);
        }

        public static bool TryParseColor(string strColor, out Color color)
        {
            color = Color.White;

            strColor = strColor.Trim();
            if (strColor.StartsWith("#")) // remove leading # if any
                strColor = strColor.Substring(1);
            
            int n;
            if (Int32.TryParse(strColor, System.Globalization.NumberStyles.HexNumber, null, out n))
            {
                color = Color.FromArgb(n);
                // sets the alpha value to 255
                color = Color.FromArgb(255, color.R, color.G, color.B);
                return true;
            }
            return false;
        }

    }



}
