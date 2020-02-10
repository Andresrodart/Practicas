#include <stdio.h> 
#include <string.h>
#include "Infix2Posfix.H"

int main(int n, char const *argv[]){
    int len = strlen(argv[1]);
	char * ReGex = (char *) calloc(len, sizeof(char));
	strcpy(ReGex, argv[1]);
	infixToPostfix(ReGex);
    return 0;
}