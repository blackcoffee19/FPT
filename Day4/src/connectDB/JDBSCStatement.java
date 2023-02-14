
package connectDB;
import java.sql.*;
public class JDBSCStatement {
    String user = "root";
    String pass = "123456";
    String database = "StrongHOld";
    Connection cnn = null;
    Statement st = null;
    ResultSet rs = null;
    ResultSetMetaData rsMeta = null;

    public JDBSCStatement() {
                try{
        cnn= DBConnect.doConnect(user, pass, database);
        
        }catch(SQLException e){
                    System.out.println("Error: "+e);
        }
    }
    public void printData(){
        String query = "Select * from Items";
        try{
        st = cnn.createStatement();
        rs = st.executeQuery(query);
        while(rs.next()){
            String code = rs.getString("ICode");
            String name = rs.getString("ItemName");
            int price = rs.getInt("Rate");
            System.out.print(code+"\t");
            System.out.print(name+"\t");
            System.out.print(price);
            System.out.println("");
        }
        }catch(SQLException e){
            System.out.println("Print Error: "+e);
        }
    }
    public void insert(String code, String name, int price){
        String query = "Insert into Items values ('"+code+"', '"+name+"', "+price+")";
        try{
            st = cnn.createStatement();
            int count = st.executeUpdate(query);
            if(count == 0){
                System.out.println("Nothing to insert!");
            }
            printData();
        }catch(SQLException e){};
    }
    public void update(String code, String name, int price){
        String query = "Update Items Set ItemName='"+name+"',Rate="+price+" Where ICpde ='"+code+"'";
        try{
            st = cnn.createStatement();
            int count = st.executeUpdate(query);

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
    public static void main(String[] args) {
        JDBSCStatement jbc =new JDBSCStatement();
        jbc.printData();
    }
}
