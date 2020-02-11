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
			> (ab)* = (a-b)*
			> ab*	= a.b*
	
*/

#include <stdio.h> 
#include <string.h>
#include "Infix2Posfix.H"
#include "Thompson.h"

int main(int n, char const *argv[]){
	srand(time(0)); 
    int len = strlen(argv[1]);
	char * ReGex = (char *) calloc(len, sizeof(char));
	strcpy(ReGex, argv[1]);
	infixToPostfix(ReGex);
	printf(makeInnerSymExp(ReGex[0], 0, 1, 0));
    return 0;
}