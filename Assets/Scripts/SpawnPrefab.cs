using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour {

    public GameObject prefab;

    void Start ()
    {
        makeCube();
    }

    private void makeCube()
    {
        GameObject cube = Instantiate(prefab);
        cube.transform.parent = this.transform;
        cube.transform.position = this.transform.position;
       // cube.transform.localScale = new Vector3(1f, 1f, 1f);
        Rigidbody cubeRigidBody = cube.AddComponent<Rigidbody>(); // Add the rigidbody.
        cubeRigidBody.velocity = Vector3.zero;
        cubeRigidBody.useGravity = false;
        cubeRigidBody.isKinematic = true;
    }
    
    void Update () {
		
	}
}
