using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInheritance
{
    internal class Shape
    {
        string color;
        public string Color { get { return color; } set { color = value; } }
        public Shape()
        {
            Console.WriteLine("Shape default contructor");
        }
        public Shape(string color)
        {
            Color = color;
        }

        public virtual void Draw()
        {
            Console.WriteLine("This is Shape.Draw()");
        }
        public void Print()
        {
            Console.WriteLine("This is Shape.Print");
        }
    }
}
