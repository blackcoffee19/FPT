#include <iostream>
#include <vector>
#include <cmath>
class Student{
	std::string _name;
	public: std::string _rollno;
	int _mark;
	public:
		Student(std::string name, std::string rollno, int mark)
			:_name(name),_rollno(rollno),_mark(mark) {}
	public:
		void getInfo(){
			std::cout<<"\t"<<_rollno<<"\t"<<_name<<"\t"<<_mark<<"\n";
		}
};
void perform(){
	std::cout<<"***********************************************\n";
	std::cout<<"\t C++ Program Languge\n";
	std::cout<<"\t 1. Question 02.\n";
	std::cout<<"\t 2. Question 03\n";
	std::cout<<"\t 3. Exist\n";
	std::cout<<"***********************************************\n";
	std::cout<<"Enter your choice: ";
}

void armstrong(){
	int num, sum = 0;
	std::vector<int> arr_num;
	std::cout<<"Enter an integer: ";
	std::cin>>num;
	int num2 = num;
	while(num>0){
		arr_num.push_back(num%10);
		num /= 10;
	};
	for(int number : arr_num){
		sum += pow(number,arr_num.size());
	};
	if(num2 == sum){
		std::cout<<num2<<" is an Armstrong number.\n";
	}else{
		std::cout<<num2<<" is not an Armstrong number.\n";
	}
}
void studen(){
	int num1,num2, mark;
	std::string name, rollno;
	std::vector<Student> arr_stu;
	std::cout<<"How many student you want to manage?: ";
	std::cin>>num1;
	while(num1 > 5){
		std::cout<<"Too much!! Try again\n";
		std::cout<<"How many student you want to manage?: ";
		std::cin>>num1;
	};
	for(int i = 1; i <= num1;i++){
		std::cout<<"\nEnter student "<<i<<" name: ";
		std::cin>>name;
		std::cout<<"Enter student "<<i<<" rollno: ";
		std::cin>>rollno;
		std::cout<<"Enter student mark: ";
		std::cin>>mark;
		Student str = Student(name,rollno,mark);
		arr_stu.push_back(str);
	};
	std::cout<<"\nStudent Rollno to Search: ";
	std::cin>>rollno;
	std::cout<<"\tRollno \t Name \t Marks\n";
	std::cout<<"\t________|___________|________\n";
	int count = 0;
	for(Student stu : arr_stu){
		if(stu._rollno == rollno){
			stu.getInfo();
			count++;
		}
	};
	if(count == 0){
		std::cout<<"\nStudent 's Rollno not found\n";
	}
	std::cout<<"\n";
}
int main(){
	int choice = 1;
	while(choice != 3){
		perform();
		std::cin>>choice;
		if(choice == 1){
			armstrong();
		} else if(choice ==2){
			studen();
		} else if(choice == 3){
			std::cout<<"\nGoodbye!!\n";
		} else {
			std::cout<<"\nError ! Wrong number\n";
		}
	};

	return 0;
}
