﻿using System.Collections;
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
            floor.transform.position = new Vector3(0f, floorheight * i, 0f);
            floor.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            //            int numTimes = Random.Range(0, 4);
            //            for (int j = 0; j < numTimes; j++)
            //            {
            if(i %2 == 1) {
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