using System;

namespace Yax.Tests
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class ShowInDemoApplicationAttribute : Attribute
    {
        public ShowInDemoApplicationAttribute()
        {
            this.SortKey = null;
        }

        public string SortKey { get; set; }
    }
}
