#include <stdio.h>
//In hoa => in thuong && in thuong => in hoa
int main(){
	printf("Enter the character: ");
	char x;
	scanf("%c",&x);
	if(x < 65 || x > 122 || (x >90 && x < 97)){
		printf("Invalid character! Try again!\n");
	} else if(x >= 65 && x <= 90){
		x += 32;
		printf("Character has lowercase: %c\n",x);
	} else {
		x -= 32;
		printf("Character has uppercase: %c\n",x);
	};
	return 0;
}
