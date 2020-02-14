#include <stdio.h>
#include <ctype.h>
#include <stdlib.h>
#include <string.h>
#include <limits.h>
#include "thompson.h"

struct Thompson * readReGex(char * regex, int * len){
    //We do not check is len inside the regex lenght because the last letter we will read is a Literal and literals never call readReGex again
	char x = regex[--(*len)];
    if (isalpha(x))
        return makeLieteral(charToString(x));
    else if(x == '.')
        return makeConcatenation(regex, len);
    else if (x == '|')
        return makeAlternation(regex, len);
    else if (x == '*')
        return makeKleene(regex, len);
    
}

struct Thompson * makeNode(int n){
    struct Thompson * res = (struct Thompson *) malloc(sizeof(struct Thompson));
    res->n = n;
    res->id = UINT_MAX;
    res->visited = False;
    res->final = (n != 0)? False:True;
    res->desc  = (n != 0)? (char * *) malloc(n * sizeof(char *)):NULL;
    res->nodes = (n != 0)? (struct Thompson * *) malloc(n * sizeof(struct Thompson *)):NULL;
    return res;
}

struct Thompson * makeLieteral(char * x){
    struct Thompson * res = makeNode(1);
	res->desc[0] = x;
    res->nodes[0] = makeNode(0);
    return res;
}

struct Thompson * makeConcatenation(char * regex, int * len){
    struct Thompson * resL, * resR, * aux;
    resR = readReGex(regex, len);
    resL = readReGex(regex, len);
	aux = resL;
    while (aux->nodes != NULL) aux = aux->nodes[0];
    aux->n = resR->n;
    aux->desc = resR->desc;
    aux->final = resR->final;
	aux->nodes = resR->nodes;
    return resL;
}

struct Thompson * makeAlternation(char * regex, int * len){
    struct Thompson * res, * aux, * end;
    end = makeNode(0);
    res = makeNode(2);
    res->desc[0] = epsilonDot; 
    res->desc[1] = epsilonDot; 
    res->nodes[0] = readReGex(regex, len); 
    res->nodes[1] = readReGex(regex, len); 
    for(int i = 0; i < res->n; i++){
        aux = res->nodes[i];
        while (aux->nodes[0]->final != True) aux = aux->nodes[0];
        aux->nodes[0] = makeLieteral(epsilonDot);
        aux->nodes[0]->nodes[0] = end;
    }
    
    return res; 
}

struct Thompson * makeKleene(char * regex, int * len){
    struct Thompson * res, * aux, * end;
    res = makeNode(2);
    res->desc[0] = epsilonDot; 
    res->desc[1] = epsilonDot; 
    res->nodes[0] = readReGex(regex, len); 
    
    end = makeNode(2);
    end->desc[0] = epsilonDot; 
    end->desc[1] = epsilonDot; 
    end->nodes[0] = makeNode(0);

    end->nodes[1] = res->nodes[0]; 
    res->nodes[1] = end->nodes[0];
    return res;
}

void giveId(struct Thompson * q, int * serial){
    if (q->id == UINT_MAX)
        q->id = (int) (*serial)++;
    for (int i = 0; i < q->n; i++)
        giveId(q->nodes[i], serial);
}

int makeString(struct Thompson * q, char * * output){
    if (q->n == 0)
		return 0;

	int len = 2*strlen(*output) + 4*strlen(transitionDot) + 2*strlen(epsilonDot);
	char * aux = (char *) malloc(len * sizeof(char));
	char * tmp = (char *) calloc(len, sizeof(char));
	strcpy(aux, *output);

	if (!aux)
		perror("No spaces for string");
	for (int i = 0; i < q->n; i++){
		sprintf(tmp, transitionDot, q->id, q->nodes[i]->id, q->desc[i]);
		strcat(aux, tmp);
	}
    if(!q->visited){
	    *output = aux;
        q->visited = True;
    }
	for (int i = 0; i < q->n; i++)
		makeString( q->nodes[i], output);
	return 0;
}

char * charToString(char x){
    char * res = (char *) malloc(2 * sizeof(char));
    res[0] = x;
    res[1] = '\0';
    return res;
}

char * getDotNotation(struct Thompson * q, char * Regex){
    int i = 0, finalState;
    struct Thompson * iterator = q;
	char * res = (char *) malloc(2 * strlen(graphDotHeader) * sizeof(char));
	char * aux = (char *) malloc((strlen(res) + 35) * sizeof(char));
    while (!iterator->final) iterator = iterator->nodes[0];
    giveId(q, &i);
	sprintf(res, graphDotHeader, (float) (rand() % 1000)/1000, iterator->id);
	makeString(q, &res);
    sprintf(aux,"\tlabel = \"NFA of Thompson of: %s\";\n", Regex);
	strcat(res, aux);
	strcat(res, graphDotTail);
	return res;
}