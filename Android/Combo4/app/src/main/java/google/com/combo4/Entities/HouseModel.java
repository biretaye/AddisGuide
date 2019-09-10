package google.com.combo4.Entities;

/**
 * Created by Nets-Hp on 5/20/2016.
 */
import com.google.android.gms.maps.model.LatLng;
import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;


public class HouseModel {

    @SerializedName("$id")
    @Expose
    private String $id;
    @SerializedName("HouseID")
    @Expose
    private Integer HouseID;
    @SerializedName("HouseNumber")
    @Expose
    private String HouseNumber;

    @SerializedName("StreetID")
    @Expose
    private Integer StreetID;
    @SerializedName("House_Latitude")
    @Expose
    private Double HouseLatitude;
    @SerializedName("House_Longitude")
    @Expose
    private Double HouseLongitude;

    @SerializedName("Street")
    @Expose
    StreetModel Street;

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
     * The HouseID
     */
    public Integer getHouseID() {
        return HouseID;
    }

    /**
     *
     * @param HouseID
     * The HouseID
     */
    public void setHouseID(Integer HouseID) {
        this.HouseID = HouseID;
    }

    /**
     *
     * @return
     * The HouseNumber
     */
    public String getHouseNumber() {
        return HouseNumber;
    }

    /**
     *
     * @param HouseNumber
     * The HouseNumber
     */
    public void setHouseNumber(String HouseNumber) {
        this.HouseNumber = HouseNumber;
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
     * The HouseLatitude
     */
    public Double getHouseLatitude() {
        return HouseLatitude;
    }

    /**
     *
     * @param HouseLatitude
     * The House_Latitude
     */
    public void setHouseLatitude(Double HouseLatitude) {
        this.HouseLatitude = HouseLatitude;
    }

    /**
     *
     * @return
     * The HouseLongitude
     */
    public Double getHouseLongitude() {
        return HouseLongitude;
    }

    /**
     *
     * @param HouseLongitude
     * The House_Longitude
     */
    public void setHouseLongitude(Double HouseLongitude) {
        this.HouseLongitude = HouseLongitude;
    }



    /**
     *
     * @return
     * The Street
     */
    public StreetModel getStreet() {
        return Street;
    }

    /**
     *
     * @param Street
     * The Street
     */
    public void setStreet(StreetModel Street) {
        this.Street = Street;
    }

    public LatLng getLocation(){
        double lng = getHouseLongitude();
        double lat = getHouseLatitude();
        LatLng point = new LatLng(lat, lng);
        return point;
    }

}