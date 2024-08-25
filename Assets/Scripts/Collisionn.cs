using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using System.Threading;
using Unity.VisualScripting;



public class Collisionn : MonoBehaviour
{
    public GameObject explosion;
    public Transform bomb;
    public int lives = 3;
    [SerializeField] GameObject heart3;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other is BoxCollider2D)
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.SetParent(other.transform, true);
            e.gameObject.SetActive(true);
            e.transform.position = this.transform.position;
            this.gameObject.SetActive(false);
            e.gameObject.SetActive(false);
            Debug.Log("Died");
        }
        else
        {
            if (other.transform.childCount != 0)
            {
                //Debug.Log(other.GetInstanceID());
                Debug.Log(other.transform.GetChild(0));

                bomb = other.transform.Find("bomb(Clone)");
                if (bomb != null)
                {
                    Debug.Log("Bomb here");
                    other.transform.DetachChildren();
                    this.gameObject.SetActive(false);
                    if (lives == 3)
                    {
                        heart3.gameObject.SetActive(false);
                        lives--;
                    }
                }
            }

        }

    }

} 
   
