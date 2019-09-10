package google.com.combo4.lbs;

import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;

import android.os.AsyncTask;
import android.util.Log;

public class PlacesTask extends AsyncTask<String, Void, String>{

	@Override
	protected String doInBackground(String... place) {
		String data = "";
		
		// Obtain browser key from https://code.google.com/apis/console
		String key = "key=YOUR_API_KEY";
		
		String input="";
		
		try {
			input = "input=" + URLEncoder.encode(place[0], "utf-8");
		} catch (UnsupportedEncodingException e1) {
			e1.printStackTrace();
		}		
		
		
		// place type to be searched
		String types = "types=geocode";
		
		// Sensor enabled
		String sensor = "sensor=false";			
		
		// Building the parameters to the web service
		String parameters = input+"&"+types+"&"+sensor+"&"+key;
		
		// Output format
		String output = "json";
		
		// Building the url to the web service
		String url = "https://maps.googleapis.com/maps/api/place/autocomplete/"+output+"?"+parameters;

		try{
			// Fetching the data from web service in background
			Http http= new Http();
			data = http.read(url);
		}catch(Exception e){
            Log.d("Background Task",e.toString());
		}
		return data;		
	}
	@Override
	protected void onPostExecute(String result) {			
		super.onPostExecute(result);
		
		// Creating ParserTask
		PlacesDisplayTask parserTask = new PlacesDisplayTask();
		
		// Starting Parsing the JSON string returned by Web Service
		parserTask.execute(result);
	}		
}
