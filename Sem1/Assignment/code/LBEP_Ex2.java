import java.util.Scanner;

public class LBEP_Ex2 {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("Enter the width of Rectangle: ");
        String str1 = input.next();
        System.out.println("Enter the high of Rectangle: ");
        String str2 = input.next();
        double x = Double.parseDouble(str1);            
        double y = Double.parseDouble(str2);
        input.close();
        double per = (x+y)*2;
        double area = x*y;
        System.out.printf("\tPerimeter of the Rectangle: 2 *(%.1f+%.1f) = %.1f\n",x,y,per);
        System.out.printf("\tArea of the Rectangle: %.1f * %.1f = %.1f\n",x,y,area);            
    }
}