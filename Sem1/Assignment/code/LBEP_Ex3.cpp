#include <iostream>

int main(){
    double x;
    std::cout << "Enter the radius of Circle: ";
    std::cin >> x;
    std::cout << "\tPerimter of the Circle: 2 * "<< x<<" * 3.14 = "<<x*2*3.14<<"\n";
    std::cout << "\tArea of the Circle: "<<x <<" * "<<x<<" *3.14 = "<<x*x*3.14<<"\n";
    return 0;
}