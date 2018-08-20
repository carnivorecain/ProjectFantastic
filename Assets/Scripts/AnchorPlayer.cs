using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // constantly returns object to origin. Hopefully fixes headset offset bug
        this.transform.position = new Vector3(0f, transform.position.y, 0f);
	}
}
