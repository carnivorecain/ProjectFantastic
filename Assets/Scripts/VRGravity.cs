using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGravity : MonoBehaviour {

    public float gravity = 2f;
    private float velocity = 20f;
    private float initialDistance = 0f;
    private RaycastHit hit;
    void Start()
    {
        var dist = 0f;
        GetHitDistance(out dist);
        initialDistance = dist;
    }
    bool GetHitDistance(out float distance)
    {
        distance = 0f;
        Ray downRay = new Ray(transform.position, -Vector3.up); // this is the downward ray
        if (Physics.Raycast(downRay, out hit))
        {
            distance = hit.distance;
            print("current distance:" + distance);
            return true;
        }
        return false;
    }
    void Update()
    {
        var dist = 0f;

        // update initialDistance when player is standing upright
        if (Input.GetKeyDown(KeyCode.Return)) {
            GetHitDistance(out dist);
            initialDistance = dist;
        }

        // check for fall
        if (GetHitDistance(out dist))
        {
            var height = dist - initialDistance;
            if (height > 0)
            {
                print("current height:" + height);
                //fall
                velocity += gravity * Time.deltaTime;
                var fallDist = velocity * Time.deltaTime;
                if(fallDist > height)
                {
                    fallDist = height;
                }
                transform.Translate(Vector3.down * fallDist);
            }
            else
            {
                velocity = 0f;
            }
        }
        else
        {
            Debug.Log("Infinite Fall");
        }
    }
}