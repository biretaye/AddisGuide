package google.com.combo4.API;

import google.com.combo4.Entities.*;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

/**
 * Created by ITSC on 5/9/2016.
 */
public interface ApiEndpoints {

    @GET("Destinations/GetDestination/{id}")
    public Call<DestinationModel> GetDestination(@Path("id") int id);

    @GET("Destinations/")
    public Call<List<DestinationModel>> GetDestinations();






    @GET("Houses/")
    public Call<List<HouseModel>> GetHouses();

    @GET("Houses/GetHouseUsingHouseNoAndStreet/{id}/{id2}")
    public Call<List<HouseModel>> GetHouseUsingHouseNoAndStreet(@Path("id") String houseNumber,@Path("id2") String streetName);





    @GET("StationLocations/")
    public Call<List<StationLocationModel>> GetStationLocations();  //all

    @GET("StationLocations/GetStationTypeLocation/{id}")
    public Call<List<StationLocationModel>> GetStationTypeLocation(@Path("id") String stationType);

    @GET("StationLocations/GetStationName/{id}")
    public Call<StationLocationModel> GetStationFromName(@Path("id") String stationName);





    @GET("StationDestinations/")
    public Call<List<StationDestinationModel>> GetStationDestinations();

    @GET("StationDestinations/GetDestinationsFromStation/{id}")
    public Call<List<StationDestinationModel>> GetDestinationsFromStation(@Path("id") String stationName);

    @GET("StationDestinations/GetStationsFromDestination/{id}")
    public Call<List<StationDestinationModel>> GetStationsFromDestination(@Path("id") String destinationName);



    @GET("Streets/")
    public Call<List<StreetModel>> GetStreet();

    @GET("Streets/GetStreetUsingStreetNamen/{id}")
    public Call<List<StreetModel>> GetStreetUsingStreetName(@Path("id") String streetName);




    @GET("TrafficSignLocations/")
    public Call<List<TrafficSignLocationModel>> GetTrafficSignLocations();


    @GET("TrafficSignLocations//GetTrafficSignLocationByType/{id}")
    public Call<List<TrafficSignLocationModel>> GetTrafficSignLocationByType(@Path("id") String signName);


}

