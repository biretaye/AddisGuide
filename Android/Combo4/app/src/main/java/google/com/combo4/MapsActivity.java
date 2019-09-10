package google.com.combo4;

import android.Manifest;
import android.app.AlertDialog;
import android.app.PendingIntent;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.PackageManager;
import android.location.Criteria;
import android.location.Location;
import android.location.LocationManager;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Handler;
import android.provider.Settings;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.FragmentActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.BitmapDescriptorFactory;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.Marker;
import com.google.android.gms.maps.model.MarkerOptions;

import java.util.ArrayList;
import java.util.List;

import android.location.LocationListener;

import google.com.combo4.Entities.StationLocationModel;
import google.com.combo4.route.Dec;
import google.com.combo4.route.Directions;

import google.com.combo4.route.DownloadTask;
import google.com.combo4.route.ProximityActivity;
import google.com.combo4.stations.DistanceActivity;
import google.com.combo4.stations.StationsDirections;
import google.com.combo4.stations.StationsDownloadTask;
import google.com.combo4.stations.Tarif;
import google.com.combo4.stations.TrafficAssister;

public class MapsActivity extends FragmentActivity implements OnMapReadyCallback, LocationListener {

    private GoogleMap mMap;
    Button find_btn;
    Button nearest_btn;
    EditText dest_text;
    TextView price_text;
    TextView alert_text;
    Button price_btn;
    private int PROXIMITY_RADIUS = 100000;
    double latitude = 0;
    double longitude = 0;
    private static final String GOOGLE_API_KEY = "AIzaSyDEhbNaa2GJzSIupMuh7l_IguJ8XSHOw8Y";
    ArrayList<LatLng> marker_points;
    ArrayList<LatLng> touched_points;
    ArrayList<LatLng> mMarkerPoints;
    LatLng origin, dest;
    List<StationLocationModel> stations;
    PendingIntent pendingIntent;
    LatLng searched_dest = new LatLng(0, 0);
    ArrayList<LatLng> empty_list;
    String message = "";

    Location location;
    LocationManager locationManager ;
    String provider;
    String house_msg;
    MainActivity ma = new MainActivity();
    ArrayList<Float> ordered_dist;
    ArrayList<LatLng> ordered_waypoints;
    final Context context = this;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_maps);
        // Obtain the SupportMapFragment and get notified when the map is ready to be used.
        SupportMapFragment mapFragment = (SupportMapFragment) getSupportFragmentManager()
                .findFragmentById(R.id.map);
        mapFragment.getMapAsync(this);
        find_btn = (Button) findViewById(R.id.button);
        nearest_btn = (Button) findViewById(R.id.nearest_btn);
        dest_text = (EditText) findViewById(R.id.dest_text);
        price_btn = (Button) findViewById(R.id.price_btn);
        price_text = (TextView) findViewById(R.id.price_text);
        alert_text = (TextView) findViewById(R.id.alert_text);

        Intent intent = getIntent();
        message = intent.getStringExtra(MainActivity.ExtraMessage);

        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            // TODO: Consider calling
            //    ActivityCompat#requestPermissions
            // here to request the missing permissions, and then overriding
            //   public void onRequestPermissionsResult(int requestCode, String[] permissions,
            //                                          int[] grantResults)
            // to handle the case where the user grants the permission. See the documentation
            // for ActivityCompat#requestPermissions for more details.
            return;
        }

        locationManager = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
        Criteria criteria = new Criteria();
        provider = locationManager.getBestProvider(criteria, true);

        location = locationManager.getLastKnownLocation(provider);
        locationManager.requestLocationUpdates(provider,1000,0,this);


        marker_points = new ArrayList<LatLng>();
        touched_points = new ArrayList<LatLng>();
        mMarkerPoints = new ArrayList<LatLng>();
        empty_list = new ArrayList<LatLng>();
        ordered_dist= new ArrayList<Float>();
        ordered_waypoints= new ArrayList<LatLng>();
        if (location!=null){
            onLocationChanged(location);
        }else if (location ==null){
            Toast.makeText(getApplicationContext(), "ያሉበት ቦታ ስላልታወቀ ፣ ከንደገና ይሞክሩ", Toast.LENGTH_LONG).show();
        }
        find_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Search search = new Search();
                search.get_search_name(dest_text.getText().toString(),latitude,longitude,mMap);

            }
        });
        nearest_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                DistanceActivity da= new DistanceActivity();
                LatLng loc= new LatLng(latitude,longitude);
                if (Dec.search_results!=null){
                    LatLng nearest_service= da.get_nearest_station(loc,Dec.search_results);

                    mMap.moveCamera(CameraUpdateFactory.newLatLng(nearest_service));
                    mMap.animateCamera(CameraUpdateFactory.zoomTo(15));
                    searched_dest=nearest_service;
                }

