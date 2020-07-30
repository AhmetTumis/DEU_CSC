#include <stdio.h>

int main(){

    int a,deger,i,j;

    printf("deger gir: ");
    scanf("%d", &deger);

    for(i=1; i<=(deger-1)/2+1; i++){

        for(j=0; j<deger; j++){

            printf("*");
        }
        
        printf("\n");

        if(i!=(deger-1)/2+1){

            for(a=0; a<deger; a++){
            
            printf(" ");
            }
            printf("\n");
        }
    }
}



