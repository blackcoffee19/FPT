
package Exercise;

import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;


public class WriteToFile {
    public static void main(String[] args) throws IOException{
        Scanner sc = new Scanner(System.in);
        System.out.println("Nhap thong tin nhan vien");
        Employee em = new Employee();
        System.out.print("Id nhan vien: ");
        em.setId(sc.nextLine().trim());
        System.out.print("Ten nhan vien: ");
        em.setName(sc.nextLine().trim());
        System.out.print("Tuoi nhan vien: ");
        em.setAge(sc.nextLine().trim());
        
        //Tao file
        try(FileWriter file = new FileWriter("worker.txt")){
            file.write("Nhan vien: ");
            file.write(em.getId());
            file.write(em.getName());
            file.write(em.getAge());
            file.close();
        }catch(IOException e){
            System.out.println("Loi ghi file! "+e);
        }
    }
}
