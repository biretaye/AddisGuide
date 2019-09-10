package google.com.combo4.stations;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import org.json.JSONObject;

import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.location.Location;
import android.location.LocationManager;
import android.os.AsyncTask;
import android.widget.Button;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;


import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.maps.model.PolylineOptions;

import google.com.combo4.MainActivity;
import google.com.combo4.route.Dec;
import google.com.combo4.route.DirectionsJSONParser;

public class StationsParserTask extends
		AsyncTask<Object, Integer, List<List<HashMap<String, String>>>> {
	double mylat = 0;
	double mylng = 0;

	RadioButton driving;
	RadioButton walking;
	RadioGroup route_toggle;

	final int driver_mode = 0;
	final int walker_mode = 1;
	int moder = 0;

	ListView map_list;
	GoogleMap map;
	ArrayList<LatLng> markerPoints;
	LatLng origin, dest;
	TextView dis_dur, duration;
	Context context;
	ArrayList<LatLng> touched_points;
	Button draw_btn;

	ArrayList<LatLng> waypoints_list;
	ArrayList<MarkerOptions> step_markers = new ArrayList<MarkerOptions>();
	ArrayList<String> instructions = new ArrayList<String>();
	ArrayList<LatLng> mMarkerPoints;

	LocationManager locationManager;
	PendingIntent pendingIntent;
	PendingIntent pendingIntent2;
	int index;
	ArrayList<LatLng> points = null;
	PolylineOptions lineOptions = null;

	@Override
	protected List<List<HashMap<String, String>>> doInBackground(
			Object... inputObj) {

		JSONObject jObject;
		List<List<HashMap<String, String>>> routes = null;
		DirectionsJSONParser parser = new DirectionsJSONParser();

		try {
			map = (GoogleMap) inputObj[0];
			jObject = new JSONObject((String) inputObj[1]);

			routes = parser.parse(jObject);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return routes;
	}

	@Override
	protected void onPostExecute(List<List<HashMap<String, String>>> result) {

		for (int i = 0; i < result.size(); i++) {
			points = new ArrayList<LatLng>();
			lineOptions = new PolylineOptions();

			List<HashMap<String, String>> path = result.get(i);
			for (int j = 0; j < path.size(); j++) {
				HashMap<String, String> point = path.get(j);

				double lat = Double.parseDouble(point.get("lat"));
				double lng = Double.parseDouble(point.get("lng"));
				LatLng position = new LatLng(lat, lng);
				points.add(position);

			}
			//mukera
			for (int st=0; st<Dec.mystations.size();st++){
				for (int pts=0;pts<points.size();pts++){
					float[] results = new float[points.size()];
					Location.distanceBetween(points.get(pts).latitude, points.get(pts).longitude,
							Dec.mystations.get(st).getLocation().latitude, Dec.mystations.get(st).getLocation().longitude, results);

					if (results[0]<50){
						if(!(Dec.waypoints2.contains(Dec.mystations.get(st).getLocation()))){
							Dec.waypoints2.add(Dec.mystations.get(st).getLocation());
						}
						else {
							continue;
						}

					}
				}
				
			}
			//taxis
			for (int st=0; st<Dec.taxi_stations.size();st++){
				for (int pts=0;pts<points.size();pts++){
					float[] results = new float[points.size()];
					Location.distanceBetween(points.get(pts).latitude, points.get(pts).longitude,
							Dec.taxi_stations.get(st).getLocation().latitude, Dec.taxi_stations.get(st).getLocation().longitude, results);

					if (results[0]<50){
						if(!(Dec.taxi_waypoints.contains(Dec.taxi_stations.get(st).getLocation()))){
							Dec.taxi_waypoints.add(Dec.taxi_stations.get(st).getLocation());
						}
						else {
							continue;
						}

					}
				}

			}
			for (int st=0; st<Dec.bus_stations.size();st++){
				for (int pts=0;pts<points.size();pts++){
					float[] results = new float[points.size()];
					Location.distanceBetween(points.get(pts).latitude, points.get(pts).longitude,
							Dec.bus_stations.get(st).getLocation().latitude, Dec.bus_stations.get(st).getLocation().longitude, results);

					if (results[0]<50){
						if(!(Dec.bus_waypoints.contains(Dec.bus_stations.get(st).getLocation()))){
							Dec.bus_waypoints.add(Dec.bus_stations.get(st).getLocation());
						}
						else {
							continue;
						}
					}
				}
			}
			for (int st=0; st<Dec.train_stations.size();st++){
				for (int pts=0;pts<points.size();pts++){
					float[] results = new float[points.size()];
					Location.distanceBetween(points.get(pts).latitude, points.get(pts).longitude,
							Dec.train_stations.get(st).getLocation().latitude, Dec.train_stations.get(st).getLocation().longitude, results);

					if (results[0]<200){
						if(!(Dec.train_waypoints.contains(Dec.train_stations.get(st).getLocation()))){
							Dec.train_waypoints.add(Dec.train_stations.get(st).getLocation());
						}
						else {
							continue;
						}
					}
				}
			}
		}

	}

}