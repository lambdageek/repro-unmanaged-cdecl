#include <stdio.h>

#include "natural.h"


typedef void (*VoidFn)(void);

VoidFn ptrToFunc;


int
natural_capture (void* p)
{
	printf ("was called with %p\n", p);
	ptrToFunc = (VoidFn)p;
	return 0;
}


int
natural_invoke ()
{
	printf ("calling %p\n", ptrToFunc);
	ptrToFunc();
	return 0;
}

const int8_t *
natural_getter ()
{
	return (const int8_t*)"abcdefg";
}
