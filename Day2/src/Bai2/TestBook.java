
package Bai2;
import java.util.Scanner;
public class TestBook {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Scanner sc2 = new Scanner(System.in);
        BookCatalog bkList = new BookCatalog();
        int choice = 1;
        do{
            try{
            System.out.print("\nBook list has "+bkList.numberBook()+" books :\n1.Add new Book\n2. Remove a book\n3. Display all Books\n4. Display books by author\n5. Exist\n>> ");
            choice = Integer.parseInt(sc.nextLine().trim());
                switch (choice) {
                    case 1:
                        bkList.add();
                        break;
                    case 2:
                        System.out.print("Enter the remove Book id: ");
                        String id = sc2.nextLine().trim();
                        bkList.remove(id);
                        break;
                    case 3:
                        bkList.display();
                        break;
                    case 4: 
                        System.out.print("Enter the name of Author: ");
                        String name = sc2.nextLine().trim();
                        bkList.display(name);
                        break;
                    case 5: 
                        System.out.println("Exit!");
                        break;
                    default:
                        System.out.println("There is no option "+choice+"\nTry again!");
                }
            }catch(Exception e){
                System.out.println("Error: "+e);
                System.out.println("\tPlz Input the number!");
            }
        }while(choice != 5);
    }
}
