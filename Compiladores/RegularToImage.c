#include <stdio.h> 
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
			> ab*	= a.b*
	
*/

int main(int n, char const *argv[]){
	srand(time(0)); 
    int len = strlen(argv[1]), i = 0;
	char * ReGex = (char *) calloc(len, sizeof(char));
	char * res;
	
	strcpy(ReGex, argv[1]);
	infixToPostfix(ReGex);
    len = strlen(ReGex);
	struct Thompson * graph = readReGex(ReGex, &len);
	
	strcpy(ReGex, argv[1]);
	res = getDotNotation(graph, ReGex);
	printf(res, "--");
	return 0;
}