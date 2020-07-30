#include <stdio.h>
int main(){

    int a,b,c,d,e,deger;
    printf("deger gir:");
    scanf("%d", &deger);

    c = deger;
    d= (deger-1)/2;
    for(a=0; a<d; a++){

        for(b = 0; b<c-1; b++){
            printf(" ");
        }
        c--;
        printf("*\n");
    }

    for(b=0; b<d+1; b++){
        printf("*");
    }

    printf("\n");
    c = d+1;

    for(a=0; a<d;a++){

        for(b=0; b<c; b++){
            printf(" ");
        }

        c++;
        printf("*\n");
        
    }

}