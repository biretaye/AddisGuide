package google.com.combo4.stations;

import google.com.combo4.route.Dec;

/**
 * Created by Nets-Hp on 6/10/2016.
 */
public class Tarif {
    public String get_taxi_price(String distance){
        String price="";
        String npr=distance.substring(0,distance.length()-2);
        double dist = Double.parseDouble(npr);
        if (dist>0 && dist <=4) {
            price= "1.40 ብር";
        }else if(dist>4 && dist <=8){
            price= "2.60 ብር";
        }
        else if(dist>8 && dist <=12){
            price= "3.70 ብር";
        }
        else if(dist>12 && dist <=16){
            price= "5.50 ብር";
        }
        else{
            price= "10 ብር";
        }
        return price;
    }
    public String get_bus_price(String distance){
        String price="";
        String npr=distance.substring(0,distance.length()-2);
        double dist = Double.parseDouble(npr);
        if (dist>0 && dist <=4) {
            price= "1 ብር";
        }else if(dist>4 && dist <=8){
            price= "2 ብር";
        }
        else if(dist>8 && dist <=12){
            price= "3 ብር";
        }
        else if(dist>12 && dist <=16){
            price= "5 ብር";
        }
        else{
            price= "7 ብር";
        }
        return price;
    }
    public String get_train_price(String distance){
        String price="";
        String npr=distance.substring(0,distance.length()-2);
        double dist = Double.parseDouble(npr);
        if (dist>0 && dist <=4) {
            price= "2 ብር";
        }else if(dist>4 && dist <=8){
            price= "4 ብር";
        }
        else{
            price= "6 ብር";
        }
        return price;
    }
}
