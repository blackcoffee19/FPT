
package connectDB;

import java.sql.*;

public class TestConnection {
    String username ="sa";
    String pass = "123456";
    String database = "StrongHold";
    public TestConnection() {
    }

    public String getUsername() {
        return username;
    }
    public String getPass() {
        return pass;
    }

    public String getDatabase() {
        return database;
    }
    
    
    public static void main(String[] args) {
        DBConnect conn = new DBConnect();
        TestConnection test = new TestConnection();
        try{
            Connection db = DBConnect.doConnect(test.getUsername(), test.getPass(), test.getDatabase());
        }catch(SQLException e){
            e.printStackTrace();
        }
    }
}
