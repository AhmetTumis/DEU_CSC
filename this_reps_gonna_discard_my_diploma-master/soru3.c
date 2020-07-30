#include <stdio.h>

int main(){

    int i,j, rows;
    printf("n degerini giriniz: \n");
    scanf("%d",&rows);
    i=1;

    while(i<=rows){
    j=rows;
    while( j>i){
       printf(" ");
        j--;
    }
    printf("*");
    j=1;
    while(j<(i-1)*2){
       printf(" ");
        j++;
    }
    if(i==1){
      printf("\n");
    }
    else{
      printf("*\n");
    }
     i++;
}

    i=rows-1;
while(i>=1){
    j=rows;
    while(j>i){
       printf(" ");
        j--;
    }
    printf("*");
    j=1;
    while(j<(i-1)*2){
       printf(" ");
        j++;
    }
    if(i==1){
      printf("\n");
    }
    else{
      printf("*\n");
    }
     i--;
    }

    return 0;
    
}