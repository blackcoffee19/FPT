using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInheritance
{
    internal class Circle: Shape, IMyIO
    {
        public override void Draw()
        {
            base.Draw();

        }
        public void Save();
    }
}
