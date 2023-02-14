package Exercise;
import java.io.Serializable;
import java.util.Scanner;
public class Employee implements Serializable{ 
    private String id, name, age;

    public Employee() {
    }

    public Employee(String id, String name, String age) {
        this.id = id;
        this.name = name;
        this.age = age;
    }

    public String getAge() {
        return age;
    }

    public String getId() {
        return id;
    }

    public String getName() {
        return name;
    }
    
    public void setAge(String age) {
        this.age = age;
    }

    public void setId(String id) {
        this.id = id;
    }

    public void setName(String name) {
        this.name = name;
    }
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Nhap thong tin nhan vien");
        Employee em = new Employee();
        System.out.print("Id nhan vien: ");
        em.setId(sc.nextLine().trim());
        System.out.print("Ten nhan vien: ");
        em.setName(sc.nextLine().trim());
        System.out.print("Tuoi nhan vien: ");
        em.setAge(sc.nextLine().trim());
        
    }
}
