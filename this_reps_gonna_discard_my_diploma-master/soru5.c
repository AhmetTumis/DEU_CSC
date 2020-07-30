#include <stdio.h>

int main(){

    int a, b, c, deger, d, e;

    printf("deger gir: ");
    scanf("%d",&deger);

    c = (deger-1)/2;
    d = deger-1;
    e =1;
    for(a=0; a<=c; a++){

        for(b = 0; b<d; b++){
            printf(" ");
        }
        for(b = 0; b < e; b++){
            printf("*");
        }
        e++;
        d--;
        printf("\n");
    }

    d = c+1;
    e = c;

    for(a=0; a<c; a++){

        for(b = 0; b<d; b++){
            printf(" ");
        }
        for(b = 0; b < e; b++){
            printf("*");
        }
        e--;
        d++;
        printf("\n");
    }






}