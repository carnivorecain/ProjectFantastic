using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling : MonoBehaviour {

    public float playerHeight = 2f;

	// Use this for initialization
	void Start ()
    {

        GameObject floor = GameObject.Find("Floor");
        GameObject ceiling = Instantiate(Resources.Load("Ceiling")) as GameObject;
        ceiling.transform.position = floor.transform.position;
        ceiling.transform.rotation = floor.transform.rotation;
        float ceilingHeight = playerHeight * 0.75f + 1f; // +1 for lift height
        ceiling.transform.Translate(Vector3.up * ceilingHeight);


    }

    // Update is called once per frame
    void Update () {
		
    
	}
}
