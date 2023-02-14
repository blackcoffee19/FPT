
package DemoException;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

public class DemoTryCatchRe {
    public static void main(String[] args) throws FileNotFoundException {
        String line;
           
        try {
             BufferedReader br = new BufferedReader(new FileReader("text.txt"));
            while((line = br.readLine())!=null){
                System.out.println("Line => "+line);
            }
        } catch (IOException e) {
            System.out.println("IOException is try block: "+e.getMessage());
        }
    }
}
