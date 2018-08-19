using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC_Layout : MonoBehaviour
{

    //public int numFloors;
    public GameObject[] floors;
    public float floorheight = 2f;

    private GameObject[] realFloors;

    // Use this for initialization
    void Start()
    {
        int numFloors = floors.Length;
        realFloors = new GameObject[numFloors];

        for (int i = 0; i < numFloors; i++)
        {
            //            GameObject floor = Instantiate(floors[Random.Range(0, floors.Length)]);
            GameObject floor = Instantiate(floors[i]);
            floor.transform.SetParent(this.transform);
            //            floor.transform.localScale = this.transform.localScale;
            var scaleFactor = 1.0f;// / 4.0f;
            floor.transform.localScale = new Vector3(this.transform.localScale.x * scaleFactor, this.transform.localScale.y * scaleFactor, this.transform.localScale.z * scaleFactor);
            floor.transform.localPosition = new Vector3(0f, floorheight * (i+1), 0f);
            floor.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            //            int numTimes = Random.Range(0, 4);
            //            for (int j = 0; j < numTimes; j++)
            //            {
            if(i %2 == 0) {
                floor.transform.Rotate(Vector3.up, 180f);
            }
            realFloors[i] = floor;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}