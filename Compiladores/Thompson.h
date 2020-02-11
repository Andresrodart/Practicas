/*
	Syntax:
		<: initial state
		>: final state
		!: char for label
		#: inner expression
		$ -> >;: final state from inner expression

	NOTE. EACH COSNTRUCTION SHOULD HAVE HER OWN 
	TABLE WITH INITAL STATE, FINAL STATE, ETC. 
*/

#include <string.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h> 

const char * symbol_expression = "\n\
	subgraph cluster_%d{ \n\
		style = filled; \n\
		color = \"%4.3f 1 0.7\"; \n\
		node [style = filled, color = white]; \n\
		%d -> %d [ label = \"%c;\" ]; \n\
		label = \"cluster %d\"; \n\
	}\
";
char * empty_expression = ".\
	< -> > [ label = \"&epsilon;\" ];\
";

void remove_spaces(char* s) {
    const char* d = s;
    do {
        while ( *d == '\t') {
            ++d;
        }
    } while (*s++ = *d++);
}

char * makeSymExp(char var, int q, int f){
	char  * str = (char * ) calloc(29, sizeof(char));
	sprintf(str, "%d -> %d [ label = \"%c;\" ];", q, f, var);
	//remove_spaces(str);
	return str;
}

char * makeInnerSymExp(char var, int q, int f, int cluster){
	char * str = (char * ) calloc(145, sizeof(char));
	sprintf(str, symbol_expression, cluster, (float) (rand() % 1000)/1000, q, f, var, cluster);
	//remove_spaces(str);
	return str;
}

char * makeUniExp ();

char * union_expression[] = {
	"< -> # [ label = \"&epsilon;\" ]; $ -> > [ label = \"&epsilon;\" ];",
	"< -> # [ label = \"&epsilon;\" ]; $ -> > [ label = \"&epsilon;\" ];"
};
/*
	y: most be a contruction of a transition between f from x and q from y 
		fx -> qy
*/
char * concatenation_expression = ".\
	# -> > [ label = \"&epsilon;\" ];\
";

struct Graph{
	int nStates;
	char q, f, *graph;
};

struct Thompson{
	char * expression;
	char * * reference;
};

void addExpression(struct Graph * graph, char * exp){
	int nChar = strlen(exp);
	if(nChar);
};

/*
	Need a table to keep track of which is the final
	and initial node.
*/