//
//                if (Dec.route_color_msg.equals("taxi")){
//                    LatLng nearest_station= da.get_nearest_station(loc,Dec.taxi_stations.);
//                }

                //Toast.makeText(getApplicationContext(), String.valueOf(Dec.search_results.size()), Toast.LENGTH_LONG).show();
            }
        });
        nearest_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                DistanceActivity da= new DistanceActivity();
                LatLng loc= new LatLng(latitude,longitude);

                LatLng nearest_service= da.get_nearest_station(loc,Dec.search_results);

                mMap.moveCamera(CameraUpdateFactory.newLatLng(nearest_service));
                mMap.animateCamera(CameraUpdateFactory.zoomTo(15));
                searched_dest=nearest_service;

                //Toast.makeText(getApplicationContext(), String.valueOf(Dec.search_results.size()), Toast.LENGTH_LONG).show();
            }
        });
        price_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Tarif tarif= new Tarif();
                String taxi_price="";
                String bus_price="";
                String train_price="";

                if(Dec.distance!=null){
                    taxi_price= tarif.get_taxi_price(Dec.distance);
                    bus_price=tarif.get_bus_price(Dec.distance);
                    train_price=tarif.get_train_price(Dec.distance);
                    price_text.setText("ርቀት "+Dec.distance+"\n"+" በታክሲ: "+"ዋጋ "+ taxi_price +"\n" +" በባስ: "+"ዋጋ "+ bus_price+ "\n" +" በባቡር: "+"ዋጋ "+ train_price);

                }else{
                    Toast.makeText(getApplicationContext(), "ትንሽ ይጠብቁ", Toast.LENGTH_SHORT).show();

                }


            }
        });
    }

    public boolean float_click(View view) {
        String signal="";
        switch (view.getId()) {

            case R.id.action_a:
                Dec.route_color_msg="taxi";
                draw("driving",Dec.taxi_waypoints);

                break;
            case R.id.action_b:
                draw("driving",Dec.bus_waypoints);
                Dec.route_color_msg="bus";
                break;
            case R.id.action_c:
                draw("driving",Dec.train_waypoints);
                Dec.route_color_msg="train";
                break;
            case R.id.action_d:
                Dec.route_color_msg="car";
                origin = mMarkerPoints.get(0);
                //LatLng or5 = new LatLng(location.getLatitude(), location.getLongitude());
                // dest = touched_points.get(0);
                // String url = directions.getDirectionsUrl(origin, dest);

                // Toast.makeText(getApplicationContext(), String.valueOf(Dec.waypoints.size()), Toast.LENGTH_SHORT).show();

                nullChecker(searched_dest);
                StationsDirections directions5 = new StationsDirections();
                String url5 = directions5.getDirectionsUrl(origin,
                        searched_dest);

                Log.d("DIR URL", url5);
                StationsDownloadTask downloadTask5 = new StationsDownloadTask();
                Object[] toPass5 = new Object[2];
                toPass5[0] = mMap;
                toPass5[1] = url5;
                downloadTask5.execute(toPass5);


                Handler handler5 = new Handler();
                handler5.postDelayed(new Runnable() {
                    @Override
                    public void run() {
                        Directions directions = new Directions();
                        LatLng or = new LatLng(location.getLatitude(), location.getLongitude());
                        Dec.waypoints2.clear();
                        String url = directions.getDirectionsUrl(origin,
                                searched_dest, empty_list,"driving");

                        Log.d("DIR URL", url);

                        DownloadTask downloadTask = new DownloadTask();
                        Object[] toPass = new Object[2];
                        toPass[0] = mMap;
                        toPass[1] = url;
                        downloadTask.execute(toPass);
                        // Toast.makeText(getBaseContext(), String.valueOf(Dec.waypoints2.size()), Toast.LENGTH_LONG).show();
                        voice();
                    }
                }, 8000);
                break;
            case R.id.action_e:
                Dec.route_color_msg="walk";
                origin = mMarkerPoints.get(0);
                //LatLng or5 = new LatLng(location.getLatitude(), location.getLongitude());
                // dest = touched_points.get(0);
                // String url = directions.getDirectionsUrl(origin, dest);

                // Toast.makeText(getApplicationContext(), String.valueOf(Dec.waypoints.size()), Toast.LENGTH_SHORT).show();

                nullChecker(searched_dest);
                StationsDirections directionsw = new StationsDirections();
                String urlw = directionsw.getDirectionsUrl(origin,
                        searched_dest);

                Log.d("DIR URL", urlw);
                StationsDownloadTask downloadTaskw = new StationsDownloadTask();
                Object[] toPassw = new Object[2];
                toPassw[0] = mMap;
                toPassw[1] = urlw;
                downloadTaskw.execute(toPassw);


                Handler handlerw = new Handler();
                handlerw.postDelayed(new Runnable() {
                    @Override
                    public void run() {
                        Directions directions = new Directions();
                        LatLng or = new LatLng(location.getLatitude(), location.getLongitude());
                        Dec.waypoints2.clear();
                        String url = directions.getDirectionsUrl(origin,
                                searched_dest, empty_list,"walk");

                        Log.d("DIR URL", url);

                        DownloadTask downloadTask = new DownloadTask();
                        Object[] toPass = new Object[2];
                        toPass[0] = mMap;
                        toPass[1] = url;
                        downloadTask.execute(toPass);
                        // Toast.makeText(getBaseContext(), String.valueOf(Dec.waypoints2.size()), Toast.LENGTH_LONG).show();
                        //voice();
                    }
                }, 8000);
                break;
            default:
                return false;
        }
        return true;
    }
    /**
     * Manipulates the map once available.
     * This callback is triggered when the map is ready to be used.
     * This is where we can add markers or lines, add listeners or move the camera. In this case,
     * we just add a marker near Sydney, Australia.
     * If Google Play services is not installed on the device, the user will be prompted to install
     * it inside the SupportMapFragment. This method will only be triggered once the user has
     * installed Google Play services and returned to the app.
     */
    @Override
    public void onMapReady(GoogleMap googleMap) {

        mMap = googleMap;
        LatLng addis = new LatLng(9.0116,38.7577);
        mMap.moveCamera(CameraUpdateFactory.newLatLng(addis));
        mMap.animateCamera(CameraUpdateFactory.zoomTo(12));

        final Intent intent2 = new Intent(this,MainActivity.class);
        if(!isNetworkAvailable()) {
            LayoutInflater li = LayoutInflater.from(context);


            View promptView = li.inflate(R.layout.prompts2, null);

            AlertDialog.Builder alert = new AlertDialog.Builder(context);
            alert.setView(promptView);
            alert.setCancelable(true)

                    .setPositiveButton("Go to Settings", new DialogInterface.OnClickListener() {

                        @Override
                        public void onClick(DialogInterface dialog, int which) {

                            Intent intent = new Intent(Settings.ACTION_DATA_ROAMING_SETTINGS);
                            startActivity(intent);
                        }
                    }
                    ).setOnCancelListener(new DialogInterface.OnCancelListener() {
                                              @Override
                                              public void onCancel(DialogInterface dialog) {
                                                  startActivity(intent2);
                                              }
            });
            AlertDialog ad = alert.create();
            ad.show();
        }

        String provider_check = Settings.Secure.getString(getContentResolver(),
                Settings.Secure.LOCATION_PROVIDERS_ALLOWED);
        final Intent intent = new Intent(this,MainActivity.class);

        if (!provider_check.equals("")) {

            //Toast.makeText(getBaseContext(), "GPS enabled", Toast.LENGTH_SHORT).show();
            // Toast.makeText(getBaseContext(), "PLEASE WAIT", Toast.LENGTH_SHORT).show();
        } else {

            LayoutInflater li = LayoutInflater.from(context);
            View promptView = li.inflate(R.layout.prompts, null);
            AlertDialog.Builder alert = new AlertDialog.Builder(context);
            alert.setView(promptView);
            alert.setCancelable(true)
                    .setPositiveButton("Go to Settings", new DialogInterface.OnClickListener() {

                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            Intent intent = new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS);
                            startActivity(intent);
                        }
                    }).setOnCancelListener(new DialogInterface.OnCancelListener() {
                @Override
                public void onCancel(DialogInterface dialog) {
                    startActivity(intent);
                }
            });
            AlertDialog ad = alert.create();
            ad.show();

        }

        if (mMarkerPoints!=null){

        }
        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            // TODO: Consider calling
            //    ActivityCompat#requestPermissions
            // here to request the missing permissions, and then overriding
            //   public void onRequestPermissionsResult(int requestCode, String[] permissions,
            //                                          int[] grantResults)
            // to handle the case where the user grants the permission. See the documentation
            // for ActivityCompat#requestPermissions for more details.
            return;

        }
        mMap.setMyLocationEnabled(true);

        if (message != null && message.equals("bus")) {


            // Add a marker in Sydney and move the camera
            //LatLng sydney = new LatLng(8.9535,38.76347);
            //mMap.addMarker(new MarkerOptions().position(sydney).title("Marker in Sydney"));
            //mMap.moveCamera(CameraUpdateFactory.newLatLng(sydney));
            MarkerOptions mo = new MarkerOptions();
            for (StationLocationModel mod : Dec.bus_stations) {
                mo.position(mod.getLocation());
                mo.title(mod.getStationName());
                mo.icon(BitmapDescriptorFactory
                        .fromResource(R.drawable.taxi_marker));
//                mo.icon(BitmapDescriptorFactory
//                        .defaultMarker(BitmapDescriptorFactory.HUE_GREEN));

                Marker marker = mMap.addMarker(mo);
                marker.showInfoWindow();
            }
        }
        else if(message != null && message.equals("taxi")){
            MarkerOptions mo = new MarkerOptions();
            for (StationLocationModel mod : Dec.taxi_stations) {
                mo.position(mod.getLocation());
                mo.title(mod.getStationName());
                mo.icon(BitmapDescriptorFactory
                        .fromResource(R.drawable.taxi_marker));
//                mo.icon(BitmapDescriptorFactory
//                        .defaultMarker(BitmapDescriptorFactory.HUE_BLUE));
                Marker marker = mMap.addMarker(mo);
                marker.showInfoWindow();
            }
        }
        else if(message != null && message.equals("train")){
            MarkerOptions mo = new MarkerOptions();
            for (StationLocationModel mod : Dec.train_stations) {

                mo.position(mod.getLocation());
                mo.title(mod.getStationName());
                mo.icon(BitmapDescriptorFactory
                        .defaultMarker(BitmapDescriptorFactory.HUE_AZURE));

                Marker marker = mMap.addMarker(mo);
                marker.showInfoWindow();
            }
        }
        else if(message != null && message.equals("house")){
            if (Dec.houses.size()==0){
                Toast.makeText(getApplicationContext(),"no results found, try again",Toast.LENGTH_LONG).show();
            }else {
                Dec.houses.get(0);
                MarkerOptions mo = new MarkerOptions();
                mo.position(Dec.houses.get(0).getLocation());

                mo.icon(BitmapDescriptorFactory
                        .defaultMarker(BitmapDescriptorFactory.HUE_MAGENTA));
                mMap.addMarker(mo);
                mMap.moveCamera(CameraUpdateFactory.newLatLng(Dec.houses.get(0).getLocation()));
                mMap.animateCamera(CameraUpdateFactory.zoomTo(12));
            }

        }else if(message.equals("restaurant") || message.equals("movie_theater")||message.equals("bank")){

            Search search = new Search();
            search.get_search_category(message,latitude,longitude,mMap);
        }

        else {
            Toast.makeText(getBaseContext(), "sfdjhjsdkfhj", Toast.LENGTH_LONG).show();

        }

        mMap.setOnMapClickListener(new GoogleMap.OnMapClickListener() {
            @Override
            public void onMapClick(LatLng point) {
                drawMarker(point);
            }
        });

        mMap.setOnMarkerClickListener(new GoogleMap.OnMarkerClickListener() {
            @Override
            public boolean onMarkerClick(Marker marker) {
                searched_dest = marker.getPosition();

                marker.showInfoWindow();

                mMap.moveCamera(CameraUpdateFactory.newLatLng(searched_dest));

                return true;
            }
        });



     //   Toast.makeText(getApplicationContext(), "recieved", Toast.LENGTH_LONG).show();

