
package DemoException;

public class Class {
    public static void main(String[] args) {
        try{
            int divByZero = 5/0;
            System.out.println("Rest of code block");
        }catch(Exception e){
            System.out.println("ArithmeticException: "+e);
        }finally{
            System.out.println("This is finally block");
        }
    }
}
