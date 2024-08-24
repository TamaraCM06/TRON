using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using System.Threading;



public class Collisionn : MonoBehaviour
{
    public GameObject explosion;


    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject e = Instantiate(explosion) as GameObject;
        e.transform.SetParent(other.transform, true);
        e.gameObject.SetActive(true);
        e.transform.position = this.transform.position;
        this.gameObject.SetActive(false);
        afterTrigger();


        void afterTrigger()
        {
            Thread.Sleep(3000);
            e.gameObject.SetActive(false);
        }
    }

} 
   
