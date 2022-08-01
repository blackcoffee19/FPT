#include<stdio.h>
#include<string.h>

int main() {
   char str1[100];
   char str2[100];
   char str3[200];
   int len;
 
   printf("Input first string: ");
   gets(str1);
 
   printf("Input second string: ");
   gets(str2);
 
   strcpy(str3, str1);
   strcat(str3, str2);
 
   printf("Concat string: %s", str3);
 
   return (0);
}
