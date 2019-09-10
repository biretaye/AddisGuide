package google.com.combo4.Entities;

/**
 * Created by Nets-Hp on 5/20/2016.
 */
import com.google.android.gms.maps.model.LatLng;
import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;


public class DestinationModel {

    @SerializedName("$id")
    @Expose
    private String $id;

    @SerializedName("DestinationID")
    @Expose
    private Integer DestinationID;

    @SerializedName("DestinationName")
    @Expose
    private String DestinationName;

    @SerializedName("DestinationLatitude")
    @Expose
    private Double DestinationLatitude;

    @SerializedName("DestinationLongitude")
    @Expose
    private Double DestinationLongitude;

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
    public String get$id() {
        return $id;
    }

    /**
     * @param $id The $id
     */
    public void set$id(String $id) {
        this.$id = $id;
    }

    /**
     * @return The DestinationID
     */
    public Integer getDestinationID() {
        return DestinationID;
    }

    /**
     * @param DestinationID The DestinationID
     */
    public void setDestinationID(Integer DestinationID) {
        this.DestinationID = DestinationID;
    }

    /**
     * @return The DestinationName
     */
    public String getDestinationName() {
        return DestinationName;
    }

    /**
     * @param DestinationName The DestinationName
     */
    public void setDestinationName(String DestinationName) {
        this.DestinationName = DestinationName;
    }

    /**
     * @return The DestinationLatitude
     */
    public Double getDestinationLatitude() {
        return DestinationLatitude;
    }

    /**
     * @param DestinationLatitude The DestinationLatitude
     */
    public void setDestinationLatitude(Double DestinationLatitude) {
        this.DestinationLatitude = DestinationLatitude;
    }

    /**
     * @return The DestinationLongitude
     */
    public Double getDestinationLongitude() {
        return DestinationLongitude;
    }

    /**
     * @param DestinationLongitude The DestinationLongitude
     */
    public void setDestinationLongitude(Double DestinationLongitude) {
        this.DestinationLongitude = DestinationLongitude;
    }

    public LatLng getLocation(){
        double lng = getDestinationLongitude();
        double lat = getDestinationLatitude();
        LatLng point = new LatLng(lat, lng);
        return  point;
    }
}


