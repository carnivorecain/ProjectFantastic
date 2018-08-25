using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObjectHeight : MonoBehaviour {

    private RaycastHit hit;
    public GameObject trackedObject;
    int groundCount = 0;

	// Use this for initialization
	void Start () {
		
	}

    public bool isGrounded () {
        print(name + " ground count " + groundCount);
        return groundCount > 0;
    }

    // Update is called once per frame
    void Update () {
        
        Vector3 scale = transform.localScale;
        scale.y = trackedObject.transform.localPosition.y;
        transform.localScale = scale;

        Vector3 position = transform.position;
        position.x = trackedObject.transform.position.x;
        position.y = trackedObject.transform.position.y - scale.y;
        position.z = trackedObject.transform.position.z;
        transform.position = position;

        transform.rotation = Quaternion.identity;
    }

    bool GetHitDistance(out float distance)
    {
        distance = 0f;
        Ray downRay = new Ray(transform.position, -Vector3.up); // this is the downward ray
        if (Physics.Raycast(downRay, out hit))
        {
            distance = hit.distance;
            // print("distance:" + distance);
            return true;
        }
        return false;
    }

    public float getRelativeHeight()
    {
        return transform.position.y - transform.lossyScale.y/2f;
    }

    public float getHeight()
    {
        var dist = 0f;
        if (GetHitDistance(out dist))
        {
            var height = dist - getRelativeHeight();
            print("current height:" + height);
            return height;
        }
        return 1000;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "CauseTwirl")
        {
            print(this.name + " collided with " + collision.gameObject.name);
            groundCount++;
        }
    }

    protected virtual void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "CauseTwirl")
        {
            print(this.name + " exitted " + collision.gameObject.name);
            groundCount--;
        }
    }
}
