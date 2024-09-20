using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Moto
{
    public class MotoBotCollision : Collisionn
    {
        public GameObject panel;
        new void OnTriggerEnter2D(Collider2D other)
        {
            if (other is BoxCollider2D)
            {
                this.gameObject.SetActive(false);
                Debug.Log("Bot died");
                Destroy(panel);
            }
        }    }
}