#include <stdio.h>

int main(){

    int a, b, deger, negDeger;

    printf("n degerini gir: ");
    scanf("%d", &deger);

    negDeger = deger-1;

    for(a=0; a<deger; a++){
        for(b=0; b<deger; b++){

            if(b==a || b==negDeger){
                printf("*");
            }
            
            else{
                printf(" ");
            }
        }
        negDeger--;
        printf("\n");
    }


}