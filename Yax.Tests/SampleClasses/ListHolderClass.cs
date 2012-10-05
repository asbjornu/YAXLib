﻿using System.Collections.Generic;
using System.Text;

namespace Yax.Tests.SampleClasses
{
    public class ListHolderClass
    {
        public List<string> ListOfStrings { get; set; }

        public ListHolderClass()
        {
            this.ListOfStrings = new List<string>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.ListOfStrings)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        public static ListHolderClass GetSampleInstance()
        {
            var inst = new ListHolderClass();

            inst.ListOfStrings.Add("Hi");
            inst.ListOfStrings.Add("Hello");

            return inst;
        }

    }
}