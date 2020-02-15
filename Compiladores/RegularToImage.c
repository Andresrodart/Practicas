#include <stdio.h> 
#include <stdlib.h> 
#include <string.h>
#include <time.h>
#include "Infix2Posfix.H"
#include "thompson.h"
/*
	Autor: Andrés Rodarte López
	Description: Program that recives a ReGex and produces
		a representation of it in .dot notation
	Syntax:
		- ()	are grouping symbols
		- .		is a concatenation operator
		- *		is a Kleene operator
		- +		is a addition operator
		- |		is a union oparator
		E.g.: 
			> (ab)* = (a.b)*
			> ab*	= a.(b*)
	
*/

int main(int n, char const *argv[]){
	int len = strlen(argv[1]), i = 0;
	char * ReGex = (char *) calloc(len, sizeof(char)), * res;
	FILE * out_file = fopen("NFA.dot", "w+"); // write only 
    if (out_file == NULL)  
		perror("Error! Could not open file\n"); 
	srand(time(0)); 
	
	strcpy(ReGex, argv[1]);
	ReGex = addCntSym(ReGex);
	printf(ReGex);
	infixToPostfix(ReGex);
    len = strlen(ReGex);
	
	struct Thompson * graph = readReGex(ReGex, &len);
	strcpy(ReGex, argv[1]);
	
	res = getDotNotation(graph, ReGex);
	int x = fprintf(out_file, res);
	fclose(out_file);
	return 0;
}