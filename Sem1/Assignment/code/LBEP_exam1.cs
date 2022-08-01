using System;
class Book{
	string name;
	int quantity;
	int price;
	public Book(string name, int quan, int price){
		this.name= name;
		this.quantity = quan;
		this.price = price;
	}
	public void getInfor(){
		int amount = this.quantity * this.price;
		Console.WriteLine("{0} \t\t {1} \t {2} \t {3}",this.name,this.quantity, this.price, amount);
	}
}
class LBEP_exam1
{
    static void Main(string[] args){
        int choice = 1;
        while(choice != 3){
            Console.WriteLine("*********************************");
            Console.WriteLine("C# Program Language");
            Console.WriteLine("\t1. Question 02");
            Console.WriteLine("\t2. Question 03");
            Console.WriteLine("\t3. Exit.");
            Console.WriteLine("*********************************");
            Console.Write("\tEnter Choice (1-3): ");
            choice = Int32.Parse(Console.ReadLine());
            if(choice == 1){
                Console.Write("Enter an integer: ");
                string input = Console.ReadLine();
                int num = Int32.Parse(input);
                int fac = 1;
                for(int i = 1; i <= num; i++){
                    fac *= i;
                };
                Console.WriteLine("Factoria: {0}! = {1}",num, fac);
            } else if(choice == 2){
                Console.Write("How many books would you like to manage: ");
                int num_book = Int32.Parse(Console.ReadLine());
                while(num_book > 5){
                    Console.WriteLine("The number is invalid!");
                    Console.Write("How many books would you like to manage: ");
                };
                Book[] arr_books = new Book[num_book]; 
                for(int i = 0; i< num_book;i++){
                    int no_book = i+1;
                    Console.WriteLine("\nEnter book {0} name: ",no_book);
                    string book_name = Console.ReadLine();
                    Console.Write("Enter quantity: ");
                    int quantity = Int32.Parse(Console.ReadLine());
                    Console.Write("Enter Unit Price: ");
                    int price = Int32.Parse(Console.ReadLine());
                    Book new_book = new Book(book_name,quantity,price);
			arr_books[i] = new_book;
                };
                Console.WriteLine("\nBook List Information: ");
                Console.WriteLine("No\tName\tQuantity Price Amount");
                Console.WriteLine("__|__________|_____|______|______");
                for(int i = 0; i <num_book; i++){
                    int no = i+1;
                    Console.Write("{0}\t",no);
			arr_books[i].getInfor();
                };
            } else {
			Console.WriteLine("Goodbye!\n");
			break;
		}
        }
    }
}
