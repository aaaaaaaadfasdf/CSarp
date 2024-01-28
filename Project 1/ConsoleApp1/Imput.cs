using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Data;



 struct Imput{



     public  List<Func<Creatur,int>> imput =[];


     
public  Imput(){

 imput = new List<Func<Creatur,int>>
        {
            DirectionN,
            DirectionO,
            DirectionS,
            DirectionW
        };

        
}



    public static int DirectionN(Creatur inc){
    int c=0;
    
       while(true){
        c+=1;
        if(inc.x+c>=Grid.x){
             return c;
        }
        if(!(Grid.Map[inc.x+c,inc.y]==0)){
            return c;
        }
       }



}
   

public static int DirectionO( Creatur inc){
    int c=0;

       while(true){
        c+=1;
        if(inc.y+c>=Grid.y){
             return c;
        }
        if(!(Grid.Map[inc.x,inc.y+c]==0)){
            return c;
        }
       }
}

public static int DirectionS( Creatur inc){
    int c=0;

       while(true){
        c+=1;
           if(inc.x-c<0){
             return c;
        }
        if(!(Grid.Map[inc.x-c,inc.y]==0)){
            return c;
        }
       }
}

public static int DirectionW( Creatur inc){
    int c=0;

       while(true){
        c+=1;
         if(inc.y-c<0){
             return c;
        }
        if(!(Grid.Map[inc.x,inc.y-c]==0)){
            return c;
        }
       }
}}

