
package File;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
public class demo2 {
    public static void main(String[] args) throws IOException{
        //Tao file
        FileOutputStream fos = new FileOutputStream("file.txt");
        
        //Tao doi tuong DataOuputStream
        DataOutputStream dos = new DataOutputStream(fos);
        dos.writeInt(100);
        dos.writeDouble(12.3);
        dos.writeUTF("STRING");
        //done DataOutput Stream
        dos.close();
       
        //Tao doi tuong File Input Stream
        FileInputStream fis = new FileInputStream("file.txt");
        //Tao doi tuong
        DataInputStream dis = new DataInputStream(fis);
        int i = dis.readInt();
        double d = dis.readDouble();
        String str = dis.readUTF();
        //in Ket qua:
        System.out.println("Integer : "+i);
        System.out.println("Double : "+d);
        System.out.println("String : "+str);
    }    
}
