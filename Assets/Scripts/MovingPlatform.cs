using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform targetA, targetB;
    [SerializeField] private float speed = 3.0f;

    private bool switching = false;
    void Start()
    {
        
    }

   
    void FixedUpdate()
    {
        if (switching==false)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetB.position, Time.deltaTime * speed);
        }else if (switching==true)
        {
            transform.position=Vector3.MoveTowards(transform.position,targetA.position,Time.deltaTime*speed);
        }
        
        if (transform.position==targetB.position)
        {
            switching = true;
        }else if (transform.position==targetA.position)
        {
            switching = false;
        }
    }


    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            other.transform.parent = null;
        }
    }
}
