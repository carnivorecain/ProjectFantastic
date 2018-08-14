using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

    private GameObject trigger;
    private float movementSpeed = 1.0f;
    private float deltaY = 0.0f;

    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }

        set
        {
            movementSpeed = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        makeCube(trigger);
    }

    private void makeCube(GameObject cube)
    {
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = this.transform.position;
        cube.transform.Translate(Vector3.up * 1);
        cube.transform.Translate(Vector3.left * 0.2f);
        cube.transform.Translate(Vector3.back * 0.4f);
        cube.transform.localScale = new Vector3(0.8f, 0.8f, 0.2f);
        Rigidbody gameObjectsRigidBody = cube.AddComponent<Rigidbody>(); // Add the rigidbody.
        gameObjectsRigidBody.mass = 0.5f; // Set the GO's mass to 5 via the Rigidbody.
        gameObjectsRigidBody.useGravity = true;
        gameObjectsRigidBody.isKinematic = false;

        trigger = cube;
    }

    // Update is called once per frame
    void Update ()
    {
        var cubeHeight = this.transform.position.y;
        var triggerHeight = trigger.transform.position.y;
        if(triggerHeight < cubeHeight)
        {
            RaiseObject();
        }
        
    }

    private void RaiseObject()
    {
        if (deltaY < 10)
        {
            transform.Translate(Vector3.up * MovementSpeed * Time.deltaTime);
            deltaY += MovementSpeed * Time.deltaTime;
        }
        else
        {
            Destroy(trigger);
            transform.Translate(Vector3.down * 10);
            deltaY = 0;
            makeCube(trigger);
        }
    }
}
