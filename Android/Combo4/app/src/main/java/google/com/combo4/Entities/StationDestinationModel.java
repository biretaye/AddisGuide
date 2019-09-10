package google.com.combo4.Entities;

/**
 * Created by Nets-Hp on 5/20/2016.
 */
import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class StationDestinationModel {

    @SerializedName("$id")
    @Expose
    private String $id;
    @SerializedName("StationDestinationID")
    @Expose
    private Integer StationDestinationID;
    @SerializedName("StationLocationID")
    @Expose
    private Integer StationLocationID;
    @SerializedName("DestinationID")
    @Expose
    private Integer DestinationID;
    @SerializedName("MidPointID")
    @Expose
    private Integer MidPointID;
    @SerializedName("Destination")
    @Expose
    private DestinationModel Destination;
    @SerializedName("StationLocation")
    @Expose
    private StationLocationModel StationLocation;
    @SerializedName("MidPoint")
    @Expose
    private MidPointModel MidPoint;

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
     * The StationDestinationID
     */
    public Integer getStationDestinationID() {
        return StationDestinationID;
    }

    /**
     *
     * @param StationDestinationID
     * The StationDestinationID
     */
    public void setStationDestinationID(Integer StationDestinationID) {
        this.StationDestinationID = StationDestinationID;
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
     * The DestinationID
     */
    public Integer getDestinationID() {
        return DestinationID;
    }

    /**
     *
     * @param DestinationID
     * The DestinationID
     */
    public void setDestinationID(Integer DestinationID) {
        this.DestinationID = DestinationID;
    }

    /**
     *
     * @return
     * The Destination
     */
    public DestinationModel getDestination() {
        return Destination;
    }

    /**
     *
     * @param Destination
     * The Destination
     */
    public void setDestination(DestinationModel Destination) {
        this.Destination = Destination;
    }

    /**
     *
     * @return
     * The StationLocation
     */
    public StationLocationModel getStationLocation() {
        return StationLocation;
    }

    /**
     *
     * @param StationLocation
     * The StationLocation
     */
    public void setStationLocation(StationLocationModel StationLocation) {
        this.StationLocation = StationLocation;
    }

    /**
     *
     * @return
     * The MidPointID
     */
    public Integer getMidPointID() {
        return MidPointID;
    }

    /**
     *
     * @param MidPointID
     * The MidPointID
     */
    public void setMidPointID(Integer MidPointID) {
        this.MidPointID = MidPointID;
    }


    /**
     *
     * @return
     * The MidPoint
     */
    public MidPointModel getMidPoint() {
        return MidPoint;
    }

    /**
     *
     * @param MidPoint
     * The MidPoint
     */
    public void setMidPoint(MidPointModel MidPoint) {
        this.MidPoint = MidPoint;
    }

}