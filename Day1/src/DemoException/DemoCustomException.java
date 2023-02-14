
package DemoException;


public class DemoCustomException extends Exception {

    public DemoCustomException() {
        super();
    }
    

    @Override
    public String getMessage() {
        return "This is DemoCustomException";
    }

    
    
}
