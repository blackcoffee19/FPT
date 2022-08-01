using System;
class LBEP_Ex2{
    static void Main(string[] args){
        Console.WriteLine("Enter the width of Rectangle: ");
        string str1 = Console.ReadLine();
        Console.WriteLine("Enter the high of Rectangle: ");
        string str2 = Console.ReadLine();
        double x = Double.Parse(str1);
        double y = Double.Parse(str2);
        double per = (x+y)*2;
        double area = x*y;
        Console.WriteLine("");
        Console.WriteLine("\tPerimeter of the Rectangle: 2 * ({0:F1} +{1:F1}) = {2:F1}\n",x,y,per);
        Console.WriteLine("\tArea of the Rectangle: {0:F1} * {1:F1} = {2:F1}\n",x,y,area);
    }
}