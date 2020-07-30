#include <stdio.h>

int main(){

    int a,b,c,d,e,f,g,h,deger;

    printf("deger gir: ");
    scanf("%d",&deger);

    c= (deger-1)/2;
    d = (deger-1)/2;
    f = 1;
    for(a=0; a<c; a++){
        for(b=0; b<d; b++){
            printf("*");
        }
        for(e=0; e<f; e++){
            printf(" ");
        }
        for(g=0; g<d; g++){
            printf("*");
        }

        d--;
        f+=2;
        printf("\n");
    }

    f = 0;
    d = deger;

    for(a=0; a<c+1; a++){

        for(b=0; b<f; b++){
            printf("*");
        }
        for(e=0; e<d; e++){
            printf(" ");
        }
        for(g=0; g<f; g++){
            printf("*");
        }

        f++;
        d-=2;
        printf("\n");
    }

}