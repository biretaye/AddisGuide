package google.com.combo4.stations;

import android.location.Location;
import android.widget.Toast;

import com.google.android.gms.maps.model.LatLng;

import java.util.List;

import google.com.combo4.Entities.TrafficSignLocationModel;
import google.com.combo4.route.Dec;

/**
 * Created by Nets-Hp on 6/10/2016.
 */
public class TrafficAssister {
    double lat=0;
    double lng=0;
    public void check_speed(Location location,boolean leba){
        lat=location.getLatitude();
        lng = location.getLongitude();
        LatLng point = new LatLng(lat,lng);
        List<TrafficSignLocationModel> trafficSgins = Dec.trafficSgins;
        for (TrafficSignLocationModel tsm: trafficSgins){
            if( location.getSpeed()>1 ){
                leba= true;
            }else{
                leba=false;
            }
        }

    }
}
