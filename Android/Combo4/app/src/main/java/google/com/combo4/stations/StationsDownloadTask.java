package google.com.combo4.stations;


import com.google.android.gms.maps.GoogleMap;

import android.os.AsyncTask;
import android.util.Log;

import google.com.combo4.route.Http;

public class StationsDownloadTask extends AsyncTask<Object, Void, String> {
	GoogleMap map;
	@Override
	protected String doInBackground(Object... inputObj) {

		String data = "";

		try {
			map=(GoogleMap) inputObj[0];
			String myurl = (String)inputObj[1];
			
			Http http = new Http();
			data = http.downloadUrl(myurl);
		} catch (Exception e) {
			Log.d("Background Task", e.toString());
		}
		return data;
	}

	@Override
	protected void onPostExecute(String result) {
		super.onPostExecute(result);
		  
		StationsParserTask parserTask = new StationsParserTask();
		Object[] toPass = new Object[2];
        toPass[0] = map;
        toPass[1] = result;
		parserTask.execute(toPass);

	}
}
