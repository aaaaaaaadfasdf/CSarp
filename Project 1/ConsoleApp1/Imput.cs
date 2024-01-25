using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Data;



struct Input{



    
int DirectionN( int x, int y){
    int c=0;

       while(true){
        c+=1;
        if(x+c>=Grid.x){
             return c;
        }
        if(!(Grid.Map[x+c,y]==0)){
            return c;
        }
       }



}
   

int DirectionO( int x, int y){
    int c=0;

       while(true){
        c+=1;
        if(y+c>=Grid.y){
             return c;
        }
        if(!(Grid.Map[x,y+c]==0)){
            return c;
        }
       }
}

int DirectionS( int x, int y){
    int c=0;

       while(true){
        c+=1;
           if(x-c<0){
             return c;
        }
        if(!(Grid.Map[x-c,y]==0)){
            return c;
        }
       }
}

int DirectionW( int x, int y){
    int c=0;

       while(true){
        c+=1;
         if(y-c<0){
             return c;
        }
        if(!(Grid.Map[x,y-c]==0)){
            return c;
        }
       }
}}