//        LatLng zoom = new LatLng(location.getLatitude(),location.getLongitude());
//        mMap.moveCamera(CameraUpdateFactory.newLatLng(zoom));
//        mMap.animateCamera(CameraUpdateFactory.zoomTo(12));

    }

    @Override
    public void onLocationChanged(Location location) {
        latitude = location.getLatitude();
        longitude = location.getLongitude();
        location.getLatitude();
        price_text.setText("Speed: "+  String.format("%f:",location.getSpeed()));
        //String.format("%f:",location.getSpeed());

        TrafficAssister ta= new TrafficAssister();
        boolean leba=false;

        ta.check_speed(location,leba);
        Toast.makeText(getApplicationContext(),String.valueOf(leba),Toast.LENGTH_SHORT).show();
        LatLng point = new LatLng(latitude, longitude);

        drawMarkerO(point);
    }

    @Override
    public void onStatusChanged(String provider, int status, Bundle extras) {

    }

    @Override
    public void onProviderEnabled(String provider) {

    }

    @Override
    public void onProviderDisabled(String provider) {

    }

    private void drawMarker(LatLng point) {
        touched_points.add(point);

        MarkerOptions options = new MarkerOptions();

        options.position(point);
        if (touched_points.size() == 1) {
            options.icon(BitmapDescriptorFactory
                    .defaultMarker(BitmapDescriptorFactory.HUE_GREEN));
        } else if (touched_points.size() == 2) {
            options.icon(BitmapDescriptorFactory
                    .defaultMarker(BitmapDescriptorFactory.HUE_RED));
        }

        mMap.addMarker(options);
    }

    private void drawMarkerO(LatLng point) {

        MarkerOptions options = new MarkerOptions();
        options.position(point);

        options.icon(BitmapDescriptorFactory
                .defaultMarker(BitmapDescriptorFactory.HUE_GREEN));
        if (mMarkerPoints.size() == 0) {
            // map.addMarker(options);
            mMarkerPoints.add(point);
        } else if (mMarkerPoints.size() > 0) {
            mMarkerPoints.set(0, point);
        }

        // map.addMarker(options);
    }

    public void voice() {

        IntentFilter proximityIntent = new IntentFilter(
                "google.com.combo4.PROXIMITY_ALERT");
        registerReceiver(new ProximityActivity(), proximityIntent);
        locationManager = (LocationManager) getSystemService(LOCATION_SERVICE);
        Intent intent = new Intent("google.com.combo4.PROXIMITY_ALERT");

        pendingIntent = PendingIntent.getBroadcast(getApplicationContext(), 0,
                intent, PendingIntent.FLAG_CANCEL_CURRENT);

        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            // TODO: Consider calling
            //    ActivityCompat#requestPermissions
            // here to request the missing permissions, and then overriding
            //   public void onRequestPermissionsResult(int requestCode, String[] permissions,
            //                                          int[] grantResults)
            // to handle the case where the user grants the permission. See the documentation
            // for ActivityCompat#requestPermissions for more details.
            return;
        }
        locationManager.removeProximityAlert(pendingIntent);

        for (int k=0 ;k< Dec.html_instructions.size() ; k++) {
            intent.putExtra("counter", k);
            pendingIntent = PendingIntent.getBroadcast(
                    getApplicationContext(), k, intent,
                    PendingIntent.FLAG_CANCEL_CURRENT);
            locationManager.addProximityAlert(Dec.starting_lat.get(k),
                    Dec.starting_long.get(k), 20, -1, pendingIntent);

        }

    }
    public void draw(final String mode, final ArrayList<LatLng> stations){
        MarkerOptions mo = new MarkerOptions();
        if (location ==null){
            Toast.makeText(getApplicationContext(), "ያሉበት ቦታ እስኪታወቅ ፣ ትንሽ ይጠብቁ", Toast.LENGTH_LONG).show();
        }
        nullChecker(searched_dest);
        origin = mMarkerPoints.get(0);
        LatLng or2 = new LatLng(latitude, longitude);
        // dest = touched_points.get(0);
        // String url = directions.getDirectionsUrl(origin, dest);
        // Toast.makeText(getApplicationContext(), String.valueOf(Dec.waypoints.size()), Toast.LENGTH_SHORT).show();

        StationsDirections directions2 = new StationsDirections();
        String url2 = directions2.getDirectionsUrl(or2,
                searched_dest);

        Log.d("DIR URL", url2);
        StationsDownloadTask downloadTask2 = new StationsDownloadTask();
        Object[] toPass2 = new Object[2];
        toPass2[0] = mMap;
        toPass2[1] = url2;
        downloadTask2.execute(toPass2);


        Handler handler = new Handler();
        handler.postDelayed(new Runnable() {
            @Override
            public void run() {
                DistanceActivity da = new DistanceActivity();
                if(stations.size()>0){
                    ordered_waypoints=da.get_ordered_array(origin,stations);
                    // int min_index=da.get_nearest_station(origin,stations);
                }

                Directions directions = new Directions();
                LatLng or = new LatLng(latitude, longitude);
                String url = directions.getDirectionsUrl(origin,
                        searched_dest, ordered_waypoints,mode);

                Log.d("DIR URL", url);

                DownloadTask downloadTask = new DownloadTask();
                Object[] toPass = new Object[2];
                toPass[0] = mMap;
                toPass[1] = url;
                downloadTask.execute(toPass);
                //Toast.makeText(getBaseContext(),ordered_waypoints.get(0)., Toast.LENGTH_LONG).show();
                //voice();
            }
        }, 8000);


    }
    private boolean isNetworkAvailable() {
        ConnectivityManager connectivityManager
                = (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo activeNetworkInfo = connectivityManager.getActiveNetworkInfo();
        return activeNetworkInfo != null && activeNetworkInfo.isConnected();

    }
    private void nullChecker(LatLng dest){
        if(dest.equals(new LatLng(0,0))){
            Toast.makeText(getApplicationContext(),"መድረሻ ይምረጡ",Toast.LENGTH_SHORT).show();
        }

    }


}
