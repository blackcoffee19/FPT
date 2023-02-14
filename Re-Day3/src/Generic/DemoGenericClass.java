package Generic;

public class DemoGenericClass<T> {
    T obj; //Khai bao T co the la bat cu kieu bien nao
    //Ham dung de cac class khac goi den class generic nay

    public DemoGenericClass() {
    }

    public DemoGenericClass(T obj) {
        this.obj = obj;
    }
    //Ham tra ve gia tri
    public T getObj() {
        return this.obj;
    }
    public static void main(String[] args) {
        DemoGenericClass intObj = new DemoGenericClass<Integer>(14);
        System.out.println("Integer value: "+intObj.getObj());
        
        
        DemoGenericClass strObj = new DemoGenericClass<String>("Generic class");
        System.out.println("String value: "+strObj.getObj());
    }
}
