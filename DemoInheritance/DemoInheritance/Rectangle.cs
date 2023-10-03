using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInheritance
{
    internal class Rectangle : Shape
    {
        public void Show()
        {
            Console.WriteLine($"Rectangle Show");
        }
        public Rectangle() : base("red")
        {
            Console.WriteLine($"Shape contructor : color-{base.Color}");
        }
        public override void Draw()
        {
            base.Draw();
            Console.WriteLine($"Retangle Draw");
        }
        public new void Print()
        {
            Console.WriteLine("This is Rectanger");
        }
    }
}
