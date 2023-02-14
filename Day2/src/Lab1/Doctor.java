/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Lab1;

import java.util.*;
public class Doctor {
    String id, name, level;
    int exp_years;

    public Doctor() {
    }

    public Doctor(String id, String name, String level, int exp_years) {
        this.id = id;
        this.name = name;
        this.level = level;
        this.exp_years = exp_years;
    }

    public void setId() {
        Scanner sc =new Scanner(System.in);
        do{
            try{
                System.out.print("\nInput ID of Doctor: ");
                int x = Integer.parseInt(sc.nextLine().trim());
                if(x >=10 && x <=9999){
                    this.id = "D"+x;
                    break;
                }else if(x>0){
                    this.id = "D000"+x;
                    break;
                }else{
                    System.out.println("Id doctor containt 4 number (0< x< 9999)\nTry Again!");
                }
            }catch(Exception e){
                System.out.println("Error: "+e);
                System.out.println("\tError Just enter the number\n");
            }
        }while(true);
    }
    
    public void input(){
        Scanner sc = new Scanner(System.in);
        do{
            try{
                System.out.print("\nInput ID of Doctor: ");
                int x = Integer.parseInt(sc.nextLine().trim());
                if(x >=10 && x <=9999){
                    this.id = "D"+x;
                    break;
                }else if(x>0){
                    this.id = "D000"+x;
                    break;
                }else{
                    System.out.println("Id doctor containt 4 number (0< x< 9999)\nTry Again!");
                }
            }catch(Exception e){
                System.out.println("Error: "+e);
                System.out.println("\tError Just enter the number\n");
            }
        }while(true);
        do{
            System.out.print("Input Doctor's name: ");
            String na = sc.nextLine().trim();
            if(na.length()>2){
                this.name = na;
                break;
            }else{
                System.out.println("Doctor name has more than 2 characters!\nTry again");
            }
        }while(true);
        do{
            try{
                System.out.print("Input Doctor level: ");
                int le = Integer.parseInt(sc.nextLine().trim());
                if(le<0|| le>3){
                    System.out.println("Doctor level just 1,2 or 3\nTry again!");
                }else{
                    this.level = "Level "+le;
                    break;
                }
            }catch(Exception e){
                System.out.println("Error: "+e);
                System.out.println("\tYou must input number!\n");
                continue;
            }
        }while(true);
        do{
            try{
                System.out.print("Input Doctor experience year: ");
                int y = Integer.parseInt(sc.nextLine().trim());
                if(y >=0 && y<60){
                    this.exp_years = y;
                    break;
                }else{
                    System.out.println("This experience can't accept!\nTry again!");
                }
            }catch(Exception e){
                System.out.println("Error: "+e);
                System.out.println("\tYou must input number!\n");
                continue;
            }
        }while(true);
        System.out.println("\tCreate doctor successfull!");
    }

    @Override
    public String toString() {
        return "Doctor "+this.id+"\nDoctor name: "+this.name+"\nDoctor level: "+this.level+"\nDoctor Experience year: "+this.exp_years+"\n";
    }
    
}
