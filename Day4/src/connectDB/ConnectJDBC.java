package connectDB;

import java.sql.*;
import java.util.Scanner;
public class ConnectJDBC {
    static ConnectDBnew connect = new ConnectDBnew();
    static Connection cn = null;
    static Statement stm = null;
    static ResultSet rs = null;
    static Scanner sc; 
    static PreparedStatement prepareState = null;
    public static void listDB(){
        String query = "Select * from tbStudent";
            try {
                cn = connect.getConnectDB();
                stm = cn.createStatement();
                rs = stm.executeQuery(query);
                System.out.println("\n\tList Student in database:");
                while(rs.next()){
                    System.out.println("\nStudent ID:"+rs.getString(1)+"\nStudent Name: "+rs.getString(2)+"\n Date of birth: "+rs.getString(3));          
                }
            } catch (Exception e) {
                System.out.println("Error"+e);
            }
    }
    public static void editDB() {
        String query = "update tbStudent set st_name = ? where st_id=?";
        System.out.print("Enter Id: ");
        String id = sc.nextLine().trim();
        System.out.print("Enter new Name: ");
        String name = sc.nextLine().trim();
        try{
            cn = connect.getConnectDB();
            prepareState = cn.prepareStatement(query);
            prepareState.setString(1, name);            
            prepareState.setString(2, id);
            prepareState.execute();
            System.out.println("Update Successfull");
        }catch(Exception e){
            System.out.println("error: "+e);
        }finally{
            try {
                cn.close();
                prepareState.close();
            } catch (Exception e) {
                System.out.println("Error: "+e);
            }
        }
    }
    public static void insertDB (){
        String query  = "Insert into tbStudent (st_id, st_name, dob) values(?,?,?)";
        System.out.print("Enter Student ID: ");
        String id = sc.nextLine().trim();
        System.out.print("Enter Student Name: ");
        String name = sc.nextLine().trim();
        System.out.print("Enter Student DOB: ");
        String dob= sc.nextLine().trim();
        try{
            cn= connect.getConnectDB();
            prepareState = cn.prepareStatement(query);
            prepareState.setString(1, id);            
            prepareState.setString(2, name);
            prepareState.setDate(3, java.sql.Date.valueOf(dob));
            
            prepareState.execute();
            System.out.println("Inset Successfully!");
        }catch(Exception e ){
            System.out.println("Error: "+e);
        }finally{
            try{
                cn.close();
                prepareState.close();
                
            }catch(Exception e){
                System.out.println("Error: "+e);
            }
        }
        
    }
    public static void deleteSt( ){
        String query = "Delete from tbStudent where st_id = ?";
        System.out.println("Enter Id student: ");
        String id = sc.nextLine().trim();
        try{
            cn = connect.getConnectDB();
            prepareState = cn.prepareStatement(query);
            prepareState.setString(1, id);
            prepareState.execute();
            System.out.println("Delete Successfully");
        }catch(Exception e){
            System.out.println("Error: "+e);
        } finally{
            try {
                cn.close();
                prepareState.close();
            } catch (Exception e) {
                System.out.println("Error: "+e);
            }
        }
    }
    public static void searchStu (){
        String query = "Select * from tbStudent where st_id = ?";
        System.out.println("Enter Student id: ");
        String name = sc.nextLine().trim();
        try {
            cn = connect.getConnectDB();
            prepareState = cn.prepareStatement(query);
            prepareState.setString(1, name);
            rs = prepareState.executeQuery();
            while(rs.next()){
                System.out.println("\nId Student: "+rs.getString(1)+"\nName Student:"+rs.getString(2)+"\nDOB: "+rs.getString(3));
            }
        } catch (Exception e) {
            System.out.println("Error: "+e);
        }finally{
            try {
                cn.close();
                prepareState.close();
            } catch (Exception e) {
                System.out.println("Error: "+e);
            }
        }
        
    }
    public static void main(String[] args) {
        sc = new Scanner(System.in);
        int choice = 0;
        do{
            System.out.print("\nInput your option: \n1. List DB\n2. Edit DB\n3. Insert DB\n4. Delete DB\n5. Search DB\n6. Exit\nInput your option: ");
            try{
                choice = Integer.parseInt(sc.nextLine().trim());
            }catch(Exception e){System.out.println("Error: "+e);}
            switch(choice){
                case 1:
                    listDB();
                break;
                case 2:
                    editDB();
                break;
                case 3:
                    insertDB();
                break;
                case 4:
                    deleteSt();
                break;
                case 5:
                    searchStu();
                break;
                case 6:
                System.out.println("\n\tExit!");
                break;
                default:
                System.out.println("\nWrong option! try again ");
                break;
            }
        }while(choice !=6);
    }
}
