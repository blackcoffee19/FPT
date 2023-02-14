
package day3;
import Generic.DemoGenericClass;
import Generic.DemoGenericMethod;
public class Day3 {

    public static void main(String[] args) {
        DemoGenericClass intObj = new DemoGenericClass<Integer>(14);
        System.out.println("Integer value: "+intObj.getObj());
        
        
        DemoGenericClass strObj = new DemoGenericClass<String>("Generic class");
        System.out.println("String value: "+strObj.getObj());
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
