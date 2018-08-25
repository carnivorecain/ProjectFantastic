using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VRGravity : MonoBehaviour {

    public float gravity = .02f;
    private float velocity = 20f;
    void Start()
    {

    }

    void Update()
    {
        //find body and feet
        GameObject[] feet = GameObject.FindGameObjectsWithTag("Foot");
        GameObject[] body = GameObject.FindGameObjectsWithTag("Body");

        //combine into one array
        GameObject[] allContacts = body.Concat(feet).ToArray();

        float minHeight = 0f;
        for(int i = 0; i < allContacts.Length; i++)
        {
            GameObject contact = allContacts[i];
            VRContactPoint point = contact.GetComponent<VRContactPoint>();
            float height = point.getHeight();
            if(minHeight == 0f || minHeight > height)
            {
                minHeight = height;
            }
        }

        // check for fall
        if (Mathf.Abs(minHeight) > 0.05f)
        {
            print("current height:" + minHeight);
            //fall
            velocity += gravity * Time.deltaTime;
            if (velocity > 10f) velocity = 10f;
            var fallDist = velocity * Time.deltaTime;
            if (Mathf.Abs(fallDist) > Mathf.Abs(minHeight))
            {
                fallDist = minHeight;
                velocity = 0f;
            }
            print("fall distance:" + fallDist);

            if (fallDist > 0f)
            {
                transform.Translate(Vector3.down * fallDist);
            }
        }
        else
        {
            velocity = 0f;
        }
        print("velocity:" + velocity);
    }
}
/*
var grounded : boolean = true; 
var jump : float = 250.0; 
    var moveSpeed : float = 10.0; 
    moveSpeed = moveSpeed/100; 
    var turnSpeed : float = 10.0; 
    turnSpeed = turnSpeed/100;
    var gravity : float = 20; 
    var playerCamera : Transform; 
    function Update() {
    transform.Rotate(Vector3(Input.GetAxis("CameraVertical") * turnSpeed, Input.GetAxis("CameraHorizontal") * turnSpeed, 0));
    if (grounded == false) { //This is where I want to apply the gravity force. 
        transform.Translate(Vector3(0, gravity*Time.deltaTime, 0));
    }
    if (grounded == true) {
        transform.Translate(Vector3(Input.GetAxis("Horizontal")*moveSpeed, 0, Input.GetAxis("Vertical")*moveSpeed));
    }
    if (Input.GetButtonDown("Jump")) {
        transform.Translate(Vector3(0, Input.GetButtonDown("Jump"), 0));
    }
}
function OnCollisionEnter (other : Collision) {
    if (other.gameObject.tag == "Ground") {
        grounded = true;
    } else {
        grounded = false;
    }
}
*/