using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling : MonoBehaviour {

	void Start ()
    {
        print("spawning");
        GameObject camera = GameObject.FindWithTag("MainCamera");
        float playerHeight = camera.transform.position.y;
        GameObject ceiling = Instantiate(Resources.Load("Ceiling")) as GameObject;
        ceiling.transform.parent = this.transform;
        ceiling.transform.position = this.transform.position;
        ceiling.transform.rotation = this.transform.rotation;
        float ceilingHeight = playerHeight * 0.67f + 1f; // +1 for lift height
        ceiling.transform.Translate(Vector3.up * ceilingHeight);


        print("spawned");
    }

    // Update is called once per frame
    void Update () {
		
    
	}
}
