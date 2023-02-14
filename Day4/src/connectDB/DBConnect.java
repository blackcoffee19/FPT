/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package connectDB;
import java.sql.*;
public class DBConnect {
    static Connection cnn = null;
    public static Connection doConnect (String userName, String password, String database) throws SQLException{
                String dbURL = "jdbc:mysql://localhost:1433/"+database;
        try {
//            Class.forName("com.mysql.cj.jdbc.Driver");
            cnn = DriverManager.getConnection(dbURL,userName, password);    
            System.out.println("Successfull");
        } catch (Exception e) {
            System.out.println("Error"+e);
            e.printStackTrace();
        }
        return cnn;   
    }
}
