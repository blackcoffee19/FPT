
package Exercise;


import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;
import java.util.ArrayList;
import java.util.Scanner;
public class WriteObject {
    public static Employee inputEm (){
        Scanner sc = new Scanner(System.in);
        System.out.println("\nNhap thong tin nhan vien");
        Employee em = new Employee();
        System.out.print("Id nhan vien: ");
        em.setId(sc.nextLine().trim());
        System.out.print("Ten nhan vien: ");
        em.setName(sc.nextLine().trim());
        System.out.print("Tuoi nhan vien: ");
        em.setAge(sc.nextLine().trim());
        return em;
    }
    public static void main(String[] args) throws IOException{
        ArrayList<Employee> list  = new ArrayList();
        for(int i = 0; i <3;i++){
            Employee e = inputEm();
            list.add(e);
        };
        try( FileOutputStream fileWri = new FileOutputStream("nhanvien.bin"))
        {
            ObjectOutputStream obj = new ObjectOutputStream(fileWri);
            for(int i = 0; i<3; i++){
                System.out.println(list.get(i));
                obj.writeObject(list.get(i));
            }
            obj.close();
            System.out.println("Write file successfull!");
        }catch(IOException e){
            System.out.println("Error "+e);
        };
        
    }
}
