#include <stdio.h>

int main(){

    int a,b,c,d,e,deger;
    printf("deger gir:");
    scanf("%d", &deger);

    c =0;
    d = (deger-1)/2;

    for(a=0; a<d; a++){

        for(a=0; a<c; a++){
            printf(" ");
        }
        printf("*");
        printf("\n");
        c++;
    }

    for(a=0; a<d; a++){

        printf(" ");
    }
    for(a=0; a<d+1; a++){
        printf("*");
    }
    printf("\n");
    
    d = (deger-1)/2;
    c = d;

    for(a=0; a<d; a++){
        for(b=0; b<c-1; b++){
            printf(" "); 
        }
        printf("*");
        printf("\n");
        c--;
    }
    
}