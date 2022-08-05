#include <stdio.h>

int main() {
	printf("The number 555 id various forms:\n");
	printf("Without any modifier: \n");
	printf("[%d]\n",555);

	printf("With- modified: \n");
	printf("[%d]\n",555);

	printf("With digit string 10 as modifier: \n");
	printf("[%10d]\n", 555);
	printf("[%10d]\n",11555);

	printf("With 0 as modified : \n");
	printf("[%0d]\n",555);

	printf("With 0 and digit string 10 as modifiers: \n");
	printf("[%010d]\n",555);
	printf("[%010d]\n", 11555);

	printf("With -, 0 and digit string 10 as modifiers: \n");
	printf("[%-10d]\n",555);
	return 0;

}
