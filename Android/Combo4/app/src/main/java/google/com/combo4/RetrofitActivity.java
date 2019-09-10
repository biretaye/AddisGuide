//package google.com.combo4;
//
//import android.os.Bundle;
//import android.support.v7.app.AppCompatActivity;
//import android.widget.TextView;
//
//import google.com.combo4.Entities.DestinationModel;
//import google.com.combo4.Infra.ApiEndpoints;
//import google.com.combo4.Infra.RetrofitInitializer;
//
//import retrofit2.Call;
//import retrofit2.Callback;
//import retrofit2.Response;
//import retrofit2.Retrofit;
//
//public class RetrofitActivity extends AppCompatActivity {
//
//    private TextView textViewTest;
//    private TextView textViewTest3;
//    private TextView textViewTest4;
//    private TextView textViewTest5;
//    private TextView textViewTest7;
//    private TextView textViewTest8;
//    private TextView textViewTest9;
//    private TextView textViewTest10;
//    private TextView textViewTest15;
//    private TextView textViewTest16;
//    private TextView textViewTest18;
//    private TextView textViewTest20;
//
//    @Override
//    protected void onCreate(Bundle savedInstanceState) {
//        super.onCreate(savedInstanceState);
//        setContentView(R.layout.activity_retrofit);
//
//        textViewTest = (TextView)findViewById(R.id.textViewTest);
//        textViewTest3 = (TextView)findViewById(R.id.textViewTest3);
//        textViewTest4 = (TextView)findViewById(R.id.textViewTest4);
//        textViewTest5 = (TextView)findViewById(R.id.textViewTest5);
//        textViewTest7 = (TextView)findViewById(R.id.textViewTest7);
//        textViewTest9 = (TextView)findViewById(R.id.textViewTest9);
//        textViewTest8 = (TextView)findViewById(R.id.textViewTest8);
//        textViewTest10 = (TextView)findViewById(R.id.textViewTest10);
//        textViewTest15 = (TextView)findViewById(R.id.textViewTest15);
//        textViewTest16 = (TextView)findViewById(R.id.textViewTest16);
//        textViewTest18 = (TextView)findViewById(R.id.textViewTest18);
//        textViewTest20 = (TextView)findViewById(R.id.textViewTest20);
//
//
//        Retrofit retrofit = RetrofitInitializer.intializeRetrofit();
//        ApiEndpoints endpoints = retrofit.create(ApiEndpoints.class);
//
////        Call<DestinationModel> call = endpoints.getDestination(2);
////        Call<DestinationModel> call3 = endpoints.getDestination(3);
////        Call<DestinationModel> call4 = endpoints.getDestination(4);
////        Call<DestinationModel> call5 = endpoints.getDestination(5);
////        Call<DestinationModel> call7 = endpoints.getDestination(7);
////        Call<DestinationModel> call8 = endpoints.getDestination(8);
////        Call<DestinationModel> call9 = endpoints.getDestination(9);
////        Call<DestinationModel> call10 = endpoints.getDestination(10);
////        Call<DestinationModel> call15 = endpoints.getDestination(15);
////        Call<DestinationModel> call16 = endpoints.getDestination(16);
////        Call<DestinationModel> call18 = endpoints.getDestination(18);
////        Call<DestinationModel> call20 = endpoints.getDestination(20);
//
//        call.enqueue(new Callback<DestinationModel>() {
//            @Override
//            public void onResponse(Call<DestinationModel> call, Response<DestinationModel> response) {
//                switch (response.code()){
//                    case 200:
//                        DestinationModel bole = response.body();
//                        textViewTest.setText("Name: " + bole.getDestinationName() +
//                                "\nLongitude: " + bole.getDestinationLatitude() + "\nLatitude: " + bole.getDestinationLongitude());
//                        break;
//                }
//            }
//
//            @Override
//            public void onFailure(Call<DestinationModel> call, Throwable t) {
//                textViewTest.setText("Retrofit failed");
//                t.printStackTrace();
//
//            }
//        });
//
//        call3.enqueue(new Callback<DestinationModel>() {
//            @Override
//            public void onResponse(Call<DestinationModel> call3, Response<DestinationModel> response) {
//                switch (response.code()){
//                    case 200:
//                        DestinationModel mexico = response.body();
//                        textViewTest3.setText("Name: " + mexico.getDestinationName() +
//                                "\nLongitude: " + mexico.getDestinationLatitude() + "\nLatitude: " + mexico.getDestinationLongitude());
//                        break;
//                }
//            }
//
//            @Override
//            public void onFailure(Call<DestinationModel> call3, Throwable t) {
//                textViewTest3.setText("Retrofit failed");
//                t.printStackTrace();
//
//            }
//        });
//
//        call4.enqueue(new Callback<DestinationModel>() {
//            @Override
//            public void onResponse(Call<DestinationModel> call4, Response<DestinationModel> response) {
//                switch (response.code()){
//                    case 200:
//                        DestinationModel legehar = response.body();
//                        textViewTest4.setText("Name: " + legehar.getDestinationName() +
//                                "\nLongitude: " + legehar.getDestinationLatitude() + "\nLatitude: " + legehar.getDestinationLongitude());
//                        break;
//                }
//            }
//
//            @Override
//            public void onFailure(Call<DestinationModel> call4, Throwable t) {
//                textViewTest4.setText("Retrofit failed");
//                t.printStackTrace();
//
//            }
//        });
//
//        call5.enqueue(new Callback<DestinationModel>() {
//            @Override
//            public void onResponse(Call<DestinationModel> call5, Response<DestinationModel> response) {
//                switch (response.code()){
//                    case 200:
//                        DestinationModel shewadabo = response.body();
//                        textViewTest5.setText("Name: " + shewadabo.getDestinationName() +
//                                "\nLongitude: " + shewadabo.getDestinationLatitude() + "\nLatitude: " + shewadabo.getDestinationLongitude());
//                        break;
//                }
//            }
//
//            @Override
//            public void onFailure(Call<DestinationModel> call5, Throwable t) {
//                textViewTest5.setText("Retrofit failed");
//                t.printStackTrace();
//
//            }
//        });
//
//        call7.enqueue(new Callback<DestinationModel>() {
//            @Override
//            public void onResponse(Call<DestinationModel> call7, Response<DestinationModel> response) {
//                switch (response.code()){
//                    case 200:
//                        DestinationModel saris = response.body();
//                        textViewTest7.setText("Name: " + saris.getDestinationName() +
//                                "\nLongitude: " + saris.getDestinationLatitude() + "\nLatitude: " + saris.getDestinationLongitude());
//                        break;
//                }
//            }
//
//            @Override
//            public void onFailure(Call<DestinationModel> call7, Throwable t) {
//                textViewTest7.setText("Retrofit failed");
//                t.printStackTrace();
//
//            }
//        });
//
//        call8.enqueue(new Callback<DestinationModel>() {
//            @Override
//            public void onResponse(Call<DestinationModel> call8, Response<DestinationModel> response) {
//                switch (response.code()){
//                    case 200:
//                        DestinationModel gerji = response.body();
//                        textViewTest8.setText("Name: " + gerji.getDestinationName() +
//                                "\nLongitude: " + gerji.getDestinationLatitude() + "\nLatitude: " + gerji.getDestinationLongitude());
//                        break;
//                }
//            }
//
//            @Override
//            public void onFailure(Call<DestinationModel> call8, Throwable t) {
//                textViewTest8.setText("Retrofit failed");
//                t.printStackTrace();
//
//            }
//        });
//
//        call9.enqueue(new Callback<DestinationModel>() {
//            @Override
//            public void onResponse(Call<DestinationModel> call9, Response<DestinationModel> response) {
//                switch (response.code()){
//                    case 200:
//                        DestinationModel megenagna = response.body();
//                        textViewTest9.setText("Name: " + megenagna.getDestinationName() +
//                                "\nLongitude: " + megenagna.getDestinationLatitude() + "\nLatitude: " + megenagna.getDestinationLongitude());
//                        break;
//                }
//            }
//
//            @Override
//            public void onFailure(Call<DestinationModel> call9, Throwable t) {
//                textViewTest9.setText("Retrofit failed");
//                t.printStackTrace();
//
//            }
//        });
//
//        call10.enqueue(new Callback<DestinationModel>() {
//            @Override
//            public void onResponse(Call<DestinationModel> call10, Response<DestinationModel> response) {
//                switch (response.code()){
//                    case 200:
//                        DestinationModel kasanchis = response.body();
//                        textViewTest10.setText("Name: " + kasanchis.getDestinationName() +
//                                "\nLongitude: " + kasanchis.getDestinationLatitude() + "\nLatitude: " + kasanchis.getDestinationLongitude());
//                        break;
//                }
//            }
//
//            @Override
//            public void onFailure(Call<DestinationModel> call10, Throwable t) {
//                textViewTest10.setText("Retrofit failed");
//                t.printStackTrace();
//
//            }
//        });
//
//        call15.enqueue(new Callback<DestinationModel>() {
//            @Override
//            public void onResponse(Call<DestinationModel> call15, Response<DestinationModel> response) {
//                switch (response.code()){
//                    case 200:
//                        DestinationModel stadium = response.body();
//                        textViewTest15.setText("Name: " + stadium.getDestinationName() +
//                                "\nLongitude: " + stadium.getDestinationLatitude() + "\nLatitude: " + stadium.getDestinationLongitude());
//                        break;
//                }
//            }
//
//            @Override
//            public void onFailure(Call<DestinationModel> call15, Throwable t) {
//                textViewTest15.setText("Retrofit failed");
//                t.printStackTrace();
//
//            }
//        });
//
//        call16.enqueue(new Callback<DestinationModel>() {
//            @Override
//            public void onResponse(Call<DestinationModel> call16, Response<DestinationModel> response) {
//                switch (response.code()){
//                    case 200:
//                        DestinationModel piassa = response.body();
//                        textViewTest16.setText("Name: " + piassa.getDestinationName() +
//                                "\nLongitude: " + piassa.getDestinationLatitude() + "\nLatitude: " + piassa.getDestinationLongitude());
//                        break;
//                }
//            }
//
//            @Override
//            public void onFailure(Call<DestinationModel> call16, Throwable t) {
//                textViewTest16.setText("Retrofit failed");
//                t.printStackTrace();
//
//            }
//        });
//
//        call18.enqueue(new Callback<DestinationModel>() {
//            @Override
//            public void onResponse(Call<DestinationModel> call18, Response<DestinationModel> response) {
//                switch (response.code()){
//                    case 200:
//                        DestinationModel piassa = response.body();
//                        textViewTest18.setText("Name: " + piassa.getDestinationName() +
//                                "\nLongitude: " + piassa.getDestinationLatitude() + "\nLatitude: " + piassa.getDestinationLongitude());
//                        break;
//                }
//            }
//
//            @Override
//            public void onFailure(Call<DestinationModel> call18, Throwable t) {
//                textViewTest18.setText("Retrofit failed");
//                t.printStackTrace();
//
//            }
//        });
//
//        call20.enqueue(new Callback<DestinationModel>() {
//            @Override
//            public void onResponse(Call<DestinationModel> call20, Response<DestinationModel> response) {
//                switch (response.code()){
//                    case 200:
//                        DestinationModel merkato = response.body();
//                        textViewTest20.setText("Name: " + merkato.getDestinationName() +
//                                "\nLongitude: " + merkato.getDestinationLatitude() + "\nLatitude: " + merkato.getDestinationLongitude());
//                        break;
//                }
//            }
//
//            @Override
//            public void onFailure(Call<DestinationModel> call20, Throwable t) {
//                textViewTest20.setText("Retrofit failed");
//                t.printStackTrace();
//
//            }
//        });
//    }
//}
