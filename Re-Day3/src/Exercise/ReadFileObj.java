
package Exercise;

import java.io.FileInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;

public class ReadFileObj {
    public static void main(String[] args){
        try(FileInputStream filepath = new FileInputStream("nhanvien.bin")){
            ObjectInputStream obj = new ObjectInputStream(filepath);
            while((Employee em =(Employee) obj.readObject()) != -1){
                System.out.println("Employee: "+em);
            }
        }catch(IOException e){
                System.out.println("Error "+e);
        }
    }
}
