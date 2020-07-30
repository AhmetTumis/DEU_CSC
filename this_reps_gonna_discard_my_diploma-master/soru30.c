#include <stdio.h>

int main(){

    int a,b,c,d,e,deger;

    printf("deger gir:");
    scanf("%d", &deger);

    for(a=0; a<deger; a++){

        for(b=0; b<(deger-1)/2; b++){
            printf("*");
            printf(" ");
        }
        printf("*");
        printf("\n");
    }
}