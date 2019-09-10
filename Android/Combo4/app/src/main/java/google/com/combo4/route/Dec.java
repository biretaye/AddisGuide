package google.com.combo4.route;

import java.util.ArrayList;

import com.google.android.gms.maps.model.LatLng;

import google.com.combo4.Entities.HouseModel;
import google.com.combo4.Entities.StationLocationModel;
import google.com.combo4.Entities.TrafficSignLocationModel;

public class Dec {
	static public String distance;
	static public String duration;
	static public double my_lat=13.0685875;
	static public double my_long=80.2582827;
	static public ArrayList<LatLng> stations=new ArrayList<LatLng>();
	static public ArrayList<LatLng> waypoints=new ArrayList<LatLng>();
	static public ArrayList<LatLng> waypoints2=new ArrayList<LatLng>();
	//static public double my_lat;
	//static public double my_long;
	//static public double item_lat;
	//static public double item_long;
	static public double item_lat=13.064704;
	static public double item_long=80.266145;
	static public ArrayList<String> html_instructions=new ArrayList<String>();
	static public double last_lat;
	static public double last_long;
	static public ArrayList<String> maneuver=new ArrayList<String>();
	static public ArrayList<String> dis=new ArrayList<String>();
	static public ArrayList<String> dur=new ArrayList<String>();
	static public ArrayList<Double> starting_lat=new ArrayList<Double>();
	static public ArrayList<Double> starting_long=new ArrayList<Double>();
	static public ArrayList<Double> ending_lat=new ArrayList<Double>();
	static public ArrayList<Double> ending_long=new ArrayList<Double>();
	static public ArrayList<LatLng> route_points= new ArrayList<LatLng>();
	static public ArrayList<StationLocationModel> mystations= new ArrayList<StationLocationModel>();
	static public ArrayList<StationLocationModel> taxi_stations= new ArrayList<StationLocationModel>();
	static public ArrayList<StationLocationModel> bus_stations= new ArrayList<StationLocationModel>();
	static public ArrayList<StationLocationModel> train_stations= new ArrayList<StationLocationModel>();
	static public ArrayList<StationLocationModel> myTrainstations= new ArrayList<StationLocationModel>();
	static public ArrayList<HouseModel> houses = new ArrayList<HouseModel>();
	static public ArrayList<TrafficSignLocationModel> trafficSgins = new ArrayList<TrafficSignLocationModel>();
	static public ArrayList<LatLng> taxi_waypoints=new ArrayList<LatLng>();
	static public ArrayList<LatLng> bus_waypoints=new ArrayList<LatLng>();
	static public ArrayList<LatLng> train_waypoints=new ArrayList<LatLng>();
	static public ArrayList<LatLng> search_results=new ArrayList<LatLng>();
	static public String category_msg="";
	static public String route_color_msg="";
	static public String nearest_decider="";


}
