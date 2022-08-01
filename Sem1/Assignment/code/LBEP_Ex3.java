import java.util.*;
import java.io.*;
public class LBEP_Ex3 {
    public static void main(String[] args){
        System.out.println("Enter the radius of Circle: ");
        Scanner input = new Scanner(System.in);
        String str = input.nextLine();
        double num = Double.parseDouble(str);
        System.out.printf("\tPerimeter of the Circle: 2 * %.2f * 3.14 = %.2f\n",num,num*2*3.14);
        System.out.printf("\tArea of the Circle: %.2f * %.2f * 3.14 = %.2f\n", num, num, num*num*3.14);

    }
}