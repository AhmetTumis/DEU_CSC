#include <stdio.h>

int main(){

    int a,b,c,d,e,deger;
    printf("deger gir: ");
    scanf("%d",&deger);

    c = (deger-1)/2;
    for(a=0; a<c+1; a++){
        for(b=0; b<c; b++){
            printf(" ");
        }
            printf("*\n");
    }

    d = 1;
    e = c-1;
    for(a=0; a<c; a++){
        
        for(b=0; b<e; b++){
            printf(" ");
        }
        printf("*");

        for(b=0; b<d; b++){
            printf(" ");
        }
        printf("*");
        printf("\n");
        d+=2;
        e--;

    }
    
}