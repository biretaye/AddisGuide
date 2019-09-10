package google.com.combo4.API;


import java.util.ArrayList;
import java.util.List;

import google.com.combo4.Entities.DestinationModel;
import google.com.combo4.Entities.HouseModel;
import google.com.combo4.Entities.MidPointModel;
import google.com.combo4.Entities.StationDestinationModel;
import google.com.combo4.Entities.StationLocationModel;
import google.com.combo4.Entities.StreetModel;
import google.com.combo4.Entities.TrafficSignLocationModel;
import google.com.combo4.Entities.TrafficSignModel;

/**
 * Created by Nets-Hp on 5/24/2016.
 */
public class JsonParser {

    public static List<StationDestinationModel> ParseStationDestination(List<StationDestinationModel> stationDestinations){

        List<StationLocationModel> stations = new ArrayList<StationLocationModel>();

        List<DestinationModel> destinations = new ArrayList<DestinationModel>();
        List<MidPointModel> midPoints = new ArrayList<MidPointModel>();

        for (StationDestinationModel sd : stationDestinations){
            if (sd.getStationLocation() != null &&
                    sd.getStationLocation().get$id() == null &&
                    sd.getStationLocation().get$ref() != null){
                for (StationLocationModel sm : stations){
                    if (sm.get$id().equalsIgnoreCase(sd.getStationLocation().get$ref())){
                        sd.setStationLocation(sm);
                    }
                }

            } else {
                stations.add(sd.getStationLocation());
            }

            if (sd.getDestination() != null &&
                    sd.getDestination().get$id() == null &&
                    sd.getDestination().get$ref() != null){
                for (DestinationModel dm : destinations){
                    if (dm.get$id().equalsIgnoreCase(sd.getDestination().get$ref())){
                        sd.setDestination(dm);
                    }
                }

            } else {
                destinations.add(sd.getDestination());
            }

            if (sd.getMidPoint() != null &&
                    sd.getMidPoint().get$id() == null &&
                    sd.getMidPoint().get$ref() != null){
                for (MidPointModel mpm : midPoints){
                    if (mpm.get$id().equalsIgnoreCase(sd.getMidPoint().get$ref())){
                        sd.setMidPoint(mpm);
                    }
                }

            } else {
                midPoints.add(sd.getMidPoint());
            }

        }

        return stationDestinations;
    }

    public static List<HouseModel> ParseHouse(List<HouseModel> houses){
        List<StreetModel> streets = new ArrayList<>();
        for (HouseModel h: houses){
            if (h.getStreet() != null &&
                    h.getStreet().get$id() == null &&
                    h.getStreet().get$ref() != null){
                for (StreetModel s: streets){
                    if (s.get$id().equalsIgnoreCase(h.getStreet().get$ref())){
                        h.setStreet(s);
                    }
                }
            }else {
                streets.add(h.getStreet());
            }
        }
        return houses;

    }

    public static List<TrafficSignLocationModel> ParseTrafficSign(List<TrafficSignLocationModel> signs){
        List<TrafficSignModel> signName = new ArrayList<>();
        for (TrafficSignLocationModel ts : signs){
            if (ts.getTrafficSign() != null &&
                    ts.getTrafficSign().get$id() == null &&
                    ts.getTrafficSign().get$ref() != null){
                for (TrafficSignModel s : signName){
                    if (s.get$id().equalsIgnoreCase(ts.getTrafficSign().get$ref())){
                        ts.setTrafficSign(s);
                    }
                }

            }else {
                signName.add(ts.getTrafficSign());
            }
        }

        return signs;
    }


    public static List<StationLocationModel> GetStationLocationModelFromStationDestination(List<StationDestinationModel> stationDestinations){
        List<StationLocationModel> stationLocations = new ArrayList<>();
        for (StationDestinationModel sd : stationDestinations){
            stationLocations.add(sd.getStationLocation());
        }
        return stationLocations;
    }

    public static List<DestinationModel> GetDestinationModelFromStationDestination(List<StationDestinationModel> stationDestinations){
        List<DestinationModel> destinations = new ArrayList<>();
        for (StationDestinationModel sd : stationDestinations){
            destinations.add(sd.getDestination());
        }
        return destinations;
    }

//    public static List<StationDestinationModel> ParseStationFromDestination(List<StationDestinationModel> stationDestinations, String destinationName){
//        List<StationDestinationModel> stationDestinationsNew = ParseStationDestination(stationDestinations);
//        List<StationDestinationModel> stationDestinationsFinal = new ArrayList<>();
//
//        for (StationDestinationModel sd : stationDestinationsNew){
//            if (sd.getDestination().getDestinationName().equalsIgnoreCase(destinationName)){
//                stationDestinationsFinal.add(sd);
//            }
//        }
//        return stationDestinationsFinal;
//    }

    public static String changeString(String selam){
        String newSelam = selam;
        newSelam = "changed inside a method";
        return newSelam;
    }

    public static String add(int no){
        no = no + 2;
        return no + "";
    }
}
