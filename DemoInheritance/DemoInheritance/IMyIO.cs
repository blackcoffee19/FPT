using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInheritance
{
    internal interface IMyIO
    {
        void Save();
        public string Name
        {
            set;get;
        }
    }
}
