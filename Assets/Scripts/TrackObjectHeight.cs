using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObjectHeight : MonoBehaviour {

    private RaycastHit hit;
    public GameObject trackedObject;
    int groundCount = 0;
    public bool isGrounded = false;

    // Use this for initialization
    void Start () {
		
	}

    // TODO: rewrite to check for an intersection with GetHitObject
    //public bool isGrounded () {
    //    print(name + " ground count " + groundCount);
    //    return groundCount > 0;
    //}

    // Update is called once per frame
    void Update () {

        Vector3 scale = transform.localScale;
        scale.y = trackedObject.transform.localPosition.y;
        transform.localScale = scale;

        Vector3 position = transform.position;
        position.x = trackedObject.transform.position.x;
        position.y = trackedObject.transform.position.y - transform.lossyScale.y / 2f;
        position.z = trackedObject.transform.position.z;
        transform.position = position;

        transform.rotation = Quaternion.identity;
    }

    //bool GetHitFromTrackedObject(out float distance) {
    bool GetHitDistance(out float distance) {
        distance = 0f;

        // Bit shift the index of the Surface layer (9) to get a bit mask
        int layerMask = 1 << 9;
        // This would cast rays only against colliders in layer 9.

        RaycastHit hit;
        Vector3 pos = trackedObject.transform.position;
        Vector3 dir = Vector3.down;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(pos, dir, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(pos, dir * hit.distance, Color.green);
            distance = hit.distance;
            print(name + " distance: " + distance);
            return true;
        }
        else
        {
            Debug.DrawRay(pos, dir * 1000, Color.red);
            Debug.Log(name + "Did not Hit");
            return false;
        }

    }

    public GameObject GetHitObject()
    {
        // Bit shift the index of the Surface layer (9) to get a bit mask
        int layerMask = 1 << 9;
        // This would cast rays only against colliders in layer 9.

        RaycastHit hit;
        Vector3 pos = trackedObject.transform.position;
        Vector3 dir = Vector3.down;
        // Does the ray intersect any objects excluding the player layer
        //    Ray downRay = new Ray(transform.position, -Vector3.up); // this is the downward ray
        if (Physics.Raycast(pos, dir, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(pos, dir * hit.distance, Color.green);
            return hit.transform.gameObject;
        }
        else
        {
            Debug.DrawRay(pos, dir * 1000, Color.red);
            Debug.Log(name + "Did not Hit");
            return null;
        }

    }

    public float GetRelativeHeight()
    {
        return transform.position.y - transform.lossyScale.y/2f;
    }

    public float GetHeight()
    {
        var dist = 0f;
        if (GetHitDistance(out dist))
        {
            var height = dist - GetRelativeHeight();
            print("current height:" + height);
            return height;
        }
        return 1000;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            print(this.name + " collided with " + collision.gameObject.name);
            groundCount++;
            isGrounded = true;
        }
    }

    protected virtual void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            print(this.name + " exitted " + collision.gameObject.name);
            groundCount--;
            isGrounded = false;
        }
    }
}
