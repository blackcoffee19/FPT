using System;
class LBEP_Ex4{
	static void Main(string[] args){
		Console.WriteLine("************************************\n");
		Console.WriteLine("\tC sharp Program language: ");
		Console.WriteLine("\t1. Question 02.");
		Console.WriteLine("\t2. Question 03.");
		Console.WriteLine("\t3. Exit.");
		Console.WriteLine("************************************");
		Console.Write("\tEnter Choice (1-3): ");
		string str = Console.ReadLine();
		int num = Int32.Parse(str);
		if(num == 1){
			Console.WriteLine("Enter the width of Rectangle: ");
			double x = Double.Parse(Console.ReadLine());
			Console.WriteLine("Enter the high of Rectangle: ");
			double  y = Double.Parse(Console.ReadLine());
			double per = (x + y)*2;
			double area = x*y;
			Console.WriteLine("\tPerimeter of the Rectangle: 2* ({0:F1} +{1:F1}) = {2:F1}",x,y,per);
			Console.WriteLine("\tArea of the Rectangle: {0:F1} * {1:F1} = {2:F1}",x,y,area);
		} else if(num == 2){
			Console.WriteLine("Enter the radius of the Circle: ");
			double z = Double.Parse(Console.ReadLine());
			double per_c = z * 2 * 3.14;
			double area_c = z*z*3.14;
			Console.WriteLine("\tPerimeter of the Circle: 2 * {0:F1} *3.14 = {1:F1}",z,per_c);
			Console.WriteLine("\tArea of the Circle : {0:F1} * {0:F1} *3.14 = {1:F1}",z,area_c);
	
		} else {
			Console.WriteLine("Goodbye\n");
		}
	}
}
