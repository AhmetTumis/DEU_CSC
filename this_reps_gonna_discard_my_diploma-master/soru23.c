#include <stdio.h>

int main(){

    int a,b,c,deger;

    printf("deger gir:");
    scanf("%d", &deger);

    c=1;
    for(a=0; a<deger; a++){
        
        for(b=0; b<c; b++){
            printf("*");
        }

        c++;
        printf("\n");
    }

}