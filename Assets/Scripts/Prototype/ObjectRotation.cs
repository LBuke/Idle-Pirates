using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public GameObject[] objects;
    public float radius = 1f;
    
    public Vector3 pos_axis;
    public Vector3 rot_axis;
    public float speed;

    private bool active = false;
    private int index;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            float angle = (float) (i * Math.PI * 2f / objects.Length);
            objects[i].transform.position = new Vector3((float) (Math.Cos(angle) * radius), transform.position.y, (float) (Math.Sin(angle) * radius));
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].transform.Rotate(rot_axis, speed);
            objects[i].transform.RotateAround(transform.position, pos_axis, speed);
        }
    }
}