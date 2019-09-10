package google.com.combo4.Entities;

/**
 * Created by Nets-Hp on 5/20/2016.
 */
import com.google.android.gms.maps.model.LatLng;
import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;


public class StationLocationModel {

    @SerializedName("$id")
    @Expose
    private String $id;
    @SerializedName("StationLocationID")
    @Expose
    private Integer StationLocationID;
    @SerializedName("StationType")
    @Expose
    private String StationType;
    @SerializedName("StationName")
    @Expose
    private String StationName;
    @SerializedName("StationLatitude")
    @Expose
    private Double StationLatitude;
    @SerializedName("StationLongitude")
    @Expose
    private Double StationLongitude;

    @SerializedName("$ref")
    @Expose
    private String $ref;

    /**
     *
     * @return
     * The $ref
     */
    public String get$ref() {
        return $ref;
    }

    /**
     *
     * @param $ref
     * The $ref
     */
    public void set$ref(String $ref) {
        this.$ref = $ref;
    }

    /**
     * @return The $id
     */



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
     * The StationLocationID
     */
    public Integer getStationLocationID() {
        return StationLocationID;
    }

    /**
     *
     * @param StationLocationID
     * The StationLocationID
     */
    public void setStationLocationID(Integer StationLocationID) {
        this.StationLocationID = StationLocationID;
    }

    /**
     *
     * @return
     * The StationType
     */
    public String getStationType() {
        return StationType;
    }

    /**
     *
     * @param StationType
     * The StationType
     */
    public void setStationType(String StationType) {
        this.StationType = StationType;
    }

    /**
     *
     * @return
     * The StationName
     */
    public String getStationName() {
        return StationName;
    }

    /**
     *
     * @param StationName
     * The StationName
     */
    public void setStationName(String StationName) {
        this.StationName = StationName;
    }

    /**
     *
     * @return
     * The StationLatitude
     */
    public Double getStationLatitude() {
        return StationLatitude;
    }

    /**
     *
     * @param StationLatitude
     * The StationLatitude
     */
    public void setStationLatitude(Double StationLatitude) {
        this.StationLatitude = StationLatitude;
    }

    /**
     *
     * @return
     * The StationLongitude
     */
    public Double getStationLongitude() {
        return StationLongitude;
    }

    /**
     *
     * @param StationLongitude
     * The StationLongitude
     */
    public void setStationLongitude(Double StationLongitude) {
        this.StationLongitude = StationLongitude;
    }

    public LatLng getLocation(){
        double lng = getStationLongitude();
        double lat = getStationLatitude();
        LatLng point = new LatLng(lat, lng);
        return  point;
    }

}

