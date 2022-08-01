import java.util.*;

public class Book{
	private String name;
	private int quantity;
	private int price;
	public Book(String name, int quan, int price){
		this.name = name;
		this.quantity = quan;
		this.price = price;
	}
	public void GetInfo(){
		int amount = this.quantity * this.price;
		System.out.printf("%s \t\t %d \t %d \t %d\n",this.name,this.quantity, this.price, amount);
	}

}
