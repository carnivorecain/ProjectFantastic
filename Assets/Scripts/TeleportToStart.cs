using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToStart : MonoBehaviour {

    Vector3 SpawnPosition;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("key was pressed");
            Respawn();
        }
    }

    public void Respawn()
    {
        GameObject spawn = GameObject.Find("PlayerSpawn");
        this.transform.position = spawn.transform.position;
    }
}
