#include <stdio.h>

int main(){
    
    int a, b, c, deger;

    printf("n degeri gir: ");
    scanf("%d", &deger);

    c = deger;
    for(a=1; a<=deger; a++){
        
        if(a==1 || a == deger){ 
            for(b=0; b<deger;b++){
                printf("*");
            }   
        }
        else
        {
            for(b=1; b<=deger; b++){

                if(b==1 || b >= deger){
                    printf("*");
                }
                else
                {
                    printf(" ");
                }
            }
        }
        
        printf("\n");

    }

}