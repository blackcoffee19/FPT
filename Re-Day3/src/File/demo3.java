
package File;

import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

public class demo3 {

    
    public static void main(String[] args) {
        String filepath = "file3.txt";
        //ghi du lieu vao file
        try (FileWriter fileWri = new FileWriter(filepath)){
            fileWri.write("Hello World!");
        } catch (IOException e) {
            System.out.println("Loi ghi file: "+e.getMessage());
        }
        //doc du lieu tu file
        try(FileReader fileRea= new FileReader(filepath)){
            int ch ;
            while((ch = fileRea.read()) != -1){
                System.out.println((char) ch);
            }
        }catch(IOException e){
            System.out.println("Doc file loi: "+e.getMessage());
        }
    }
}
