
package File;

import java.io.File;


public class demo1 {
    public static void main(String[] args) {
        File file = new File("file.txt");
        try {
            if(file.createNewFile()){
                System.out.println("File created: "+file.getName());
            }else{
                System.out.println("File already exist!");
            }
        } catch (Exception e) {
            System.out.println("Error: "+e);
        }
        
        //Delete file.txt
        if(file.delete()){
            System.out.println("Delete Successful!");
        }else{
            System.out.println("Delete Failue!");
        }
        
        //check if file exists
        if(file.exists()){
            System.out.println("File exist!");
        }else{
            System.out.println("File not exist!");
        }
    }
}
