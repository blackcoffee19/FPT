#include <stdio.h>
#include <string.h>
int main(){
	int n;
	printf("Số chuỗi bạn muốn nhập: ");
	scanf("%d",&n);
	char arr_str[n][40], str[40];
	getchar();
	for(int i = 0; i<n;i++){
		printf("Enter any string %d: ",i+1);
		gets(arr_str[i]);
	};
	for(int i = 0; i<n-1;i++){
		for(int j = i+1; j<n;j++){
			if(strcmp(arr_str[i],arr_str[j])<0){
				strcpy(str,arr_str[i]);
				strcpy(arr_str[i],arr_str[j]);
				strcpy(arr_str[j],str);
			}
		}
	};
	for(int i = 0; i<n;i++){
		printf("String %d: %s\n",i+1,arr_str[i]);
	};
	return 0;
}
