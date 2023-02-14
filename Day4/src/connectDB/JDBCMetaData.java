package connectDB;

/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

/**
 *
 * @author blackcoffee
 */
import java.sql.*;
public class JDBCMetaData {
    String user = "root";
    String pass = "123456";
    String database = "StrongHOld";
    Connection cnn = null;
    Statement st = null;
    ResultSet rs = null;
    ResultSetMetaData rsMeta = null;
    
    public JDBCMetaData()  {
        try{
        cnn= DBConnect.doConnect(user, pass, database);
        
        }catch(SQLException e){
            e.getErrorCode();
        }
    }
    public void printData(){
        try{
        String sql = "Selecct * from Items";
       st = cnn.createStatement();
       rs = st.executeQuery(sql);
       rsMeta = rs.getMetaData();
        System.out.println("Print meta data details: ");
        for(int i = 1; i<= rsMeta.getColumnCount();i++){
            String name = rsMeta.getColumnName(i);
            
        }
        }catch (SQLException e){
        
        }
    }
}
