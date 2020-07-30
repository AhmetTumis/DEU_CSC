#include <stdio.h>

int main(){
    
    int a,b,c,d,e,deger,z;
    printf("deger gir: ");
    scanf("%d",&deger);

    c = (deger-1)/2;
    e=0;
    d = deger;
    for(b=0; b<c; b++){
        for(a=0; a<e; a++){
            printf(" ");
        }
        for(z=0; z<d; z++){
            printf("*");
        }
        printf("\n");
        d-=2;
        e++;
    }
    e=c;
    d=1;
    for(a=0; a<c+1; a++){
        for(b=0; b<e; b++){
            printf(" ");
        }
        for(z=0; z<d; z++){
            printf("*");
        }
        printf("\n");
        e--;
        d+=2;
    }
}