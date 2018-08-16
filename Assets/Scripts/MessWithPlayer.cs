using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class MessWithPlayer : MonoBehaviour {

    Twirl twirl;

    float maxAngle = 30;
    bool twirling = false;
    float speed = 10f;

    float curAngle = 0f;

	// Use this for initialization
	void Start () {
        twirl = GetComponent<Twirl>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            twirling = !twirling;
        }

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
}
