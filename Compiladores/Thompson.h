#ifndef THOMPSON_h_
#define THOMPSON_h_

/*Bool types declaration*/
int True = 1, False = 0;
/*Epsilon character*/
const char * epsilon = "&epsilon;\0";
/*Basic transition in .dot notation*/
const char * transition = "%d -> %d [ label = \"%s\" ];\0";
/*Struct for each node in a Thompson NFA*/
struct Thompson{
    int id, n, final;
    /*Describe movement to nodes[i] whith char[i]*/
    char * desc;
    /*0: R - 1: L*/
    struct Thompson * * nodes;
};
/*Read the regex, it will read character and determinate
which function execute. Returns a pointer to the q of the
NDA of Thompson.*/
struct Thompson * readReGex(char * regex, int len);
/*Make an empty node of type struct Thompson where n indicates if has 1 or 2 transitions
    int id, n, final;
    char * desc;
    struct Thompson * * nodes;*/
struct Thompson * makeNode(int n);
/*Make a literal tamplate, fill it and return a pointer to q*/
struct Thompson * makeLieteral(char x);
/*Make a concatenation template, fill it and return a pointer to q*/
struct Thompson * makeConcatenation(char * regex, int len);
/*Make string for .dot file*/
char * makeString(struct Thompson * q, char * output);
/*Give id to all nodes recursivly*/
void giveId(struct Thompson * q, int * serial);
#endif // THOMPSON_h_

