using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class MessWithPlayer : MonoBehaviour {

    Twirl twirl;

    float maxAngle = 30;
    bool twirling = true;
    float speed = 10f;

    float curAngle = 0f;

    // Use this for initialization
    void Start()
    {
        GameObject camera = GameObject.FindWithTag("MainCamera");
        if (camera != null) { print("Found Camera"); }
        twirl = camera.GetComponent<Twirl>();
        if (twirl != null)
        {
            print("Found Twirl");
        }
        else
        {
            twirl = camera.AddComponent<Twirl>();
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            print("P detected");
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
