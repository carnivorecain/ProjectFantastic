using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToParentHeight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Transform parent = transform.parent;
        Vector3 scale = transform.localScale;
        scale.y = parent.localPosition.y / parent.lossyScale.y;
        transform.localScale = scale;
        Vector3 pos = parent.position;
        pos.y -= parent.localPosition.y/2f;
        transform.position = pos;
        transform.rotation = Quaternion.identity;
    }
}
