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
	strcpy(ReGex, argv[1]);
	infixToPostfix(ReGex);
    struct Thompson * graph = readReGex(ReGex, &len);
	giveId(graph, &i);
	ReGex = (char *) malloc(2 * strlen(graphDot) * sizeof(char));
	sprintf(ReGex, graphDot, (float) (rand() % 1000)/1000, "%s");
	makeString(graph, &ReGex);
	
	char * res = (char *) malloc((strlen(ReGex) + 35) * sizeof(char));
	sprintf(res, ReGex, "\tlabel = \"NFA of Thompson\";\n");
	printf(res);
	return 0;
}