package google.com.combo4.Entities;


import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;


public class MidPointModel {

    @SerializedName("$id")
    @Expose
    private String $id;
    @SerializedName("MidPointID")
    @Expose
    private Integer MidPointID;
    @SerializedName("MidPointName")
    @Expose
    private String MidPointName;
    @SerializedName("MidPointLatitude")
    @Expose
    private Object MidPointLatitude;
    @SerializedName("MidPointLongitude")
    @Expose
    private Object MidPointLongitude;

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
     * The MidPointName
     */
    public String getMidPointName() {
        return MidPointName;
    }

    /**
     *
     * @param MidPointName
     * The MidPointName
     */
    public void setMidPointName(String MidPointName) {
        this.MidPointName = MidPointName;
    }

    /**
     *
     * @return
     * The MidPointLatitude
     */
    public Object getMidPointLatitude() {
        return MidPointLatitude;
    }

    /**
     *
     * @param MidPointLatitude
     * The MidPointLatitude
     */
    public void setMidPointLatitude(Object MidPointLatitude) {
        this.MidPointLatitude = MidPointLatitude;
    }

    /**
     *
     * @return
     * The MidPointLongitude
     */
    public Object getMidPointLongitude() {
        return MidPointLongitude;
    }

    /**
     *
     * @param MidPointLongitude
     * The MidPointLongitude
     */
    public void setMidPointLongitude(Object MidPointLongitude) {
        this.MidPointLongitude = MidPointLongitude;
    }

}