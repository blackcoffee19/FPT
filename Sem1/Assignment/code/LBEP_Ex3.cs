using System;
class Program{
    static void Main(String[] agrs){
        Console.WriteLine("Enter the radius of Circle: ");
        string str = Console.ReadLine();
        double num = Double.Parse(str);
        Console.WriteLine("\tPerimeter of the Circle: 2 * {0:F2} * 3.14 = {1:F2}\n",num,num*2*3.14);
        Console.WriteLine("\tArea of the Circle: {0:F2} * {0:F2} * 3.14 = {1:F2}\n",num, num*num*3.14);
    }
}