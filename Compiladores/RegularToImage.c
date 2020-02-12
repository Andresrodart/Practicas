#include <stdio.h> 
#include <string.h>
#include "Infix2Posfix.H"
#include "Thompson.h"
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

int main(int n, char const *argv[]){
	srand(time(0)); 
    int len = strlen(argv[1]);
	char * ReGex = (char *) calloc(len, sizeof(char));
	strcpy(ReGex, argv[1]);
	infixToPostfix(ReGex);
	struct Thompson * T1 = newThompson(makeInnerSymExp(ReGex[0], 0, 1, 0), 0, 1);
	struct Thompson * T2 = newThompson(makeInnerSymExp(ReGex[1], 2, 3, 1), 2, 3);
	struct Thompson * T3 = makeInnerUniExp(*T1, *T2, 4, 5, 2);
	struct Thompson * T4 = makeInnerConcat(*T1, *T1, 3, 6 - 1);
	clean(T4 -> expression);
	printf(T4 -> expression);
    return 0;
}