using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTeleport : MonoBehaviour {

    private GameObject trigger;
    private GameObject player;
    private bool teleporting = false;
    private float movementSpeed = 1.0f;
    private float deltaY = 0.0f;
    public float raiseHeight = 11.0f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void makeTrigger()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.parent = this.transform;
        cube.transform.localScale = new Vector3(1f, 6f, 1f);
        cube.transform.localPosition = new Vector3(0f, 6f, 0f);
        trigger = cube;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Teleporter")
        {
            print("teleported!");
            if (!teleporting)
            {
                RaiseObject();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Teleporter")
        {
            print("teleport!");
            if (!teleporting)
            {
                RaiseObject();
            }
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Teleporter")
        {
            teleporting = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Teleporter")
        {
            teleporting = false;
        }
    }

    private void RaiseObject()
    {
        teleporting = true;
        //Vector3 pos = player.transform.position;
        //pos.y += raiseHeight;
        player.transform.Translate(new Vector3(0f, raiseHeight, 0f));
    }
}