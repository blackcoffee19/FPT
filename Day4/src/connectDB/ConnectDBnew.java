/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package connectDB;


import java.sql.*;

/**
 *
 * @author blackcoffee
 */
public class ConnectDBnew {
  Connection cnn = null;
    public Connection getConnectDB(){
        try{
            String dbUrl = "jdbc:sqlserver://localhost:1433;databaseName=Student;";
            String user = "sa";
            String pass ="123456789";
            //Class.forName("com.microsoft.sqlserver.jdbc.SqlServerDriver");
            cnn = DriverManager.getConnection(dbUrl,user, pass);
        }catch(Exception e){
            System.out.println("Error"+e);
        }
        return cnn;
    }
}
