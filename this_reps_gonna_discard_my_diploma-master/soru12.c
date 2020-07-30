#include <stdio.h>

int main(){

    int a,b,c,d,e,deger,z,i,k;

    printf("deger gir: ");
    scanf("%d",&deger);

    c = (deger-1)/2;

    for(a=0; a<c; a++){
        for(b=0; b<deger; b++){
            printf(" ");
        }
        printf("\n");
    }

    z = c;
    e = 1;
    for(b=0; b<c+1; b++){
        for(a=0; a<z; a++){
            printf(" ");
        }
        for(i=0; i<e; i++){
            printf("*");
        }
        for(k=0; k<z; k++){
            printf(" ");
        }
        e+=2;
        z--;
        printf("\n");
    }


}