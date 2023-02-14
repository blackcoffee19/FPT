
package DemoException;

public class ThrowCustomeExcep {
    public static void main(String[] args) {
        try {
            throw new DemoCustomException();
        } catch (DemoCustomException e) {
            System.out.println( e.getMessage());
        }
    }
}
