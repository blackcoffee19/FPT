#include <iostream>

int main(){
	std::cout << "********************************\n";
	std::cout << "\tC++ Program language\n";
	std::cout << "\t1. Question 02.\n";
	std::cout << "\t2. Question 03.\n";
	std::cout << "\t3. Exit;\n";
	std::cout << "********************************\n";
	std::cout << "\tEnter Choice (1-3):\n";
	int num;
	std::cin >> num;
	if(num == 1){
		std::cout << "Enter the width of Rectangle: ";
		double x,y;
		std::cin >> x;
		std::cout << "Enter the high of Rectangle: ";
		std::cin >> y;
		std::cout << "\tPerimeter of the Rectangle: 2 * ("<<x<<" + "<< y<<") = "<<2*(x+y)<<"\n";
		std::cout << "\tArea of the Rectangle: "<<x<< " * "<<y<<" = "<< x*y<<"\n";
	} else if(num == 2){
		double z;
		std::cout << "Enter the radius of Circle: ";
		std::cin >> z;
		std::cout << "\tPerimeter of the Circle: 2 * " <<z<<" * 3.14 = "<< z*2*3.14<<"\n";
		std::cout<< "\tArea of the Circle: "<<z<<" * "<<z<<" = " << z*z*3.14<<"\n";
	}else {
		std::cout << "Goodbye\n";
	}
	return 0;

}
