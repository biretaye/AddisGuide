package google.com.combo4.route;

import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.location.LocationManager;
import android.media.MediaPlayer;
import android.net.Uri;
import android.support.v4.app.NotificationCompat;
import android.widget.Toast;

import java.util.ArrayList;

import google.com.combo4.R;

import static android.content.Intent.FLAG_ACTIVITY_NEW_TASK;


/**
 * Created by Nets-Hp on 6/3/2016.
 */
public class ProximityActivity extends BroadcastReceiver {
    String notificationTitle;
    String notificationContent;
    String tickerMessage;
    private MediaPlayer mp;
    ArrayList<String> instructions = new ArrayList<String>();

    @Override
    public void onReceive(Context mycontext, Intent myintent) {
        String k = LocationManager.KEY_PROXIMITY_ENTERING;
        boolean proximity_entering = myintent.getBooleanExtra(k, true);
        int indexer = myintent.getIntExtra("counter", 0);
        if (proximity_entering && indexer <= Dec.html_instructions.size()) {

            if (Dec.html_instructions.get(indexer).contains("right")) {
                mp = MediaPlayer.create(mycontext, R.raw.left);
            } else if (Dec.html_instructions.get(indexer).contains("left")) {
                mp = MediaPlayer.create(mycontext, R.raw.left);
            } else if (Dec.html_instructions.get(indexer).contains("Head")) {
                //search is case sensitive
                mp = MediaPlayer.create(mycontext, R.raw.start);
            } else if (Dec.html_instructions.get(indexer).contains("Continue")) {
                mp = MediaPlayer.create(mycontext, R.raw.arrived);
            } else {
                mp = MediaPlayer.create(mycontext, R.raw.right);
            }
            mp.start();
            Toast.makeText(mycontext, String.valueOf(indexer)+" alert on", Toast.LENGTH_LONG).show();

            notificationTitle = "Proximity - Entry";
            notificationContent = "Entered the region";
            tickerMessage = "Entered the region";
        }
        else{
            Toast.makeText(mycontext,"Exiting the region"  ,Toast.LENGTH_LONG).show();
            notificationTitle="Proximity - Exit";
            notificationContent="Exited the region";
            tickerMessage = "Exited the region";
        }
        Intent notificationIntent = new Intent(mycontext,getClass());
        notificationIntent.putExtra("content", notificationContent );
        notificationIntent.setData(Uri.parse("tel:/"+ (int)System.currentTimeMillis()));
        PendingIntent pendingIntent = PendingIntent.getActivity(mycontext, 0, notificationIntent, 0);
        NotificationManager nManager = (NotificationManager) mycontext.getSystemService(Context.NOTIFICATION_SERVICE);
        NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(mycontext)
                .setWhen(System.currentTimeMillis())
                .setAutoCancel(true)
                .setContentIntent(pendingIntent);

        Notification notification = notificationBuilder.build();

        nManager.notify((int)System.currentTimeMillis(), notification);

    }
}
