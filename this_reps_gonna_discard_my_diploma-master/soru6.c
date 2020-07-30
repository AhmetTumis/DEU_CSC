#include <stdio.h>

int main(){
    int a,b,c,d,deger;

    printf("deger giriniz: ");
    scanf("%d", &deger);
    c= (deger-1)/2;
    d = 1;

    for(a=0; a<=c; a++){

        for(b=0; b<d; b++){
        printf("*");
        }

        d++;
        printf("\n");
    }
    
    d = c;

    for(a=0; a<=c; a++){

        for(b=0; b<d; b++){
        printf("*");

        }
        d--;;
        printf("\n");
    }


}