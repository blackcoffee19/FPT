
package Exercise;

import java.io.FileReader;
import java.io.IOException;

public class ReadFromFile {
    public static void main(String[] args) throws IOException {
        try(FileReader file =new FileReader("worker.txt")){
            int line;
            while((line = file.read()) != -1){
                System.out.println((char)line);
            }
        }catch(IOException e){
            System.out.println("Loi doc file");
        }
    }
}
