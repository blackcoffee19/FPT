#include <stdio.h>
	/*Multiple line comment:
		1. Nhập 2 sô và tính tổng của chúng
		2. Hiển tổng hai số trên
	*/
	// Single line comment

int main() {
	//Bắt đầu
		//Chuẩn bị
		int A, B, C; //Statement -dòng lệnh khai báo số nguyên 
		//1. Nhập số A, B
		printf("Vui long nhap so thu nhat: ");
		scanf("%d", &A);
		printf("Vui long nhap so thu hai: ");
		scanf("%d", &B);
		//2. C = A + B
		C = A + B; // Toán tử gán (assignment operator) => Trái (ghi vào) = Phải (đọc giá trị ra)
		//3. Hiển thị C
		printf("Tong A va B la: %d\n", C);
	//Kết thúc
		//1. Khai báo
		int n;
		//2. Khởi tạo
		n =10;
		//3. Khai báo và khởi tạo
		float m =10.5;
		//4. Hiển thị 
		printf("Gia tri so nguyen n: %d\n", n);
		printf("Gia tri so thuc %f\n", m);
		printf("Gia tri so thuc m có 2 so le: %.2f\n", m);

	return 0;


}
