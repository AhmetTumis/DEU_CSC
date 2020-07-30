#include <stdio.h>

int main(){

    int a,b,c,d,e,deger,z;

    printf("deger gir:");
    scanf("%d", &deger);

    d = (deger-1)/2;
    c=0;
    e=deger;
    for(a=0; a<d; a++){

        for(z=0; z<c; z++){
            printf(" ");
        }
        for(b=0; b<e; b++){
            printf("*");
        }

        c++;
        e--;
        printf("\n");
    }
    d = (deger-1)/2+1;
    c= d;
    e= d;

    for(a=0; a<d; a++){

        for(z=0; z<c-1; z++){
            printf(" ");
        }
        for(b=0; b<e; b++){
            printf("*");
        }

        c--;
        e++;
        printf("\n");
    }

}