package google.com.combo4.route;


import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.util.Log;

import com.google.android.gms.maps.model.LatLng;

public class DirectionsJSONParser {
	
	public List<List<HashMap<String,String>>> parse(JSONObject jObject){
		
		List<List<HashMap<String, String>>> routes = new ArrayList<List<HashMap<String,String>>>() ;
		JSONArray jRoutes = null;
		JSONArray jLegs = null;
		JSONArray jSteps = null;	
		Dec.waypoints.add(new LatLng(8.9535, 38.76347));
		
		try {			
			
			jRoutes = jObject.getJSONArray("routes");
			for(int i=0;i<jRoutes.length();i++){			
				jLegs = ( (JSONObject)jRoutes.get(i)).getJSONArray("legs");
				List<HashMap<String, String>> path = new ArrayList<HashMap<String, String>>();
				for(int j=0;j<jLegs.length();j++){

					Dec.distance=((JSONObject) ((JSONObject)jLegs.get(j)).get("distance")).get("text").toString();
					
					Dec.duration=((JSONObject) ((JSONObject)jLegs.get(j)).get("duration")).get("text").toString();
					Log.d("Distance",Dec.distance.toString());
					jSteps = ( (JSONObject)jLegs.get(j)).getJSONArray("steps");
					
					for(int k=0;k<jSteps.length();k++){
						String polyline = "";
						if((boolean)(((JSONObject)jSteps.get(k)).has("html_instructions")))
						{
							String html=(String)(((JSONObject)jSteps.get(k)).get("html_instructions"));
							html=html.replaceAll("\\<.*?>","");
							Dec.html_instructions.add(html);
							Log.d("html_instructions", html);
						}
						else
						{
							Dec.html_instructions.add("no html");
							Log.d("SIDE", "NO Side");
						}
						if((boolean)(((JSONObject)jSteps.get(k)).has("maneuver")))
						{
							String side=(String)(((JSONObject)jSteps.get(k)).get("maneuver"));
							Dec.maneuver.add(side);
							Log.d("SIDE", side);
						}
						else
						{
							Dec.maneuver.add("No side");
							Log.d("SIDE", "NO Side");
						}
						Dec.dis.add((String)((JSONObject)((JSONObject)jSteps.get(k)).get("distance")).get("text"));
						Log.d("DIS", (String)((JSONObject)((JSONObject)jSteps.get(k)).get("distance")).get("text"));
						Dec.dur.add((String)((JSONObject)((JSONObject)jSteps.get(k)).get("duration")).get("text"));
						Dec.starting_lat.add((Double)((JSONObject)((JSONObject)jSteps.get(k)).get("start_location")).get("lat"));
						Dec.starting_long.add((Double)((JSONObject)((JSONObject)jSteps.get(k)).get("start_location")).get("lng"));
						Dec.ending_lat.add((Double)((JSONObject)((JSONObject)jSteps.get(k)).get("end_location")).get("lat"));
						Dec.ending_long.add((Double)((JSONObject)((JSONObject)jSteps.get(k)).get("end_location")).get("lng"));

						
						
						polyline = (String)((JSONObject)((JSONObject)jSteps.get(k)).get("polyline")).get("points");
						List<LatLng> list = decodePoly(polyline);
						for(int l=0;l<list.size();l++){
							HashMap<String, String> hm = new HashMap<String, String>();
							hm.put("lat", Double.toString(((LatLng)list.get(l)).latitude) );
							hm.put("lng", Double.toString(((LatLng)list.get(l)).longitude) );
							path.add(hm);						
						}								
					}
					routes.add(path);
				}
			}
			
		} catch (JSONException e) {			
			e.printStackTrace();
		}catch (Exception e){			
		}
		
		
		return routes;
	}	
	
	
	
    private List<LatLng> decodePoly(String encoded) {

        List<LatLng> poly = new ArrayList<LatLng>();
        int index = 0, len = encoded.length();
        int lat = 0, lng = 0;

        while (index < len) {
            int b, shift = 0, result = 0;
            do {
                b = encoded.charAt(index++) - 63;
                result |= (b & 0x1f) << shift;
                shift += 5;
            } while (b >= 0x20);
            int dlat = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
            lat += dlat;

            shift = 0;
            result = 0;
            do {
                b = encoded.charAt(index++) - 63;
                result |= (b & 0x1f) << shift;
                shift += 5;
            } while (b >= 0x20);
            int dlng = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
            lng += dlng;

            LatLng p = new LatLng((((double) lat / 1E5)),
                    (((double) lng / 1E5)));
            poly.add(p);
        }

        return poly;
    }
}