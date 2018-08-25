using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObjectHeight : MonoBehaviour {

    public GameObject trackedObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector3 scale = transform.localScale;
        scale.y = trackedObject.transform.localPosition.y;
        transform.localScale = scale;

        Vector3 position = transform.position;
        position.x = trackedObject.transform.position.x;
        position.y = trackedObject.transform.position.y - scale.y;
        position.z = trackedObject.transform.position.z;
        transform.position = position;

        transform.rotation = Quaternion.identity;
    }
}
