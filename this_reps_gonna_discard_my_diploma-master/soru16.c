#include <stdio.h>
int main(){


    int a,b,c,d,e,deger,z;
    printf("deger gir: ");
    scanf("%d",&deger);

    c = 0;
    d = deger;
    for(a=0; a<deger; a++){
        for(b=0; b<c; b++){
            printf(" ");
        }
        for(z=0; z<d; z++){
            printf("*");
        }
        printf("\n");
        d--;
        c++;
    }


}