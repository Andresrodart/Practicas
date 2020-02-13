#include <ctype.h>
#include <stdlib.h>
#include "thompson.h"

struct Thompson * readReGex(char * regex, int len){
    char x = regex[len++];
    if (isalpha(x))
        return makeLieteral(x);
    else if(x = '.')
        return makeConcatenation(regex, len);
}

struct Thompson * makeNode(int n){
    struct Thompson * res = (struct Thompson *) malloc(sizeof(struct Thompson));
    res->n = n;
    res->id = NULL;
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

struct Thompson * makeConcatenation(char * regex, int len){
    struct Thompson * res, * aux;
    res = readReGex(regex, --len);
    res = aux;
    while (aux != NULL) aux = aux->nodes[0];
    aux->final = False;
    aux->nodes = readReGex(regex, --len);
    return res;
}

void giveId(struct Thompson * q, int * serial){
    q->id = (*serial)++;
    for (int i = 0; i < q->n; i++)
        giveId(q->nodes[i], (*serial)++);
}

char * makeString(struct Thompson * q, char * output){
    int len = strlen(output) + strlen(transition) + strlen(epsilon) + 3;
    return "NULL";
}