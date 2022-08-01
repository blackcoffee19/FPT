#include <iostream>

int main(){
    double x,y;
    std::cout << "Enter the width of Rectangle: ";
    std::cin >> x;
    std::cout << "Enter the high of Rectangle: ";
    std::cin >> y;
    double per = (x+y)*2;
    std::cout << "\tPerimeter of the Rectangle: 2 *("<< x <<" + "<< y<<") = "<<per<<"\n";
    std::cout << "\tArea of the Rectangle: "<< x << " * "<<y<<" = "<< x*y<<"\n";
    return 0;
}