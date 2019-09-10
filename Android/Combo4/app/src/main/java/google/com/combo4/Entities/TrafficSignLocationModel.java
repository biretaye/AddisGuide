package google.com.combo4.Entities;

/**
 * Created by Nets-Hp on 5/20/2016.
 */
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.LatLngBounds;
import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;


public class TrafficSignLocationModel {

    @SerializedName("$id")
    @Expose
    private String $id;
    @SerializedName("TrafficSignLocationID")
    @Expose
    private Integer trafficSignLocationID;
    @SerializedName("TrafficSignID")
    @Expose
    private Integer trafficSignID;
    @SerializedName("TSLocationStartLatitude")
    @Expose
    private Double tSLocationStartLatitude;
    @SerializedName("TSLocationStartLongitude")
    @Expose
    private Double tSLocationStartLongitude;
    @SerializedName("TSLocationEndLatitude")
    @Expose
    private Double tSLocationEndLatitude;
    @SerializedName("TSLocationEndLongitude")
    @Expose
    private Double tSLocationEndLongitude;
    @SerializedName("TrafficSign")
    @Expose
    private TrafficSignModel trafficSign;

    /**
     *
     * @return
     * The $id
     */
    public String get$id() {
        return $id;
    }

    /**
     *
     * @param $id
     * The $id
     */
    public void set$id(String $id) {
        this.$id = $id;
    }

    /**
     *
     * @return
     * The trafficSignLocationID
     */
    public Integer getTrafficSignLocationID() {
        return trafficSignLocationID;
    }

    /**
     *
     * @param trafficSignLocationID
     * The TrafficSignLocationID
     */
    public void setTrafficSignLocationID(Integer trafficSignLocationID) {
        this.trafficSignLocationID = trafficSignLocationID;
    }

    /**
     *
     * @return
     * The trafficSignID
     */
    public Integer getTrafficSignID() {
        return trafficSignID;
    }

    /**
     *
     * @param trafficSignID
     * The TrafficSignID
     */
    public void setTrafficSignID(Integer trafficSignID) {
        this.trafficSignID = trafficSignID;
    }

    /**
     *
     * @return
     * The tSLocationStartLatitude
     */
    public Double getTSLocationStartLatitude() {
        return tSLocationStartLatitude;
    }

    /**
     *
     * @param tSLocationStartLatitude
     * The TSLocationStartLatitude
     */
    public void setTSLocationStartLatitude(Double tSLocationStartLatitude) {
        this.tSLocationStartLatitude = tSLocationStartLatitude;
    }

    /**
     *
     * @return
     * The tSLocationStartLongitude
     */
    public Double getTSLocationStartLongitude() {
        return tSLocationStartLongitude;
    }

    /**
     *
     * @param tSLocationStartLongitude
     * The TSLocationStartLongitude
     */
    public void setTSLocationStartLongitude(Double tSLocationStartLongitude) {
        this.tSLocationStartLongitude = tSLocationStartLongitude;
    }

    /**
     *
     * @return
     * The tSLocationEndLatitude
     */
    public Double getTSLocationEndLatitude() {
        return tSLocationEndLatitude;
    }

    /**
     *
     * @param tSLocationEndLatitude
     * The TSLocationEndLatitude
     */
    public void setTSLocationEndLatitude(Double tSLocationEndLatitude) {
        this.tSLocationEndLatitude = tSLocationEndLatitude;
    }

    /**
     *
     * @return
     * The tSLocationEndLongitude
     */
    public Double getTSLocationEndLongitude() {
        return tSLocationEndLongitude;
    }

    /**
     *
     * @param tSLocationEndLongitude
     * The TSLocationEndLongitude
     */
    public void setTSLocationEndLongitude(Double tSLocationEndLongitude) {
        this.tSLocationEndLongitude = tSLocationEndLongitude;
    }

    /**
     *
     * @return
     * The trafficSign
     */
    public TrafficSignModel getTrafficSign() {
        return trafficSign;
    }

    /**
     *
     * @param trafficSign
     * The TrafficSign
     */
    public void setTrafficSign(TrafficSignModel trafficSign) {
        this.trafficSign = trafficSign;
    }


    public LatLng getStartLocation(){
        double lng = getTSLocationStartLongitude();
        double lat = getTSLocationStartLatitude();
        LatLng point = new LatLng(lat, lng);
        return  point;
    }


    public LatLng getEndLocation(){
        double lng = getTSLocationEndLongitude();
        double lat = getTSLocationEndLatitude();
        LatLng point = new LatLng(lat, lng);
        return  point;
    }
    public LatLngBounds getBound(){
        LatLng ne=getStartLocation();
        LatLng sw=getEndLocation();
        LatLngBounds bound = new LatLngBounds(ne,sw);
        return bound;
    }

}
