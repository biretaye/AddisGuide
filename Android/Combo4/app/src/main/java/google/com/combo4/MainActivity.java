package google.com.combo4;

import android.content.Intent;
import android.media.Image;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.view.View;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.animation.AnimationUtils;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import google.com.combo4.API.ApiEndpoints;
import google.com.combo4.API.JsonParser;
import google.com.combo4.API.RetrofitInitializer;
import google.com.combo4.Entities.HouseModel;
import google.com.combo4.Entities.StationDestinationModel;
import google.com.combo4.Entities.StationLocationModel;
import google.com.combo4.Entities.TrafficSignLocationModel;
import google.com.combo4.route.Dec;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {
    public final static String ExtraMessage="google.com.combo4.MESSAGE";
    EditText st_num, hs_num;
    String house_number="";
    String street_number="";
    List<StationLocationModel> stations;
    List<HouseModel> house;
    List<TrafficSignLocationModel> trafficSgins;
    ImageView img;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        st_num = (EditText)findViewById(R.id.street_text);
        hs_num = (EditText)findViewById(R.id.house_text);

        /********************************************************************************/
        img = (ImageView) findViewById(R.id.nav_button4);
        img.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                img.startAnimation(AnimationUtils.loadAnimation(getApplicationContext(), R.anim.image_click));
            }
        });
        /********************************************************************************/

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "ተረጋጉ ገና አልተሰራም !", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.setDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);
        getStations();
        getTaxiStations();
        getTrainStations();
        getBusStations();

    }

    @Override
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        if (id == R.id.nav_service) {

        } else if (id == R.id.nav_navigate) {

        } else if (id == R.id.nav_rate) {

        } else if (id == R.id.nav_setting) {

        } else if (id == R.id.nav_share) {

        } else if (id == R.id.nav_send) {

        }


        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }
    public boolean find_bus(View view) {
        String signal="";
        switch (view.getId()) {

            case R.id.bus_btn:
                signal="bus";

                break;
            case R.id.taxi_btn:
                signal="taxi";

                break;
            case R.id.train_btn:
                signal="train";

                break;


            default:
                return false;
        }
        view.startAnimation(AnimationUtils.loadAnimation(getApplicationContext(), R.anim.image_click));
        Intent serviceIntent = new Intent(this, MapsActivity.class);
        serviceIntent.putExtra(ExtraMessage, signal);
        startActivity(serviceIntent);



        return true;
    }
    public boolean find_sp(View view) {
        String signal="";
        switch (view.getId()) {

            case R.id.restaurant:
                signal="bank";
                Dec.category_msg=signal;
                break;
            case R.id.gas_stations:
                signal="restaurant";
                Dec.category_msg=signal;
                break;
            case R.id.bar:
                signal="gas_station";
                Dec.category_msg=signal;
                break;
            default:
                return false;
        }
        view.startAnimation(AnimationUtils.loadAnimation(getApplicationContext(), R.anim.image_click));
        Intent serviceIntent = new Intent(this, MapsActivity.class);
        serviceIntent.putExtra(ExtraMessage, signal);
        startActivity(serviceIntent);



        return true;
    }
    public boolean find_house(View view) {
        String signal="";
        switch (view.getId()) {

            case R.id.search_house:
                street_number=st_num.getText().toString();
                house_number=hs_num.getText().toString();
                getHouse(house_number,street_number);
                signal="house";
                break;
            default:
                return false;
        }
        Intent house_intent = new Intent(this, MapsActivity.class);
        house_intent.putExtra(ExtraMessage, signal);
        startActivity(house_intent);



        return true;
    }
    public boolean float_click(View view) {
        String signal="";
        switch (view.getId()) {

            case R.id.action_a:
                signal="godriver";
                break;
            case R.id.action_b:

                signal="gotaxi";
                break;
            case R.id.action_c:

                signal="gotrain";
                break;
            default:
                return false;
        }
        Intent house_intent = new Intent(this, MapsActivity.class);
        house_intent.putExtra(ExtraMessage, signal);
        startActivity(house_intent);



        return true;
    }

    public  List<StationLocationModel> getStations (){
        if (Dec.stations!=null){
            Dec.stations.clear();
        }
        Retrofit retrofit = RetrofitInitializer.intializeRetrofit();
        ApiEndpoints endpoints = retrofit.create(ApiEndpoints.class);

        Call<List<StationLocationModel>> call2 = endpoints.GetStationTypeLocation("Taxi");
        call2.enqueue(new Callback<List<StationLocationModel>>() {
            @Override
            public void onResponse(Call<List<StationLocationModel>> call, Response<List<StationLocationModel>> response) {
                switch (response.code()){
                    case 200:
                        stations = response.body();
                        for (StationLocationModel s: stations){
                            Dec.mystations.add(s);
                        }
                        //Toast.makeText(getBaseContext(),"Sertual",Toast.LENGTH_LONG).show();
                        //textViewStations.setText(name);
                }

            }

            @Override
            public void onFailure(Call<List<StationLocationModel>> call, Throwable t) {
                //Toast.makeText(getBaseContext(),"Retrofit failed",Toast.LENGTH_LONG).show();
            }
        });

        return stations;

    }
    public  List<StationLocationModel> getTaxiStations (){
        if (Dec.stations!=null){
            Dec.stations.clear();
        }
        Retrofit retrofit = RetrofitInitializer.intializeRetrofit();
        ApiEndpoints endpoints = retrofit.create(ApiEndpoints.class);

        Call<List<StationLocationModel>> call2 = endpoints.GetStationTypeLocation("Taxi");
        call2.enqueue(new Callback<List<StationLocationModel>>() {
            @Override
            public void onResponse(Call<List<StationLocationModel>> call, Response<List<StationLocationModel>> response) {
                switch (response.code()){
                    case 200:
                        stations = response.body();
                        for (StationLocationModel s: stations){
                            Dec.taxi_stations.add(s);
                        }
                        //Toast.makeText(getBaseContext(),"Sertual",Toast.LENGTH_LONG).show();
                        //textViewStations.setText(name);
                }

            }

            @Override
            public void onFailure(Call<List<StationLocationModel>> call, Throwable t) {
                //Toast.makeText(getBaseContext(),"Retrofit failed",Toast.LENGTH_LONG).show();
            }
        });

        return stations;

    }
    public  List<StationLocationModel> getBusStations (){
        if (Dec.stations!=null){
            Dec.stations.clear();
        }
        Retrofit retrofit = RetrofitInitializer.intializeRetrofit();
        ApiEndpoints endpoints = retrofit.create(ApiEndpoints.class);

        Call<List<StationLocationModel>> call2 = endpoints.GetStationTypeLocation("Bus");
        call2.enqueue(new Callback<List<StationLocationModel>>() {
            @Override
            public void onResponse(Call<List<StationLocationModel>> call, Response<List<StationLocationModel>> response) {
                switch (response.code()){
                    case 200:
                        stations = response.body();
                        for (StationLocationModel s: stations){
                            Dec.bus_stations.add(s);
                        }
                        //Toast.makeText(getBaseContext(),"Sertual",Toast.LENGTH_LONG).show();
                        //textViewStations.setText(name);
                }

            }

            @Override
            public void onFailure(Call<List<StationLocationModel>> call, Throwable t) {
                //Toast.makeText(getBaseContext(),"Retrofit failed",Toast.LENGTH_LONG).show();
            }
        });

        return stations;

    }
    public  List<StationLocationModel> getTrainStations (){
        if (Dec.stations!=null){
            Dec.stations.clear();
        }
        Retrofit retrofit = RetrofitInitializer.intializeRetrofit();
        ApiEndpoints endpoints = retrofit.create(ApiEndpoints.class);

        Call<List<StationLocationModel>> call2 = endpoints.GetStationTypeLocation("Train");
        call2.enqueue(new Callback<List<StationLocationModel>>() {
            @Override
            public void onResponse(Call<List<StationLocationModel>> call, Response<List<StationLocationModel>> response) {
                switch (response.code()){
                    case 200:
                        stations = response.body();
                        for (StationLocationModel s: stations){
                            Dec.train_stations.add(s);
                        }
                        //Toast.makeText(getBaseContext(),"Sertual",Toast.LENGTH_LONG).show();
                        //textViewStations.setText(name);
                }

            }

            @Override
            public void onFailure(Call<List<StationLocationModel>> call, Throwable t) {
                //Toast.makeText(getBaseContext(),"Retrofit failed",Toast.LENGTH_LONG).show();
            }
        });

        return stations;

    }

    public List<HouseModel> getHouse(String hn,String sn){
        Retrofit retrofit = RetrofitInitializer.intializeRetrofit();
        ApiEndpoints endpoints = retrofit.create(ApiEndpoints.class);

        Call<List<HouseModel>> h =  endpoints.GetHouseUsingHouseNoAndStreet(hn, sn);
        h.enqueue(new Callback<List<HouseModel>>() {
            @Override
            public void onResponse(Call<List<HouseModel>> call, Response<List<HouseModel>> response) {
                switch (response.code()){
                    case 200:
                         house = JsonParser.ParseHouse(response.body());
                        if(house.size()>0) {
                            Dec.houses.add(house.get(0));
                        }
                        else{
                            Toast.makeText(getBaseContext(),"no results found",Toast.LENGTH_LONG).show();
                        }


                }
            }

            @Override
            public void onFailure(Call<List<HouseModel>> call, Throwable t) {

            }
        });

        return  house;

    }


    public void getAllTrafficSigns(){
        Retrofit retrofit = RetrofitInitializer.intializeRetrofit();
        ApiEndpoints endpoints = retrofit.create(ApiEndpoints.class);

        Call<List<TrafficSignLocationModel>> h =  endpoints.GetTrafficSignLocations();
        h.enqueue(new Callback<List<TrafficSignLocationModel>>() {
            @Override
            public void onResponse(Call<List<TrafficSignLocationModel>> call, Response<List<TrafficSignLocationModel>> response) {
                switch (response.code()){
                    case 200:
                        trafficSgins = JsonParser.ParseTrafficSign(response.body());


                        for (TrafficSignLocationModel t: trafficSgins){
                            Dec.trafficSgins.add(t);
                        }
                }
            }

            @Override
            public void onFailure(Call<List<TrafficSignLocationModel>> call, Throwable t) {

            }
        });


    }


}
