#include <stdio.h>

int main(){

    // 7 11 23 27 
    //Ahmet Tuemis 2017280064

    int i, j, n, tersN;

    printf("n sayisini giriniz: \n");
    scanf("%d", &n);
 
    if(n%2==0 || n <7){
        printf("Lutfen yedi veya yediden buyuk cift sayi giriniz.. ");
        return -1;
    }

    tersN = n;
    getchar();
    
    //7 
    getchar();
    printf("\n7 numarali soru\n\n");

    for(i=0; i<n; i++){
        for(j=0; j<n; j++){
            if((j==i && j <= (n-1)/2) || (j ==(tersN-1) && j>=(n-1)/2) || (i>(n-1)/2 && j==(n-1)/2)){
                printf("*");}
            else{
                printf(" ");}}
        tersN--;
        printf("\n");
    }
    
    printf("\n\n");
    tersN = n;

    //11

    getchar();
    printf("\n11 numarali soru\n\n");

    for(i=0; i<n; i++){
        for(j=0; j<n; j++){
            if((j>=i && j<=(n-1)/2) || (j<=(tersN-1) && j>=(n-1)/2)){
                printf("*");}
            else{
                printf(" ");}
        }
        tersN--;
        printf("\n");
    }

    printf("\n\n");

    //23
    getchar();
    printf("\n23 numarali soru\n\n");


    for(i=0; i<n;  i++){
        for(j=0; j<n; j++){

            if(j<=i && j<=(n-1)){
                printf("*");
            }
            else{
                printf(" ");
            }
        }
        printf("\n");
    }
    
    printf("\n\n");
    
    //27
    getchar();
    printf("\n27 numarali soru\n\n");


    int bosluk = (n-1)/2;
    int tur =1;

    for(i=0; i<n; i++){
        
        for(j=0; j<bosluk; j++){
            printf(" ");
        }
        for(j=0; j < tur; j++){
            printf("*");
            
        }
        for(j=0; j<bosluk; j++){
            printf(" ");
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
            printf(" ");
        }
        for(j=0; j < tur; j++){
            printf("*");
            
        }
        for(j=0; j<bosluk; j++){
            printf(" ");
        }
        printf("\n");
        bosluk++;
        tur-=2;
    
        if(bosluk > (n-1)/2){
            break;
        }

    }
    printf("\n");
    return 0;

}