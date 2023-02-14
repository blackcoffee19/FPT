/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Bai2;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Book {
    String id, title, author, publisher;
    int pages, price;

    public Book() {
    }

    public Book(String id, String title, String authorm, String publisher, int pages, int price) {
        this.id = id;
        this.title = title;
        this.author = authorm;
        this.publisher = publisher;
        this.pages = pages;
        this.price = price;
    }
    public void input(){
        Scanner sc  =new Scanner(System.in);
        String patt = "^B+[0-9]{4}$";
        do{
            System.out.print("\nInput Book id (BXXXX): ");
            String x = sc.nextLine().trim();
            if(Pattern.matches(patt, x)){
                this.id = x;
                break;
            }else{
                System.out.println("Id incorrect! Try again");
            }
        }while(true);
        do{
            System.out.print("Input Book title: ");
            String y = sc.nextLine().trim();
            Pattern pat = Pattern.compile("[a-zA-Z0-9]{2,}");
            Matcher matcher = pat.matcher(y);
            if(matcher.find()){
                this.title = y;
                break;
            }else{
                System.out.println("Book Title more than 2 character!");
            }
        }while(true);
        do{
            System.out.print("Input Book's Author: ");
            String z = sc.nextLine().trim();
            if(!z.isBlank()){
                this.author = z;
                break;
            }else{
                System.out.println("Author cannot be blank!");
            }
        }while(true);
        do{
            System.out.print("Input Book's publisher: ");
            String j = sc.nextLine().trim();
            if(!j.isBlank()){
                this.publisher = j;
                break;
            }else{
                System.out.println("Publisher cannot be blank!");
            }
        }while(true);
        while(true){
            try {
                System.out.print("Input The number page of Book: ");
                int i = Integer.parseInt(sc.nextLine().trim());
                if(i >=5 && i<=2000){
                    this.pages = i;
                break;
                }else{
                    System.out.println("The number must 5<= x <=2000!");
                }
            } catch (Exception e) {
                System.out.println("Error: "+e);
                System.out.println("\tThere is must be the number! Try Again");
            }
        };
        while(true){
            try {
                System.out.print("Input the price of Book: ");
                int m = Integer.parseInt(sc.nextLine().trim());
                if(m >0){
                    this.price = m;
                    break;
                }else{
                    System.out.println("Price must greater than 0!");
                }
            } catch (Exception e) {
                System.out.println("Error: "+e);
                System.out.println("\tPlz enter the price by number!");
            }
        };
    }

    public String getId() {
        return id;
    }

    public void setId() {
        Scanner sc  =new Scanner(System.in);
        String patt = "^B+[0-9]{4}$";
        do{
            System.out.print("\nInput new id (BXXXX): ");
            String x = sc.nextLine().trim();
            if(Pattern.matches(patt, x)){
                this.id = x;
                break;
            }else{
                System.out.println("Id incorrect! Try again");
            }
        }while(true);
    }
    
    @Override
    public String toString() {
        return "\nBook id: "+this.id+"\nBook Title: "+this.title+"\nBook Author: "+this.author+"\nBook pusblishment: "+this.publisher+"\nBook Pages: "+this.pages+"\nBook Price: "+this.price+"\n";
    }
    
}
