using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class TwirlOnCollision : MonoBehaviour {

    Twirl twirl;
    float maxAngle = 30;
    bool twirling = false;
    float speed = 10f;
    float curAngle = 0f;

    // Use this for initialization
    void Start () {
        GameObject camera = GameObject.FindWithTag("MainCamera");
        twirl = camera.GetComponent<Twirl>();
	}
	
	// Update is called once per frame
	void Update () {
        if (twirling)
        {
            curAngle = curAngle += maxAngle * Time.deltaTime * speed;
        }
        else
        {
            curAngle = 0f;
        }
        twirl.angle = curAngle;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CauseTwirl") {
            print("Twirlin");
            twirling = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "CauseTwirl") {
            twirling = false;
        }
    }


}
