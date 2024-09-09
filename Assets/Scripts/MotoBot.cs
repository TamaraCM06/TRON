using CLinkedList;
using Moto;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MotoBot : MotoScript
{
    bool waiting = false;
    private void Start()
    {
        speed = 0.5f;
    }
    void Update()
    {
        Corre();
        //if (waiting == false)
        //{
        //    StartCoroutine("decideDirection");
        //}
    }
    IEnumerator decideDirection()
    {
        print("initial dir" + this.direction);
        waiting = true;
        yield return new WaitForSeconds(3);
        randomDirection(Random.value);
        print(this.direction);
        waiting = false;

    }

    public void randomDirection(float num)
    {
        if (this.direction == Vector2.up)
        {
            if (num > 0.00 && num < 0.25)
            {
                this.direction = Vector2.right;
            }
            else if (num>0.25 && num < 0.50)
            {
                this.direction = Vector2.left;
            }
            else
            {
                this.direction = Vector2.up;
            }
        }
        if (this.direction == Vector2.right)
        {
            if (num > 0.00 && num < 0.25)
            {
                this.direction = Vector2.up;
            }
            else if (num > 0.25 && num < 0.50)
            {
                this.direction = Vector2.down;
            }
            else
            {
                this.direction = Vector2.right;
            }
        }
        if (this.direction == Vector2.left)
        {
            if (num > 0.00 && num < 0.25)
            {
                this.direction = Vector2.up;
            }
            else if (num > 0.25 && num < 0.50)
            {
                this.direction = Vector2.down;
            }
            else
            {
                this.direction = Vector2.left;
            }
        }
        if (this.direction == Vector2.up)
        {
            if (num > 0.00 && num < 0.25)
            {
                this.direction = Vector2.right;
            }
            else if (num > 0.25 && num < 0.50)
            {
                this.direction = Vector2.left;
            }
            else
            {
                this.direction = Vector2.down;
            }
        }
    }
    new void Corre()
    {
        if (cubitoCount != stellaValue * stellaValue)
        {

            UnityEngine.Transform cubito = Instantiate(stellaCube, panell).transform;
            cubito.position = this.transform.position - this.transform.right * 9;

            cubitoCount++;
        }
        else
        {
            panell.GetChild(1).SetParent(this.transform);
            Destroy(this.transform.GetChild(0).gameObject);
            cubitoCount--;
        }
        if ((direction == Vector2.right) || (direction == Vector2.left))
        {
            stellaCube.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 30);
        }
        else if ((direction == Vector2.up) || (direction == Vector2.down))
        {
            stellaCube.GetComponent<RectTransform>().sizeDelta = new Vector2(30, 60);
        }

    }

}
