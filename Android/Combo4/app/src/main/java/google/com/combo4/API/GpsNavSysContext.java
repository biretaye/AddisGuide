package google.com.combo4.API;

import java.util.List;

import google.com.combo4.Entities.DestinationModel;
import google.com.combo4.Entities.HouseModel;
import google.com.combo4.Entities.StationDestinationModel;
import google.com.combo4.Entities.StationLocationModel;
import google.com.combo4.Entities.TrafficSignLocationModel;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;

/**
 * Created by Nets-Hp on 5/20/2016.
 */
public class GpsNavSysContext {

    Retrofit retrofit;
    ApiEndpoints endpoints;

    private List<DestinationModel> destinations = null;

    private List<HouseModel> houses = null;
    private HouseModel particularHouse = null;


    private List<StationDestinationModel> stationDestinations = null;
    private List<StationDestinationModel> stationsToParticilarDestination = null;
    private List<StationDestinationModel> destinationsFromParticularStation = null;


    private List<StationLocationModel> stationLocations = null;


   private List<TrafficSignLocationModel> trafficSignLocations = null;

    public GpsNavSysContext() {
        retrofit = RetrofitInitializer.intializeRetrofit();
        endpoints = retrofit.create(ApiEndpoints.class);
    }



//    public List<DestinationModel> GetDestinations()
//    {
//
//        Call<List<DestinationModel>> call = endpoints.getDestinations();
//
//        call.enqueue(new Callback<List<DestinationModel>>() {
//            @Override
//            public void onResponse(Call<List<DestinationModel>> call, Response<List<DestinationModel>> response) {
//                if (response.code() == 200)
//                    destinations = response.body();
//
//            }
//
//            @Override
//            public void onFailure(Call<List<DestinationModel>> call, Throwable t) {
//
//                t.printStackTrace();
//
//            }
//        });
//        return destinations;
//
//    }

   public List<HouseModel> GetHouses(){
        Call<List<HouseModel>> call = endpoints.GetHouses();

        call.enqueue(new Callback<List<HouseModel>>() {
            @Override
            public void onResponse(Call<List<HouseModel>> call, Response<List<HouseModel>> response) {
                if (response.code() == 200)
                    houses = response.body();


            }

            @Override
            public void onFailure(Call<List<HouseModel>> call, Throwable t) {

                t.printStackTrace();

            }
        });
        return houses;
    }

//
//    public HouseModel GetParticularHouse(String houseNo, String streetName){
//        Call<List<HouseModel>> call = endpoints.GetHouseUsingHouseNoAndStreet(houseNo, streetName);
//
//        call.enqueue(new Callback<HouseModel>() {
//            @Override
//            public void onResponse(Call<HouseModel> call, Response<HouseModel> response) {
//                if (response.code() == 200)
//                    particularHouse = response.body();
//
//
//            }
//
//            @Override
//            public void onFailure(Call<HouseModel> call, Throwable t) {
//
//                t.printStackTrace();
//
//            }
//        });
//        return particularHouse;
//    }

    public List<StationDestinationModel> GetAllStationDestinations(){
        Call<List<StationDestinationModel>> call = endpoints.GetStationDestinations();

        call.enqueue(new Callback<List<StationDestinationModel>>() {
            @Override
            public void onResponse(Call<List<StationDestinationModel>> call, Response<List<StationDestinationModel>> response) {
                if (response.code() == 200)
                    stationDestinations = response.body();


            }

            @Override
            public void onFailure(Call<List<StationDestinationModel>> call, Throwable t) {

                t.printStackTrace();

            }
        });
        return stationDestinations;
    }

    public List<StationDestinationModel> GetStationsFromParticularDestinations(String destinationName){
        Call<List<StationDestinationModel>> call = endpoints.GetStationsFromDestination(destinationName);

        call.enqueue(new Callback<List<StationDestinationModel>>() {
            @Override
            public void onResponse(Call<List<StationDestinationModel>> call, Response<List<StationDestinationModel>> response) {
                if (response.code() == 200)
                    stationsToParticilarDestination = response.body();


            }

            @Override
            public void onFailure(Call<List<StationDestinationModel>> call, Throwable t) {

                t.printStackTrace();

            }
        });
        return stationsToParticilarDestination;
    }


    public List<StationDestinationModel> GetDestinationsFromParticularStation(String stationName){
        Call<List<StationDestinationModel>> call = endpoints.GetDestinationsFromStation(stationName);

        call.enqueue(new Callback<List<StationDestinationModel>>() {
            @Override
            public void onResponse(Call<List<StationDestinationModel>> call, Response<List<StationDestinationModel>> response) {
                if (response.code() == 200)
                    destinationsFromParticularStation = response.body();


            }

            @Override
            public void onFailure(Call<List<StationDestinationModel>> call, Throwable t) {

                t.printStackTrace();

            }
        });
        return destinationsFromParticularStation;
    }


    public List<TrafficSignLocationModel> GetAllTrafficSigns(){
        Call<List<TrafficSignLocationModel>> call = endpoints.GetTrafficSignLocations();

        call.enqueue(new Callback<List<TrafficSignLocationModel>>() {
            @Override
            public void onResponse(Call<List<TrafficSignLocationModel>> call, Response<List<TrafficSignLocationModel>> response) {
                if (response.code() == 200)
                    trafficSignLocations = response.body();


            }

            @Override
            public void onFailure(Call<List<TrafficSignLocationModel>> call, Throwable t) {

                t.printStackTrace();

            }
        });
        return trafficSignLocations;
    }
}

