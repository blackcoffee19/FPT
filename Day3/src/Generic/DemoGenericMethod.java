
package Generic;


public class DemoGenericMethod {
    public static <T> void printArray(T[] elements){
        for(T el: elements){
            System.out.println(el);
        }   
    }
    
}
