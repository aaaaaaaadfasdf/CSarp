using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Data;



 struct Imput{



     public  List<Func<Creatur,float>> imput =[];


     
public  Imput(){

 imput = new List<Func<Creatur,float>>
        {
            DirectionN,
            DirectionO,
            DirectionS,
            DirectionW,
            Time
        };

        
}



    public static float DirectionN(Creatur inc){
    int c=0;
    
       while(true){
        c+=1;
        if(inc.x+c>=Grid.x){
             return c;
        }
        if(!(Grid.Map[inc.x+c,inc.y]==0)){
            return (float)c;
        }
       }



}
   

public static float DirectionO( Creatur inc){
    int c=0;

       while(true){
        c+=1;
        if(inc.y+c>=Grid.y){
             return c;
        }
        if(!(Grid.Map[inc.x,inc.y+c]==0)){
            return (float)c;
        }
       }
}

public static float DirectionS( Creatur inc){
    int c=0;

       while(true){
        c+=1;
           if(inc.x-c<0){
             return c;
        }
        if(!(Grid.Map[inc.x-c,inc.y]==0)){
            return (float)c;
        }
       }
}

public static float DirectionW( Creatur inc){
    int c=0;

       while(true){
        c+=1;
         if(inc.y-c<0){
             return c;
        }
        if(!(Grid.Map[inc.x,inc.y-c]==0)){
            return (float)c;
        }
       }
}


public static float Time( Creatur inc){
    

       
           return (float)1/MainProgram.time;        
       
}









}

