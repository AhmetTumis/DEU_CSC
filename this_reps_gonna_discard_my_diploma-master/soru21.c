#include <stdio.h>

int main(){

    int a, b, c, d, e, deger;

    printf("n degerini gir: ");
    scanf("%d", &deger);

    d = deger-1;

    for(a=0; a<deger; a++){
        for(b=0; b<deger; b++){
            if(b==a || b == d){
                printf(" ");
            }
            else{
                printf("*");
            }
        }
        printf("\n");
        d--;
    }

}