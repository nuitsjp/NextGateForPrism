using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGateForPrism
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PageNavigationAttribute : Attribute
    {
        public string Name { get; set; }
        public PageNavigationAttribute(string name)
        {
            Name = name;
        }
    }
}
