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
        return makeLieteral(x);
    else if(x = '.')
        return makeConcatenation(regex, len);
}

struct Thompson * makeNode(int n){
    struct Thompson * res = (struct Thompson *) malloc(sizeof(struct Thompson));
    res->n = n;
    res->id = UINT_MAX;
    res->final = (n != 0)? False:True;
    res->desc  = (n != 0)? (char *) malloc(n * sizeof(char)):NULL;
    res->nodes = (n != 0)? (struct Thompson * *) malloc(n * sizeof(struct Thompson *)):NULL;
    return res;
}

struct Thompson * makeLieteral(char x){
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

void giveId(struct Thompson * q, int * serial){
    q->id = (int) (*serial)++;
    for (int i = 0; i < q->n; i++)
        giveId(q->nodes[i], serial);
}

int makeString(struct Thompson * q, char * * output){
    if (q->n == 0)
		return 0;

	int len = 2*strlen(*output) + 4*strlen(transitionDot) + 2*strlen(epsilonDot);
	char * aux = (char *) malloc(len * sizeof(char));
	
	if (!aux)
		perror("No spaces for string");

	strcpy(aux, *output);
	for (int i = 0; i < q->n; i++){
		char * tmp = (char *) malloc(len * sizeof(char));
		sprintf(tmp, transitionDot, q->id, q->nodes[i]->id, q->desc[i]);
		strcat(tmp, "\n %s \0");
		sprintf(aux, *output, tmp);
	}
	*output = aux;
	for (int i = 0; i < q->n; i++)
		makeString( q->nodes[i], output);
	return 0;
}