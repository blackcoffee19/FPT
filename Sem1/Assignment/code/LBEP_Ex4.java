import java.util.*;

public class LBEP_Ex4{
	public static void main(String[] args){
		Scanner input =  new Scanner(System.in);
		System.out.println("*****************************");
		System.out.println("\tJava Program language");
		System.out.println("\t1. Question 02.");
		System.out.println("\t2. Question 03.");
		System.out.println("\t3. Exit.");
		System.out.println("******************************");
		System.out.println("Enter choice: (1-3):");
		String str = input.next();
		int num = Integer.parseInt(str);
		if(num == 1){
			System.out.print("Enter the width of Rectangle: ");
			double x = Double.parseDouble(input.next());
			System.out.print("Enter the high of Rectangle: ");
			double y = Double.parseDouble(input.next());
			System.out.printf("\tPerimeter of the Rectangle: 2 * (%.1f + %.1f) = %.1f\n", x,y,2*(x+y));
			System.out.printf("\tArea of the Rectangle: %.1f * %.1f = %.1f\n",x,y,x*y);
		} else if(num == 2){
			System.out.print("Enter the radius of Circle: ");
			double z = Double.parseDouble(input.next());
			System.out.printf("\tPerimeter of the Circle: 2 * %.2f *3.14 = %.2f\n", z, 2*z*3.14);
			System.out.printf("\tArea of the Circle: %.2f * %.2f *3.14 = %.2f\n",z,z*z*3.14);
		}else{
			System.out.println("Goodbye");
		}
	}

}
