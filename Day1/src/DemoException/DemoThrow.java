
package DemoException;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;

public class DemoThrow {
    public static void findFile() throws FileNotFoundException{
        File newFile = new File("text.txt");
        FileInputStream stream = new FileInputStream(newFile);
    }
    public static void main(String[] args) {
        try{
            findFile();
        }catch(IOException e){
            System.out.println(e);
        }
    }
}
