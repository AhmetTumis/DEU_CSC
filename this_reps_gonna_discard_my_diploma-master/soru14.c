#include <stdio.h>

int main(){

    int a,b,c,d,e,f,deger,z;
    printf("deger gir:");
    scanf("%d", &deger);

    f = (deger-1)/2;
    d = 1;
    e = deger-2 ;
    for(a=0; a<f; a++){
        
        for(b=0; b<d; b++){
            printf("*");
        }
        for(c=0; c<e; c++){
            printf(" ");
        }
        for(z=0; z<d; z++){
            printf("*");
        }
        printf("\n");
        d++;
        e-=2;
    }

    for(a=0; a<deger; a++){
        printf("*");
    }

    printf("\n");

    e=1;
    d=(deger-1)/2;
    for(a=0; a<f; a++){
        
        for(b=0; b<d; b++){
            printf("*");
        }
        for(c=0; c<e; c++){
            printf(" ");
        }
        for(z=0; z<d; z++){
            printf("*");
        }

        printf("\n");
        e+=2;
        d--;

    }

}