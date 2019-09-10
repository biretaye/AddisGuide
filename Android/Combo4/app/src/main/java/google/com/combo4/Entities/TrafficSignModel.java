package google.com.combo4.Entities;

/**
 * Created by Nets-Hp on 5/20/2016.
 */

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;


public class TrafficSignModel {

    @SerializedName("$id")
    @Expose
    private String $id;
    @SerializedName("TrafficSignID")
    @Expose
    private Integer TrafficSignID;
    @SerializedName("TrafficSignName")
    @Expose
    private String TrafficSignName;


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
     * The TrafficSignID
     */
    public Integer getTrafficSignID() {
        return TrafficSignID;
    }

    /**
     *
     * @param TrafficSignID
     * The TrafficSignID
     */
    public void setTrafficSignID(Integer TrafficSignID) {
        this.TrafficSignID = TrafficSignID;
    }

    /**
     *
     * @return
     * The TrafficSignName
     */
    public String getTrafficSignName() {
        return TrafficSignName;
    }

    /**
     *
     * @param TrafficSignName
     * The TrafficSignName
     */
    public void setTrafficSignName(String TrafficSignName) {
        this.TrafficSignName = TrafficSignName;
    }

}