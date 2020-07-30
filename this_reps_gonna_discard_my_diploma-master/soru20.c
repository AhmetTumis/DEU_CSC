#include <stdio.h>

int main(){
    
    int a, b, c, deger, z, ortadaKalan;

    printf("n degeri gir: ");
    scanf("%d", &deger);

    z = (deger-1)/2-1;

    for(a=0; a<z-1; a++){

        if(a==0){
            for(b=0; b<deger; b++){
                printf("*");
            }
            printf("\n");
        }
    }

    for(b=0; b<z-2; b++){
        
        printf("*");
        for(c=0; c<deger-2; c++){
            printf("-");
        }
        printf("*\n");

    }

    for(a=0; a<deger; a++){

        if(a!=1 && a!= deger-2){
            printf("*");
        }
        else{
            printf("-");
        }
    }
    printf("\n");

    for(a=0; a<deger-6; a++){

        for(b=1; b<=deger; b++){
        
            if(b==1 || b==3 || b== deger-2 || b==deger){
                printf("*");
            }
            else{
                printf("-");
            }
            
        }

    printf("\n");

    }

      for(a=0; a<deger; a++){

        if(a!=1 && a!= deger-2){
            printf("*");
        }
        else{
            printf("-");
        }
    }
    printf("\n");

    for(b=0; b<z-2; b++){
        
        printf("*");
        for(c=0; c<deger-2; c++){
            printf("-");
        }
        printf("*\n");

    }

    for(a=0; a<z-1; a++){

        if(a==0){
            for(b=0; b<deger; b++){
                printf("*");
            }
            printf("\n");
        }
    }
}