#include <stdio.h>

int main(){
    int a,b,c,d,e,f,g,deger;

    printf("deger gir:");
    scanf("%d",&deger);

    c= (deger-1)/2;
    e =1;
    f=deger-2;

    for(a=0; a<c; a++){

        for(b=0; b<e; b++){
            printf("*");
        }
        for(g=0; g<f; g++){
            printf(" ");
        }
        for(b=0; b<e; b++){
            printf("*");
        }
        e++;
        f-=2;
        printf("\n");
    }

    for(b=0; b<c+1; b++){
        for(a=0; a<deger; a++){
            printf("*");
        }
        printf("\n");
    }
}