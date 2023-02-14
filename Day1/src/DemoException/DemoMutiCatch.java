
package DemoException;
import java.io.*;
public class DemoMutiCatch {

    public static void main(String[] args) {
        try {
            int arr[] = new int[10];
            arr[10] = 30/0;
        } catch  (ArithmeticException | ArrayIndexOutOfBoundsException e) {
            System.out.println( e.getMessage());
        }
    }
}
