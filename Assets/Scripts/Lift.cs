using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

    private GameObject trigger;
    private float movementSpeed = 1.0f;
    private float deltaY = 0.0f;
    public float raiseHeight = 10.0f;

    // Use this for initialization
    void Start ()
    {
        makeTrigger();
    }

    private void makeTrigger()
    {
        //        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject cube = Instantiate(Resources.Load("Kicking Cube")) as GameObject;
        cube.transform.parent = this.transform;
        cube.transform.localScale = new Vector3(0.8f, 0.8f, 0.1f);
        cube.transform.localPosition= new Vector3(0.2f, 1.05f, 0.4f);
//        cube.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
        //cube.transform.position = this.transform.position;
        //cube.transform.Translate(Vector3.up * 1.01f);
//        cube.transform.Translate(Vector3.left * 0.2f);
//        cube.transform.Translate(Vector3.back * 0.4f);
//        Rigidbody cubeRigidBody = cube.AddComponent<Rigidbody>(); // Add the rigidbody.
        Rigidbody cubeRigidBody = cube.GetComponent<Rigidbody>(); // Add the rigidbody.
        cubeRigidBody.mass = 0.5f; // Set the GO's mass to 5 via the Rigidbody.
        cubeRigidBody.useGravity = true;
        cubeRigidBody.isKinematic = false;
        cubeRigidBody.velocity = Vector3.zero;

        trigger = cube;
    }

    // Update is called once per frame
    void Update ()
    {
        var cubeHeight = this.transform.position.y + this.transform.lossyScale.y / 2.0f;
        var triggerHeight = trigger.transform.position.y;
        if(triggerHeight < cubeHeight)
        {
            RaiseObject();
        }
        
    }

    private void RaiseObject()
    {
        if (deltaY < raiseHeight)
        {
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
            deltaY += movementSpeed * Time.deltaTime;
        }
        else
        {
            Destroy(trigger);
            transform.Translate(Vector3.down * raiseHeight);
            deltaY = 0;
            makeTrigger();
        }
    }
}
