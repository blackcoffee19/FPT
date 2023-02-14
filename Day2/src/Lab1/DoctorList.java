
package Lab1;
import java.util.*;
public class DoctorList {
    HashMap<String, Doctor> drList;

    public DoctorList() {
        drList = new HashMap<>();
    }
    public void add(){
        Doctor dr = new Doctor();
        dr.input();
        boolean check = true;
        if(!drList.isEmpty()){
        for (String key : drList.keySet()) {
            if(key.equals(dr.id)){
                System.out.println("Same ID!");
                dr.setId();
                break;
            }
        }
        }
        drList.put(dr.id, dr);
    }
    public void remove(String drID){
        boolean check = true;
        for (Map.Entry<String, Doctor> entry : drList.entrySet()) {
            String key = entry.getKey();
            Doctor value = entry.getValue();
            if(key == drID){
                drList.remove(drID);
                System.out.println("Remove Successfull!");
                check = false;
            }
        }
        if(check){
        System.out.println("Not found "+drID);}
    }
    public void display(){
        System.out.println("List Doctor Level 2: ");
        drList.forEach((key, value)->{
            
            if(value.level.equals("Level 2")){
            System.out.println(value);    
            }
        });
        
    }
    public void display(String drName){
        
        drList.forEach((key, value)->{
            if(value.name == drName){
                System.out.println("Found Dr: ");
                System.out.println(value);
            }
        });
   
    }
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Scanner sc3 = new Scanner(System.in);
        DoctorList lis = new DoctorList();
        boolean exst = false;
        int choose = 0;
        do{
            try{
            System.out.print("Menu: \n1. Add new Doctor\n2. Remove Doctor by id\n3. Display Doctor Level 2\n4. Display Doctor by Name\n5. Exist\n>>>");
            choose = Integer.parseInt(sc.nextLine().trim());
            }catch(Exception e){
                System.out.println("Error:" +e);
                System.out.println("Just enter number\nEnter again!>> ");
                choose = Integer.parseInt(sc.nextLine().trim());
            }
            switch(choose){
                case 1: 
                    lis.add();
                    break;
                case 2 : 
                    System.out.print("Enter Doctor id to remove: ");
                    String drID = sc3.nextLine().trim();
                    lis.remove(drID);
                    break;
                case 3: 
                   lis.display();
                   break;
                case 4:
                    System.out.print("Enter Doctor name to display: ");
                    String name = sc3.nextLine().trim();
                    lis.display(name);
                    break;
                case 5:
                    exst = true;
                    break;
                default:
                    System.out.println("There are no "+choose+" in menu\n");
                    break;
            }
            
        }while(!exst);
    }
}
