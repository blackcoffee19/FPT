#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <stdlib.h>
const int LENGTH_NAME=100;

struct Product {
	char code[20];
	char name[LENGTH_NAME];
	int price;
};

void menu();
void inputProduct(Product *p);
void printProduct(Product p);
void swap(Product *p1, Product *p2);
void bubbleSort(Product *list, int n);
void insertionSort(Product *list, int n);
int findProductByName(char *name, Product *list, int n);
void saveToFile(Product *list, int n);
void readFromFile(Product *list, int &n);

int main() {
	menu();
	return 0;
}

void menu() {
	Product list[100];
	int n=0;
	printf("Product Manager.\n");
	int choose;
	int isExit = 0;
	while (1) {
		printf("1. Input Product.\n");
		printf("2. Print Product.\n");
		printf("3. Insertion Sort.\n");
		printf("4. Find Product By Code.\n");
		printf("5. Save to File.\n");
		printf("6. Load from File.\n");
		printf("9. Exit\n");
		scanf("%d", &choose);
		switch(choose) {
			case 1:
				inputProduct(&list[n++]);
				break;
			case 2:
				for (int i = 0; i < n; i++) 
					printProduct(list[i]);
				break;
			case 3:
				insertionSort(list, n);
				break;
			case 4: {				
				char name[LENGTH_NAME];
				printf("Input the name of the product: ");
				fflush(stdin);
				gets(name);
				int pos = findProductByName(name, list, n);
				if (pos >= 0) {
					printf("Found.\n");
					printProduct(list[pos]);
				} else {
					printf("Not exist Product with name: %s\n", name);
				}
				break;
			}
			case 5:
				saveToFile(list, n);
				break;
			case 6:
				readFromFile(list, n);
				break;
			case 9:
				isExit = 1;
				break;
		}
		if (isExit) {
			break;
		}
	}
}

void inputProduct(Product *p) {	
	printf("Input Product\n");

	printf("Product Code: ");
	fflush(stdin);
	scanf("%s", &p->code);
	
	printf("Product Name: ");
	fflush(stdin);
	gets(p->name);
	
	printf("Price: ");
	scanf("%d", &p->price);
}
void printProduct(Product p) {
	printf("\nProduct.\n");
	printf("Product Code: %s\n", p.code);
	printf("Product Name: %s\n", p.name);
	printf("Price: %d\n", p.price);
}

void swap(Product *p1, Product *p2) {
	Product tmp;
	memcpy(&tmp, p1, sizeof(Product));
	memcpy(p1, p2, sizeof(Product));
	memcpy(p2, &tmp, sizeof(Product));
}

void bubbleSort(Product *list, int n) {
	for (int i = 0; i < n; i++)	{
		for (int j = n-1; j>=i; j--) {
			if (strcmp(list[j].code, list[j-1].code) < 0) {
				swap(&list[j], &list[j-1]);
			}
		}
	}
}

void insertionSort(Product *list, int n) {
	int pos;
	Product x;
	for (int i = 1; i < n; i++)	{
		memcpy(&x, &list[i], sizeof(Product));
		pos = i-1;
		while ( pos >= 0 && (strcmp(list[pos].code, x.code) > 0) ) {
			memcpy(&list[pos+1], &list[pos], sizeof(Product));
			pos--;
		}
		memcpy(&list[pos+1], &x, sizeof(Product));
	}
}

int findProductByName(char *name, Product *list, int n) {
	int pos = 0;
	for (; pos < n; pos++) {
		if (!strcmp(name, list[pos].name))
			break;
	}
	if (pos < n)
		return pos;
	else 
		return -1;
}
void saveToFile(Product *list, int n) {
	FILE *f = fopen("d:\\product.txt", "wt");
	if (f == NULL) {
		printf("Error when open file to write\n");
		exit(0);
	}
	char line[200];
	line[0] = 0;	// khoi tao chuoi ban dau la chuoi rong
	for (int i = 0; i < n; i++) {
		Product p = list[i];
		strcat(line, p.code);
		strcat(line, ":");
		strcat(line, p.name);
		strcat(line, ":");
		char sPrice[20];
		sprintf(sPrice, "%d", p.price);
		strcat(line, sPrice);
		fprintf(f, "%s\n", line);
		line [0] = 0;	// xoa dong de chuan bi ghi hang moi
	}
	fclose(f);
}

void readFromFile(Product *list, int &n) {
	FILE *f = fopen("d:\\product.txt", "rt");
	if (f == NULL) {
		printf("Error when open file to read\n");
		exit(0);
	}
	char line[200];
	n = 0;
	while(fgets(line, 200 - 1, f) != NULL) {
		Product p;
		char *tok = strtok(line, ":");
		strcpy(p.code, tok);
		tok = strtok(NULL, ":");
		strcpy(p.name, tok);
		tok = strtok(NULL, ":");
		p.price = atoi(tok);
		list[n++] = p;
	}
	fclose(f);
}
