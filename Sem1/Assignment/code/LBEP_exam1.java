import java.util.*;

public class LBEP_exam1 {
	public static void main(String[] args) {
		System.out.println("************************************");
		System.out.println("Java Program language");
		System.out.println("\t1. Question 02.");
		System.out.println("\t2. Question 03.");
		System.out.println("\t3. Exit.");
		System.out.println("************************************");
		System.out.println("Enter Choice (1-3): ");
		Scanner input = new Scanner(System.in);
		String str = input.next();
		int num = Integer.parseInt(str);
		if (num == 1) {
			System.out.print("Enter an integer: ");
			String str2 = input.next();
			int num2 = Integer.parseInt(str2);
			int j = num2;
			int i = 1;
			while (num2 > 0) {
				i *= num2;
				num2--;
			}
			;
			System.out.printf("Factorial: %d! = %d\n", j, i);
		} else if (num == 2) {
			System.out.print("How many books would you like to manage: ");
			String str2 = input.next();
			int num_books = Integer.parseInt(str2);
			while (num_books > 5 || num_books <= 0) {
				System.out.println("The number is invalid! Please try again!\n");
				System.out.print("How many books would you like to manage: ");
				String num_books_str = input.next();
				num_books = Integer.parseInt(num_books_str);
			}
			;
			Book[] books = new Book[num_books];
			for (int i = 0; i < num_books; i++) {
				int num_i = i + 1;
				System.out.printf("Enter book %d name: ", num_i);
				String book_name = input.next();
				System.out.print("Enter quantity: ");
				String quan = input.next();
				int quan_num = Integer.parseInt(quan);
				System.out.print("Enter Unit price: ");
				String pri_str = input.next();
				int price = Integer.parseInt(pri_str);
				Book book = new Book(book_name,quan_num,price);
				books[i] = book;
				System.out.println();
			}
			;
			System.out.println("Book List Information: ");
			System.out.println("No\tName\tQuantity Price Amount");
			System.out.println("__|__________|_________|_____|______");
			for (int i = 0; i < num_books; i++) {
				int num_i = i + 1;
				System.out.printf("%d\t",num_i);
				books[i].GetInfo();
			}
			;

		}
	}
}
