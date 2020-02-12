/*
	NOTE. EACH COSNTRUCTION SHOULD HAVE HER OWN 
	TABLE WITH INITAL STATE, FINAL STATE, ETC. 
*/

#include <string.h>
#include <stdlib.h>
#include <string.h> 
#include <stdio.h>
#include <time.h> 

struct Graph{
	int nStates;
	char q, f, * graph;
};

struct Thompson{
	char * expression;
	char reference[2];
	/*
		reference
			0: q
			1: f
	*/
};
char * subgraph = "\
	subgraph cluster_%c{\
		style = \"rounded,filled\";\
		color = \"#000000\";\
		fillcolor = \"%4.3f 0.3 0.9\";\
		node [style = \"rounded,filled\", color = \"#000000\", fillcolor = white];\
		%s\
		label = \"cluster %c\";\
	}\
";

char * empty_expression = ".\
	-%c- -> -%c- [ label = \"&epsilon;\" ];\
";

const char * symbol_expression = "\
	-%c- -> -%c- [ label = \"%c\" ];\
";

char * union_expression = "\
	-%c- -> -%c- [ label = \"&epsilon;\" ]; %s  -%c- -> -%c- [ label = \"&epsilon;\" ];\
	-%c- -> -%c- [ label = \"&epsilon;\" ]; %s  -%c- -> -%c- [ label = \"&epsilon;\" ];\
";

char * concat_expression = "\
	%c; %s %s \
\
";

struct Thompson * newThompson(char * exp, char q, char f){
	int len = strlen(exp) + 2;
	struct Thompson * aux = (struct Thompson *) malloc(sizeof(struct Thompson));
	if (!aux)
		perror("No Thompson struct allocation");
	
	aux -> expression = (char *) malloc(len * sizeof(char));
	aux -> reference[0] = q;
	aux -> reference[1] = f;
	
	if (!(aux -> expression))
		perror("No expression string in Thompson struct allocation");
	
	strcpy(aux -> expression, exp);
	return aux;
}

void remove_spaces(char* s) {
    const char* d = s;
    do {
        while ( *d == '\t' | *d == '\n') {
            ++d;
        }
    } while (*s++ = *d++);
}

char * makeSymExp(char var, char q, char f){
	char  * str = (char * ) calloc(29, sizeof(char));
	sprintf(str, "%c -> %c [ label = \"%c;\" ];", q, f, var);
	remove_spaces(str);
	return str;
}

char * makeInnerSymExp(char var, char q, char f, char cluster){
	char * str = (char * ) calloc(strlen(subgraph) + strlen(symbol_expression) + 1, sizeof(char));
	char * aux = (char * ) calloc(strlen(symbol_expression) + 1, sizeof(char));
	sprintf(aux, symbol_expression, q, f, var);
	sprintf(str, subgraph, cluster, (float) (rand() % 1000)/1000, aux, cluster);
	remove_spaces(str);
	return str;
}

struct Thompson * makeInnerUniExp (struct Thompson one, struct Thompson two, char q, char f, char cluster){
	int len = strlen(union_expression) + strlen(one.expression) + strlen(two.expression) + 1;
	char * str = (char * ) calloc(len + strlen(subgraph), sizeof(char));
	char * aux = (char * ) calloc(len, sizeof(char));
	sprintf(aux, union_expression,
		q, 	one.reference[0], one.expression, one.reference[1], f,
		q, 	two.reference[0], two.expression, two.reference[1],	f);
	sprintf(str, subgraph, cluster, (float) (rand() % 1000)/1000, aux, cluster);
	remove_spaces(str);
	return newThompson(str, q, f);
}
//Use @ and ~ to delimit var names
struct Thompson * makeInnerConcat(struct Thompson * one, struct Thompson * two, int cluster){
	int len = strlen(concat_expression) + strlen(one->expression) + strlen(two->expression) + 1;
	char * str = (char * ) calloc(len + strlen(subgraph), sizeof(char));
	char * aux = (char * ) calloc(len, sizeof(char));
	char q2 = two -> reference[0];
	for (size_t i = 0; i < strlen(two -> expression) - 3; i++)
		if (two -> expression[i + 1] == '-' && two -> expression[i] == q2 &&  two -> expression[i + 2] == '-')
			two -> expression[i] = one -> reference[1];
	
	sprintf(aux, concat_expression, q2, one -> expression, two -> expression);
	sprintf(str, subgraph, cluster, (float) (rand() % 1000)/1000, aux, cluster);

	two -> reference[0] = one -> reference[1];
	return newThompson(str, one -> reference[0], two -> reference[1]);
	
}

void addExpression(struct Graph * graph, char * exp){
	int nChar = strlen(exp);
	if(nChar);
}

/*
	Need a table to keep track of which is the final
	and initial node.
*/