
package Bai2;

import java.util.Scanner;
import java.util.HashSet;
public class BookCatalog {
    HashSet<Book> bkList;

    public BookCatalog() {
        bkList = new HashSet<>();
    }
    public int numberBook(){
        return bkList.size();
    }
    public void add(){
        Book newBk = new Book();
        newBk.input();
        if(bkList.size()>0){
            for(Book bk : bkList){
                if(bk.getId().equals(newBk.getId())){
                    System.out.println("\tError This book id is duplicate!");
                    newBk.setId();
                    break;
                }
            }
        };
        bkList.add(newBk);
        System.out.println("Add Book to the Book List Successful!\n");
    }
    public void remove(String id){
        if(bkList.size()>0){
            boolean check = true;
            for(Book bk : bkList){
                String bkID = bk.getId();
                if(bkID.equals(id)){
                    bkList.remove(bk);
                    System.out.println("Remove Book "+id+" successful!");
                    check = false;
                    break;
                }
            }
            if(check){
                System.out.println("There are no Book has ID "+id);
            }
        }else{
            System.out.println("There are no Book in the Book List");
        };
    }
    public void display(){
        if(bkList.size()>0){
            System.out.println("Books in List: ");
            for(Book bk : bkList){
                System.out.println(bk);
            }
        }else{
            System.out.println("There are no Book in the Book List");
        };
    }
    public void display(String name){
        if(bkList.size()>0){
            System.out.println("Books of "+name+" in List: ");
            boolean check = true;
            for(Book bk : bkList){
                if(bk.author.equals(name)){
                    System.out.println(bk);
                    check = false;
                }
            }
            if(check){
                System.out.println("\nThere are no books of Author "+name+"\n");
            }
        }else{
            System.out.println("There are no Book in the Book List");
        };
    }
}
