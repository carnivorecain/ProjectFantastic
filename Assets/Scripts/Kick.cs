using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision other)
    {
        GameObject trigger = other.gameObject;
        if (trigger.tag == "Kickable")
        {
            print("Take that!");
            Rigidbody rigidbody = trigger.GetComponent<Rigidbody>();
            Vector3 kickDir = trigger.transform.position - this.transform.position;
            rigidbody.AddForce(kickDir  * 1000f);
            GameObject king = GameObject.FindGameObjectWithTag("GoblinKing");
            Animator animator = king.GetComponent<Animator>();
        }
    }
}
