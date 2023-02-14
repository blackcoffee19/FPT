/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package connectDB;

/**
 *
 * @author blackcoffee
 */
import java.sql.*;
public class JDBCPrepareStatement {
        String user = "root";
    String pass = "123456";
    String database = "StrongHOld";
    Connection cnn = null;
    Statement st = null;
    ResultSet rs = null;
    ResultSetMetaData rsMeta = null;

    public JDBCPrepareStatement() {
                try{
        cnn= DBConnect.doConnect(user, pass, database);
        
        }catch(SQLException e){
                    System.out.println("Error: "+e);
        }
    }
    public void printData(){
        String query = "Select * from Items";
        try{
        st = cnn.prepareStatement(query);
//        st.executeQuery();
        while(rs.next()){
        
        }
        }catch(SQLException e){
            System.out.println("Print Error: "+e);
        }
    }
    public void insert(String code, String name, int price){
        String query = "Insert into Items values (?,?,?)";
        try{
            st = cnn.prepareStatement(query);
            st.setString(1,code);
            st.setString(2,name);
            st.setInt(3,price);
            int count  = st.executeUpdate();
            if(count == 0){
                System.out.println("Nothing to insert!");
            }
            printData();
        }catch(SQLException e){};
    }
    public void update(String code, String name, int price){
        String query = "Update Items Set ItemName=?, Rate = ? where ICode = ?";
        try{
            st.setString(1,name);
            st.setInt(2,price);
            st.setString(3,code);
            int count  = st.executeUpdate();
            if(count == 0){
                System.out.println("Nothing to update!");
            }
            printData();
        }catch(SQLException e){};
    }
    public void delete(String code){
        String query = "Delete from Items where ICode='"+code+"'";
        try{
            st = cnn.createStatement();
            rs = st.executeQuery(query);
        }catch(SQLException e){};
    }
}
