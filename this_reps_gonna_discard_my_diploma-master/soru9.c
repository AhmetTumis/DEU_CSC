#include <stdio.h>

int main(){

    int a,b,c,d,e,f,g,h,deger;

    printf("deger gir: ");
    scanf("%d",&deger);

    h = (deger-1)/2;
    for(a=0; a<h; a++){

        for(b=0; b<h; b++){
            printf(" ");
        }

        printf("*");

        for(c=0; c<h; c++){
            printf(" ");
        }

        printf("\n");
    }

    for(a=0; a<deger; a++){

        printf("*");
    }
    printf("\n");

        for(a=0; a<h; a++){

        for(b=0; b<h; b++){
            printf(" ");
        }

        printf("*");

        for(c=0; c<h; c++){
            printf(" ");
        }

        printf("\n");
    }


}