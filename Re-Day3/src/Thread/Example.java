
package Thread;

public class Example extends Thread{

    @Override
    public void run() {
        if(this.isDaemon()){
            System.out.println("Deamon!");
        }else{
            System.out.println("Not Deamon");
        }
        for(int i = 0; i< 10;i++){            
            System.out.println("Example "+this.getName()+ " : "+i+ " Priority: "+this.getPriority());
            try{
                Thread.sleep(1000);
            }catch(InterruptedException e){
                System.out.println("Thread Interupt");
            }
        }
        System.out.println("Thread exist");
    }
    public static void main(String[] args) throws InterruptedException{
        System.out.println(currentThread().getName()+" Start: ");
        Example ex1 = new Example();
        ex1.setName("T1");
//        Loader lod1 = new Loader();
//        ex1.setDaemon(true);
        
//        lod1.start();

        if(ex1.isAlive()){
        try{
            ex1.join();
            System.out.println("Thread alive: "+ex1.isAlive());
        }catch(InternalError e){
            System.out.println(e);
        }

        }
        ex1.start();    
        
        System.out.println("End!");
//        Example2 ex3 = new Example2(3);
//        ex3.start();

    }   
   
}
