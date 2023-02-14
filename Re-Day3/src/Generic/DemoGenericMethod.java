
package Generic;

public class DemoGenericMethod {
   public static <T> void printArray(T[] elements){
        for(T el: elements){
            System.out.println(el);
        }   
    } 
    public static void main(String[] args) {
        Integer[] intArray = {1,2,3,5};
        Double[] douArray = {1.23,2.3,5.2,65.4};
        Character[] charArray  = {'H','E','L','L','O'};
        System.out.println("Int Array: ");
        DemoGenericMethod.printArray(intArray);
        System.out.println("Double Array: ");
        DemoGenericMethod.printArray(douArray);
        System.out.println("Char Array: ");
        DemoGenericMethod.printArray(charArray);
    }
}
