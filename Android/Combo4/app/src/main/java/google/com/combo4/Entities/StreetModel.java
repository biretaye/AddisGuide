package google.com.combo4.Entities;

/**
 * Created by Nets-Hp on 5/20/2016.
 */
import com.google.android.gms.maps.model.LatLng;
import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;


public class StreetModel {

    @SerializedName("$id")
    @Expose
    private String $id;
    @SerializedName("StreetID")
    @Expose
    private Integer StreetID;
    @SerializedName("StreetName")
    @Expose
    private String StreetName;
    @SerializedName("StreetStartLatitude")
    @Expose
    private Double StreetStartLatitude;
    @SerializedName("StreetStartLongitude")
    @Expose
    private Double StreetStartLongitude;
    @SerializedName("StreetEndLatitude")
    @Expose
    private Double StreetEndLatitude;
    @SerializedName("StreetEndLongitude")
    @Expose
    private Double StreetEndLongitude;

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
     * The StreetID
     */
    public Integer getStreetID() {
        return StreetID;
    }

    /**
     *
     * @param StreetID
     * The StreetID
     */
    public void setStreetID(Integer StreetID) {
        this.StreetID = StreetID;
    }

    /**
     *
     * @return
     * The StreetName
     */
    public String getStreetName() {
        return StreetName;
    }

    /**
     *
     * @param StreetName
     * The StreetName
     */
    public void setStreetName(String StreetName) {
        this.StreetName = StreetName;
    }

    /**
     *
     * @return
     * The StreetStartLatitude
     */
    public Double getStreetStartLatitude() {
        return StreetStartLatitude;
    }

    /**
     *
     * @param StreetStartLatitude
     * The StreetStartLatitude
     */
    public void setStreetStartLatitude(Double StreetStartLatitude) {
        this.StreetStartLatitude = StreetStartLatitude;
    }

    /**
     *
     * @return
     * The StreetStartLongitude
     */
    public Double getStreetStartLongitude() {
        return StreetStartLongitude;
    }

    /**
     *
     * @param StreetStartLongitude
     * The StreetStartLongitude
     */
    public void setStreetStartLongitude(Double StreetStartLongitude) {
        this.StreetStartLongitude = StreetStartLongitude;
    }

    /**
     *
     * @return
     * The StreetEndLatitude
     */
    public Double getStreetEndLatitude() {
        return StreetEndLatitude;
    }

    /**
     *
     * @param StreetEndLatitude
     * The StreetEndLatitude
     */
    public void setStreetEndLatitude(Double StreetEndLatitude) {
        this.StreetEndLatitude = StreetEndLatitude;
    }

    /**
     *
     * @return
     * The StreetEndLongitude
     */
    public Double getStreetEndLongitude() {
        return StreetEndLongitude;
    }

    /**
     *
     * @param StreetEndLongitude
     * The StreetEndLongitude
     */
    public void setStreetEndLongitude(Double StreetEndLongitude) {
        this.StreetEndLongitude = StreetEndLongitude;
    }



    public LatLng getStartLocation(){
        double lng = getStreetStartLongitude();
        double lat = getStreetStartLatitude();
        LatLng point = new LatLng(lat, lng);
        return  point;
    }

    public LatLng getEndLocation(){
        double lng = getStreetEndLongitude();
        double lat = getStreetEndLatitude();
        LatLng point = new LatLng(lat, lng);
        return  point;
    }

}
