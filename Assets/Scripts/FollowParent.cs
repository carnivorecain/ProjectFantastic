using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParent : MonoBehaviour {

    public Vector3 positionOffset = new Vector3(0f, 0f, 0f);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = positionOffset;

    }
}
