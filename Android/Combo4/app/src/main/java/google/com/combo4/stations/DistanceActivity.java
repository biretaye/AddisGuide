package google.com.combo4.stations;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.Timer;

import android.location.Location;
import android.os.Handler;

import com.google.android.gms.maps.model.LatLng;

public class DistanceActivity {

	final int driver_mode = 0;
	final int walker_mode = 1;
	int moder = 0;

	Timer timer = new Timer();
	final Handler handler = new Handler();
	Location location1;
	ArrayList<Float> dts = new ArrayList<Float>();
	ArrayList<Float> ordered = new ArrayList<Float>();
	ArrayList<LatLng> waypoints_ordered= new ArrayList<LatLng>();;
	
	public ArrayList<Float> getDistance(LatLng origin, ArrayList<LatLng> dest) {

		for (int i = 0; i < dest.size(); i++) {
			float[] results = new float[dest.size()];
			Location.distanceBetween(origin.latitude, origin.longitude,
					dest.get(i).latitude, dest.get(i).longitude, results);

			dts.add(results[0]);
		}
		
		return dts;

	}

	public ArrayList<Float> dist_ord(LatLng origin, ArrayList<LatLng> dest) {

		for (int i = 0; i < dest.size(); i++) {
			float[] results = new float[dest.size()];
			Location.distanceBetween(origin.latitude, origin.longitude,
					dest.get(i).latitude, dest.get(i).longitude, results);

			dts.add(results[0]);
			Collections.sort(dts);
		}
		
		return dts;

	}
	public float dist_between(LatLng origin, LatLng dest) {
		float[] results = new float[1];
		Location.distanceBetween(origin.latitude, origin.longitude,
				dest.latitude, dest.longitude, results);
		return results[0];

	}
	public ArrayList<Float> dist_lister(LatLng origin, ArrayList<LatLng> dests) {
		float[] results = new float[1];
		for(int i=0;i<dests.size();i++){
			Location.distanceBetween(origin.latitude, origin.longitude,
					dests.get(0).latitude, dests.get(0).longitude, results);
			ordered.add(results[0]);
		}
		
		
		return ordered;

	}

	public int dist_calc(ArrayList<Float> in) {

		Float min = in.get(0);
		for (Float x : in) {
			min = min < x ? min : x;
		}
		// Distance.index_nearest = Distance.distances.indexOf(min);
		return in.indexOf(min);
	}
	public ArrayList<LatLng> get_ordered_array(LatLng origin, ArrayList<LatLng> dest) {

		for (int i = 0; i < dest.size(); i++) {
			float[] results = new float[dest.size()];
			Location.distanceBetween(origin.latitude, origin.longitude,
					dest.get(i).latitude, dest.get(i).longitude, results);

			dts.add(results[0]);
		}

		Float min = dts.get(0);
		for (Float x : dts) {
			min = min < x ? min : x;
		}
		// Distance.index_nearest = Distance.distances.indexOf(min);
		int index= dts.indexOf(min);
		for(int x=0;x<dest.size();x++){
			waypoints_ordered.add(dest.get(index));
			dts.set(index,1000000f);

		}
		return  waypoints_ordered;

	}
	public LatLng get_nearest_station(LatLng origin, ArrayList<LatLng> dest) {

		for (int i = 0; i < dest.size(); i++) {
			float[] results = new float[dest.size()];
			Location.distanceBetween(origin.latitude, origin.longitude,
					dest.get(i).latitude, dest.get(i).longitude, results);

			dts.add(results[0]);
		}

		Float min = dts.get(0);
		for (Float x : dts) {
			min = min < x ? min : x;
		}
		// Distance.index_nearest = Distance.distances.indexOf(min);
		int index= dts.indexOf(min);

		return  dest.get(index);

	}

}