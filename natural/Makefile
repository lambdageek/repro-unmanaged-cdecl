
SOURCES:= \
	natural.c \
	natural.h

CFLAGS+=-Wall -std=c99

.PHONY: all clean

all: libnatural.dylib

clean:
	-rm -f libnatural.dylib

libnatural.dylib: $(SOURCES)
	clang -o $@ -shared $(CFLAGS) $(LDFLAGS) $(filter-out %.h,$(SOURCES))
