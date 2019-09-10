package google.com.combo4.API;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

/**
 * Created by Nets-Hp on 5/20/2016.
 */
public class RetrofitInitializer {

    //public static final String BASE_URL = "http://10.5.55.139:40805/api/";
    public static final String BASE_URL = "http://192.168.43.32:40805/api/";


    public static Retrofit intializeRetrofit() {
        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(BASE_URL)
                .addConverterFactory(GsonConverterFactory.create())
                .build();

        return retrofit;
    }
}
