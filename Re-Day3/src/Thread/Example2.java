/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Thread;

/**
 *
 * @author blackcoffee
 */
public class Example2 implements Runnable {
    long minPrime;

    public Example2(long minPrime) {
        this.minPrime = minPrime;
    }
    public void run(){
        for(int i = 0; i<minPrime; i++){
            System.out.println("Thread run");
        }
    }
    public void start(){
        this.run();
    }
}
