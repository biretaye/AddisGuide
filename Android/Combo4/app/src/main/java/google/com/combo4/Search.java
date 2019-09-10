package google.com.combo4;

import android.location.Location;
import android.widget.Toast;

import com.google.android.gms.maps.GoogleMap;

import google.com.combo4.lbs.GooglePlacesReadTask;

/**
 * Created by Nets-Hp on 6/5/2016.
 */
public class Search {
    private int PROXIMITY_RADIUS = 100000;
    private static final String GOOGLE_API_KEY = "AIzaSyDEhbNaa2GJzSIupMuh7l_IguJ8XSHOw8Y";
    public void get_search_category(String type,Double latitude,Double longitude,GoogleMap map){

        StringBuilder googlePlacesUrl = new StringBuilder(
                "https://maps.googleapis.com/maps/api/place/nearbysearch/json?");
        googlePlacesUrl
                .append("location=" + latitude+ "," + longitude);
        googlePlacesUrl.append("&radius=" + PROXIMITY_RADIUS);
        googlePlacesUrl.append("&type=" + type);
        googlePlacesUrl.append("&sensor=true");
        googlePlacesUrl.append("&key=" + GOOGLE_API_KEY);

        GooglePlacesReadTask googlePlacesReadTask = new GooglePlacesReadTask();
        Object[] toPass = new Object[2];
        toPass[0] = map;
        toPass[1] = googlePlacesUrl.toString();
        googlePlacesReadTask.execute(toPass);

        //Toast.makeText(getApplicationContext(), "found", Toast.LENGTH_LONG).show();
    }
    public void get_search_name(String name,Double latitude,Double longitude,GoogleMap map){

        StringBuilder googlePlacesUrl = new StringBuilder(
                "https://maps.googleapis.com/maps/api/place/nearbysearch/json?");
        googlePlacesUrl
                .append("location=" + latitude+ "," + longitude);
        googlePlacesUrl.append("&radius=" + PROXIMITY_RADIUS);
        googlePlacesUrl.append("&name=" + name);
        googlePlacesUrl.append("&sensor=true");
        googlePlacesUrl.append("&key=" + GOOGLE_API_KEY);

        GooglePlacesReadTask googlePlacesReadTask = new GooglePlacesReadTask();
        Object[] toPass = new Object[2];
        toPass[0] = map;
        toPass[1] = googlePlacesUrl.toString();
        googlePlacesReadTask.execute(toPass);

        //Toast.makeText(getApplicationContext(), "found", Toast.LENGTH_LONG).show();
    }
}
