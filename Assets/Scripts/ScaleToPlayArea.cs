using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ScaleToPlayArea : MonoBehaviour {

    //public SDK_BaseBoundaries boundaries;
    // Use this for initialization
    void Start() {
        Scale();
    }


    IEnumerator Scale()
    {
        var rect = new Valve.VR.HmdQuad_t();

        while(!SteamVR_PlayArea.GetBounds(SteamVR_PlayArea.Size.Calibrated, ref rect)) {
            print("waiting");
            yield return new WaitForSeconds(0.1f);
        }

        Vector3 newScale = new Vector3(Mathf.Abs(rect.vCorners0.v0 - rect.vCorners2.v0), this.transform.localScale.y, Mathf.Abs(rect.vCorners0.v2 - rect.vCorners2.v2));

        //this.transform.localScale = newScale;


        ////SDK_BaseBoundaries boundaries = GetComponent<SDK_BaseBoundaries>();
        //Transform playArea = boundaries.GetPlayArea();

        //float xScale = this.transform.lossyScale.x / playArea.transform.lossyScale.x;
        //float yScale = this.transform.lossyScale.y / playArea.transform.lossyScale.y;
        //float zScale = this.transform.lossyScale.z / playArea.transform.lossyScale.z;
        float minScale = Mathf.Min(newScale.x, newScale.z);
        this.transform.SetGlobalScale(new Vector3(minScale, minScale, minScale));
        print("Scaled to" + minScale);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
