#include <stdio.h>

int main(){

    int i, j, n;

    printf("deger :");
    scanf("%d", &n);

    int bosluk = (n-1)/2;
    int tur =1;

    for(i=0; i<n; i++){
        
        for(j=0; j<bosluk; j++){
            printf("-");
        }
        for(j=0; j < tur; j++){
            printf("*");
            
        }
        for(j=0; j<bosluk; j++){
            printf("-");
        }
        printf("\n");
        bosluk--;
        tur+=2;
        
        if(tur > n-2 ){
            break;
        }
    }

    bosluk = 0;
    tur = n;

    for(i=n; i>0; i--){

        for(j=0; j<bosluk; j++){
            printf("-");
        }
        for(j=0; j < tur; j++){
            printf("*");
            
        }
        for(j=0; j<bosluk; j++){
            printf("-");
        }
        printf("\n");
        bosluk++;
        tur-=2;
    
        if(bosluk > (n-1)/2){
            break;
        }

    }



}