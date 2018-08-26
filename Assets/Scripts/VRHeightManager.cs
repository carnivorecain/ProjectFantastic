using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VRHeightManager : MonoBehaviour {

    public float gravity = -.02f;
    private float velocity = 0f;
    void Start()
    {

    }

    void Update()
    {
        if (IsGrounded())
        {
            GameObject surface = GetSurfaceObject();
            if (surface.transform.position.y > transform.position.y)
            {
                velocity = 1f;
            }
        }
        else
        {
            ApplyGravity();
        }

        CalculateMovement();
    }

    //bool Intersects(Bounds bounds)
    //{
    //    overlapping = collider.bounds.Intersects(bounds);
    //    return overlapping;
    //}

    bool IsGrounded()
    {



        GameObject[] headsets = GameObject.FindGameObjectsWithTag("HeadsetTracker");
        GameObject[] controllers = GameObject.FindGameObjectsWithTag("ControllerTracker");

        //combine into one array 
        GameObject[] heightTrackers = headsets.Concat(controllers).ToArray();

        for (int i = 0; i < heightTrackers.Length; i++)
        {
            GameObject heightTracker = heightTrackers[i];
            TrackObjectHeight tracker = heightTracker.GetComponent<TrackObjectHeight>();
            if (tracker != null && tracker.isGrounded)
            {
                print(heightTracker.name + " is grounded");
                return true;
            }
        }

        return false;
    }

    GameObject GetSurfaceObject()
    {
        //find body and feet 
        GameObject headset = GameObject.FindGameObjectsWithTag("HeadsetTracker")[0];
        TrackObjectHeight tracker = headset.GetComponent<TrackObjectHeight>();
        GameObject surface = tracker.GetHitObject();
        
        return surface;
    }

    //Bounds AllBounds()
    //{
    //    this.transform.bou
    //    Bounds bounds = renderer.bounds;
    //    foreach (var r in GetComponentsInChildren<Renderer>())
    //    {
    //        bounds.Encapsulate(r.bounds);
    //    }
    //    return bounds
    //}

    void ApplyGravity()
    {
        velocity += gravity * Time.deltaTime;

        // cap at a terminal velocity
        if (velocity > 10f) velocity = 10f;
    }

    void CalculateMovement()
    {
        print("velocity:" + velocity);
        if (Mathf.Abs(velocity) > 0.01f)
        {
            var fallDist = velocity * Time.deltaTime;
            transform.Translate(Vector3.up * fallDist);
        }
    }
}