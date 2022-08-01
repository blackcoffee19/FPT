#include <iostream>
#include <vector>
int choice = 1;
class Book{
	std::string name;
	int quantity;
	int price;
	public:
	void getInfo(){
		int amount = quantity * price;
		std::cout<<name<<"\t \t"<<quantity<<"\t"<<price<<"\t"<<amount<<"\n";
	}
	void setName(std::string newName){
		name = newName;
	}
	void setQuantity(int quan){
		quantity = quan;
	}
	void setPrice(int pri){
		price = pri;
	}
};
void factorial(int *num){
	int fac = *num;
	while(fac > 1){
		fac--;
		(*num) *= fac;
	};
}
int main(){
	while(choice !=3){
		std::cout << "**********************************"<< std::endl;
		std::cout << "C++ Program Language"<< std::endl;
		std::cout << "\t1. Question 02."<<std::endl;
		std::cout << "\t2. Question 03."<<std::endl;
		std::cout << "\t3. Exit."<<std::endl;
		std::cout << "**********************************"<<std::endl;
		std::cout << "Enter Choice (1 - 3):";
		std::cin >> choice;
		if(choice == 1){
			int a;
			int x = 1;
			std::cout<< "Enter an integer: ";
			std::cin>>a;
			int b = a;
			factorial(&a);
			std::cout<< "Factorial: "<<b<<"! = "<<a<<std::endl;
			std::cout<<"\n"<<std::endl;
		}else if(choice == 2){
			std::cout<< "How many books would you like to manage: ";
			int num_book;
			std::cin>>num_book;
			while(num_book > 5 || num_book <= 0){
				std::cout<<"The number is invalid! Press any key to continue"<<std::endl;
				std::cout<<"\nHow many books would you like to manage: ";
				std::cin>>num_book;
			};
			std::vector<Book> arr_book;
			for(int i = 0; i< num_book;i++){
				int no = i+1;
				Book book;
				std::cout<<"Enter book "<<no <<" name:";
				std::string name;
				std::cin>> name;
				book.setName(name);
				std::cout<<"Enter quantity: ";
				int quan;
				std::cin>> quan;
				book.setQuantity(quan);
				std::cout<< "Enter Unit price: ";
				int pri;
				std::cin>> pri;
				book.setPrice(pri);
				arr_book.push_back(book);
				std::cout<<"\n"<<std::endl;
			};
			std::cout<<"\nBook List Information: "<<std::endl;
			std::cout<<"No\tName\t\tQuantity Price Amount"<<std::endl;
			std::cout<<"__|________________|_________|_______|____"<<std::endl;
			for(int i = 0; i < arr_book.size();i++){
				int no2 = i+1;
				std::cout<<no2<<"\t";
				arr_book[i].getInfo();
			};
			std::cout<<"\n"<<std::endl;
		};
		if(choice == 3)
		std::cout<<"Goodbye!!"<<std::endl;
	}
}
