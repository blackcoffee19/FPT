using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    public class Calculate
    {
        int data;
        static Calculate()
        {
            int count = 0;
        }
        public int Add(ref int a,ref int b)
        {
            a = 10;
            b = 21;
            Console.WriteLine($"In method a ={a} + b ={b} = {a + b}");
            return a + b;
        }
        public int Sub(int a, int b = 2)
        {
            return a - b;
        }
    }
}
