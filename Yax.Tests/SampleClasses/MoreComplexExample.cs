﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Yax.Tests.SampleClasses
{
    [ShowInDemoApplication]

    [Comment(@"This example tries to show almost all features of YAXLib which were not shown before.
      FamousPoints - shows a dictionary with a non-primitive value member.
      IntEnumerable - shows serializing properties of type IEnumerable<>
      Students - shows the usage of YAXNotCollection attribute")]
    public class MoreComplexExample
    {
        [Dictionary(EachPairName = "PointInfo", KeyName = "PName",
            ValueName = "ThePoint", SerializeKeyAs = NodeTypes.Attribute,
            SerializeValueAs = NodeTypes.Attribute)]
        public Dictionary<string, MyPoint> FamousPoints { get; set; }

        private List<int> m_lst = new List<int>();

        public IEnumerable<int> IntEnumerable
        {
            get
            {
                return this.m_lst;
            }

            set
            {
                this.m_lst = value.ToList();
            }
        }

        [NotCollection]
        public Students Students { get; set; }

        public override string ToString()
        {
            return GeneralToStringProvider.GeneralToString(this);
        }

        public static MoreComplexExample GetSampleInstance()
        {
            Dictionary<string, MyPoint> famPoints = new Dictionary<string, MyPoint>();
            famPoints.Add("Center", new MyPoint() { X = 0, Y = 0 });
            famPoints.Add("Q1", new MyPoint() { X = 1, Y = 1 });
            famPoints.Add("Q2", new MyPoint() { X = -1, Y = 1 });

            int[] nArray = new int[] { 1, 3, 5, 7 };

            return new MoreComplexExample()
            {
                FamousPoints = famPoints,
                Students = Students.GetSampleInstance(),
                IntEnumerable = nArray
            };
        }
    }

    public class MyPoint
    {
        [AttributeForClass]
        public int X { get; set; }

        [AttributeForClass]
        public int Y { get; set; }

        public override string ToString()
        {
            return String.Format("({0}, {1})", this.X, this.Y);
        }
    }

    public class Students : IEnumerable<string>
    {
        public int Count { get; set; }

        public string[] Names { get; set; }

        public string[] Families { get; set; }

        public string GetAt(int i)
        {
            return String.Format("{0}, {1}", this.Families[i], this.Names[i]);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("Count = {0}", this.Count));
            sb.AppendLine(String.Format("Names: "));
            foreach (string str in this.Names)
                sb.Append(str + "  ");

            sb.AppendLine(String.Format("Families: "));
            foreach (string str in this.Families)
                sb.Append(str + "  ");

            return sb.ToString();
        }

        public static Students GetSampleInstance()
        {
            return new Students()
            {
                Count = 3,
                Names = new string[] { "Ali", "Dave", "John" },
                Families = new string[] { "Alavi", "Black", "Doe" }
            };
        }

        #region IEnumerable<string> Members

        public IEnumerator<string> GetEnumerator()
        {
            return new StudentsEnumerator(this);
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new StudentsEnumerator(this);
        }

        #endregion
    }

    public class StudentsEnumerator : IEnumerator<string>
    {
        Students m_students = null;
        int counter = -1;
        public StudentsEnumerator(Students studentsInstance)
        {
            this.m_students = studentsInstance;
            this.counter = -1;
        }

        #region IEnumerator<string> Members

        public string Current
        {
            get { return this.m_students.GetAt(this.counter); }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {

        }

        #endregion

        #region IEnumerator Members

        object IEnumerator.Current
        {
            get { return this.m_students.GetAt(this.counter); }
        }

        public bool MoveNext()
        {
            this.counter++;
            if (this.counter >= this.m_students.Count)
                return false;
            return true;
        }

        public void Reset()
        {
            this.counter = -1;
        }

        #endregion
    }


}
