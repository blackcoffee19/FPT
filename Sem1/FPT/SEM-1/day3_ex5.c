#include <stdio.h>

int main() {
	char ch;
	printf("\nEnter a lower cased alphabet (a-z): ");
	scanf("%xc",&ch);
	if(ch < 'a' || ch > 'z'){
		printf("\nCharacter not a lower cased alphabet\n");
	} else {
		switch(ch){
			case 'a':
			case 'e':
			case 'u':
			case 'i':
			case 'o':
				printf("Character is a vowel\n");
				break;
			case 'z':
				printf("Last Alphabet <z> was entered\n");
				break;
			default:
				printf("Character is consonant\n");
				break;

		}
	}

}
