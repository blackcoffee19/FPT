
package Thread;

public class Loader extends Thread {

    @Override
    public void run(){
        try{
        for(int j  = 0; j<6; j++){
            System.out.println(this.getName()+" Loading..."+j);
            if(j == 2){
                Thread.sleep(1000);
            }
        }
        }catch(InterruptedException e){
            System.out.println("Sleep");
        }
    }
    
}
