
#include <inttypes.h>
#include <string.h>
#include <stdlib.h>
#include <string.h> 
#include <stdio.h>
#include <time.h> 
#include <math.h>
/*
	NOTE. EACH COSNTRUCTION SHOULD HAVE HER OWN 
	TABLE WITH INITAL STATE, FINAL STATE, ETC. 
*/
struct Graph{
	int nStates;
	char q, f, * graph;
};

struct Thompson{
	char * expression;
	int reference[2];
	/*
		reference
			0: q
			1: f
	*/
};

int True = 1, False = 0;

char * subgraph = "\
	subgraph cluster_%d{\
		style = \"rounded,filled\";\
		color = \"#000000\";\
		fillcolor = \"%4.3f 0.3 0.9\";\
		node [style = \"rounded,filled\", color = \"#000000\", fillcolor = white];\
		%s\
		label = \"cluster %d\";\
	}\
";

char * empty_expression = ".\
	@%d ~ -> @%d ~ [ label = \"&epsilon;\" ];\
";

const char * symbol_expression = "\
	@%d ~ -> @%d ~ [ label = \"%c\" ];\
";

char * union_expression = "\
	@%d ~ -> @%d ~ [ label = \"&epsilon;\" ]; %s  @%d ~ -> @%d ~ [ label = \"&epsilon;\" ];\
	@%d ~ -> @%d ~ [ label = \"&epsilon;\" ]; %s  @%d ~ -> @%d ~ [ label = \"&epsilon;\" ];\
";

char * concat_expression = "\
	@%d ~; %s %s \
\
";

struct Thompson * newThompson(char * exp, int q, int f){
	int len = strlen(exp) * 2;
	//printf("%s \n \n %d \n", exp, len);
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

struct Thompson * copyThompson(struct Thompson * Thm){
	struct Thompson * aux = (struct Thompson *) malloc(sizeof(struct Thompson));
	int len = strlen(Thm -> expression) + 2;
	
	if (!aux)
		perror("No Thompson struct allocation");
	
	aux -> expression = (char *) malloc(len * sizeof(char));
	aux -> reference[0] = Thm -> reference[0];
	aux -> reference[1] = Thm -> reference[1];
	
	if (!(aux -> expression))
		perror("No expression string in Thompson struct allocation");

	strcpy(aux -> expression, Thm -> expression);
	return aux;
}

void clean(char* s) {
    const char* d = s;
    do {
        while ( *d == '@' | *d == '~') {
            ++d;
        }
    } while (*s++ = *d++);
}

void remove_spaces(char* s) {
    const char* d = s;
    do {
        while ( *d == '\t' | *d == '\n') {
            ++d;
        }
    } while (*s++ = *d++);
}

unsigned long long compare(char * s, int i, char * c, char delimiter){
	s = s + i + 1;
	do{
		if (*s != *c)
			return False;
	}while ((*(++s) != delimiter && *(++c) != delimiter));
	return (unsigned long long int) s;
}

int changeValue(struct Thompson * one, int i, int serial, int * max){
	char * s = one -> expression;
	int j = i, k = 0, x;
	while (*(s + j) != '~')	j++;
	char * aux = (char * ) calloc(j - i + 10, sizeof(char));
	char * tmp = (char * ) calloc(strlen(s) * 2, sizeof(char));
	j = i + 1;
	do {
		aux[k++] = *(s + j);
		j++;
	}while (*(s + j) != '~');
	j = i + 3;
	*(s + i + 1) = '%';
	*(s + i + 2) = 's';
	
	while(*(s + j) != '~'){
		*(s + j) = ' ';
		j++;
	}
	
	x = serial + strtoumax(aux, NULL, 10);
	*max = (*max > x)? *max : x;
	sprintf(aux, "%d ", x);
	sprintf(tmp, s, aux);
	(*one).expression = tmp;
	for (i; *(s + i) != '~'; i++);
	return i + 1;
}

int changeValueCluster(struct Thompson * one, int i, int * maxCluster){
	char * s = one -> expression;
	int j = i, k = 0, x;
	while (*(s + j) != '{')	j++;
	char * aux = (char * ) calloc(j - i, sizeof(char));
	char * tmp = (char * ) calloc(strlen(s) * 2, sizeof(char));
	j = i + 9; //As c = i and _ = i + 7
	do {
		aux[k++] = *(s + j);
		j++;
	}while (*(s + j) != '{');

	*(s + i + 8) = '%';
	*(s + i + 9) = 's';
	
	x = *maxCluster + strtoumax(aux, NULL, 10);
	*maxCluster ++;
	sprintf(aux, "_%d", x);
	sprintf(tmp, s, aux);
	(*one).expression = tmp;
	for (i; *(s + i) != '{'; i++);
	return i + 1;
}

char * makeSymExp(char var, int q, int f){
	char  * str = (char * ) calloc(29, sizeof(char));
	sprintf(str, "@%d ~ -> @%d ~ [ label = \"%c;\" ];", q, f, var);
	remove_spaces(str);
	return str;
}

char * makeInnerSymExp(char var, int q, int f, int cluster){
	char * str = (char * ) calloc(strlen(subgraph) + strlen(symbol_expression) + 1, sizeof(char));
	char * aux = (char * ) calloc(strlen(symbol_expression) + 1, sizeof(char));
	sprintf(aux, symbol_expression, q, f, var);
	sprintf(str, subgraph, cluster, (float) (rand() % 1000)/1000, aux, cluster);
	remove_spaces(str);
	return str;
}

struct Thompson * makeInnerUniExp (struct Thompson one, struct Thompson two, int q, int f, int cluster){
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

//Use @ and ~ to delimit var names R y L son el mismo apuntador si mando el amisma estructura
struct Thompson * makeInnerConcat(struct Thompson R, struct Thompson L, int cluster, int serial){
	struct Thompson * one = copyThompson(&R), * two = copyThompson(&L);
	printf("-> %s \n \n \n", one -> expression);
	int len = strlen(concat_expression) + strlen(one->expression) + 2 * strlen(two->expression) + 10;
	int Exp2Len = strlen(two -> expression), max = 0, maxCluster = cluster;
	char * f1  = (char * ) calloc(log10(one -> reference[1] + 1) + 2, sizeof(char));
	char * q2  = (char * ) calloc(log10(two -> reference[0] + 1) + 2, sizeof(char));
	char * aux = (char * ) calloc(len * 2, sizeof(char));
	char * str = (char * ) calloc(len + strlen(subgraph), sizeof(char));
	sprintf(f1, "%d ~", one -> reference[1]);
	sprintf(q2, "%d ~", two -> reference[0]);
	for (int i = 0; i < Exp2Len; i++)
		if (two -> expression[i] == '@'){
			if(compare(two -> expression, i, q2, '~')){
				for (int j = 0; f1[j] != '~'; j++)
					two -> expression[++i] = f1[j];
			}else{
				i = changeValue(two , i, serial, &max);
			}
		}else if (compare(two -> expression, i, "cluster", 'r')){
				i = changeValueCluster(two , i, &maxCluster);
		}
	
	printf("-> %s \n \n \n", aux);
	sprintf(aux, concat_expression, one -> reference[1], one -> expression, two -> expression);
	sprintf(str, subgraph, cluster, (float) (rand() % 1000)/1000, aux, cluster);
	remove_spaces(str);
	two -> reference[0] = one -> reference[1];
	return newThompson(str, one -> reference[0], max);
}

void addExpression(struct Graph * graph, char * exp){
	int nChar = strlen(exp);
	if(nChar);
}

/*
	Need a table to keep track of which is the final
	and initial node.
*/