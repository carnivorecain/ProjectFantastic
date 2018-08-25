using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRContactPoint : MonoBehaviour {
    
    private RaycastHit hit;
    private GameObject root;
    void Start()
    {
        root = GameObject.FindGameObjectsWithTag("PlayerRoot")[0];
    }

    bool GetHitDistance(out float distance)
    {
        distance = 0f;
        Ray downRay = new Ray(transform.position, -Vector3.up); // this is the downward ray
        if (Physics.Raycast(downRay, out hit))
        {
            //if(hit.distance > 0.1) {
                distance = hit.distance;
            //}
            // print("distance:" + hit.distance);
            return true;
        }
        return false;
    }

    public float getRelativeHeight() {
        float rootBase = root.transform.position.y;
        return this.transform.position.y - rootBase;
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

    void Update()
    {

    }
}