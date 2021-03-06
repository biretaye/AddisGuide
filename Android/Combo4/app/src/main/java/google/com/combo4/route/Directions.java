package google.com.combo4.route;

import java.util.ArrayList;

import android.app.PendingIntent;
import android.content.Context;
import android.location.LocationManager;
import android.widget.Button;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;

import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;

public class Directions {
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
	ArrayList<LatLng> touched_points = new ArrayList<LatLng>();
	Button draw_btn;

	ArrayList<LatLng> waypoints_list;
	ArrayList<MarkerOptions> step_markers;
	ArrayList<LatLng> mMarkerPoints;

	LocationManager locationManager;
	PendingIntent pendingIntent;
	PendingIntent pendingIntent2;
	int index;

	public String getDirectionsUrl(LatLng origin, LatLng dest,
			ArrayList<LatLng> way,String mode) {
		String str_origin = "origin=" + origin.latitude + ","
				+ origin.longitude;
		String str_dest = "destination=" + dest.latitude + "," + dest.longitude;
		String sensor = "sensor=false";
		String waypoints = "";
		//String alt= "alternatives=true";

		 mode = "mode="+mode;
		/* if (driving.isChecked()) { mode =
		"mode=driving"; moder = 0; } else if (walking.isChecked()) { mode =
		 * "mode=walking"; moder = 1; }
		 */
		for (int i = 0; i < way.size(); i++) {
			LatLng point = (LatLng) way.get(i);
			if (i == 0)
				waypoints = "waypoints=";
			waypoints += point.latitude + "," + point.longitude + "|";
		}
		String parameters = str_origin + "&" + str_dest + "&" + sensor + "&"
				+ waypoints + "&"+ mode;
		String output = "json";
		String url = "https://maps.googleapis.com/maps/api/directions/"
				+ output + "?" + parameters;

		return url;
	}
}
