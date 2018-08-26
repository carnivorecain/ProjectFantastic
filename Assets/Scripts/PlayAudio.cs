using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour {
    
    public string audioTriggerTag;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == audioTriggerTag) {
            AudioSource audio = this.GetComponent<AudioSource>();
            audio.Play();
        }
    }
}