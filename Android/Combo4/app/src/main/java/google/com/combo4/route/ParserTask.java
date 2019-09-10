package google.com.combo4.route;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import org.json.JSONObject;

import android.app.PendingIntent;
import android.content.Context;
import android.graphics.Color;
import android.location.Location;
import android.location.LocationManager;
import android.os.AsyncTask;
import android.os.Handler;
import android.widget.Button;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;

import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.model.BitmapDescriptorFactory;
import com.google.android.gms.maps.model.CircleOptions;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.Marker;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.maps.model.PolylineOptions;

public class ParserTask extends
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
	PolylineOptions lineOptions2 = null;

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
			lineOptions2 = new PolylineOptions();
			List<HashMap<String, String>> path = result.get(i);

			for (int j = 0; j < path.size(); j++) {
				HashMap<String, String> point = path.get(j);

				double lat = Double.parseDouble(point.get("lat"));
				double lng = Double.parseDouble(point.get("lng"));
				LatLng position = new LatLng(lat, lng);

				points.add(position);
			}

			 if(Dec.route_color_msg.equals("car")){
				lineOptions.addAll(points);
				lineOptions.width(20);
				lineOptions.color(Color.CYAN);
			}
			else if(Dec.route_color_msg.equals("walk")){
				lineOptions.addAll(points);
				lineOptions.width(20);
				lineOptions.color(Color.MAGENTA);
			}
			else{
				 lineOptions.addAll(points);
				 lineOptions.width(20);
				 lineOptions.color(Color.argb(180, 7, 139, 143));
			 }

				//lineOptions.color(Color.GREEN);
			}

		if (lineOptions!=null){
			map.addPolyline(lineOptions);
		}

		for (int i = 0; i < Dec.starting_lat.size(); i++) {
			LatLng latlng = new LatLng(Dec.starting_lat.get(i),
					Dec.starting_long.get(i));
			MarkerOptions options = new MarkerOptions();

			options.position(latlng);
			options.title(Dec.html_instructions.get(i));
			options.icon(BitmapDescriptorFactory.defaultMarker());
			//map.addMarker(options);
			drawCircle(latlng);
			step_markers.add(options);
			instructions.add(Dec.html_instructions.get(i));
//			Marker marker = mMap.addMarker(mo);
//			marker.showInfoWindow();
			
				
			
		}

	}

	private void drawCircle(LatLng point) {

		CircleOptions circleOptions = new CircleOptions();
		circleOptions.center(point);
		circleOptions.radius(10);
		circleOptions.strokeColor(Color.BLACK);
		circleOptions.fillColor(0x301fff4c);
		circleOptions.strokeWidth(2);
		map.addCircle(circleOptions);
	}

	private void draw_route() {
		lineOptions.addAll(points);
		lineOptions.width(5);
		lineOptions.color(Color.BLUE);
	}

}