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
        if ((this.GetComponent<Collisionn>().lives) == 0)
        {
            this.gameObject.SetActive(false);
        }
        else if (this.GetComponent<Collisionn>().GameOverScreen.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
        if (this.waiting == false)
        {
            StartCoroutine("decideDirection");
        }
    }
    IEnumerator decideDirection()
    {
        print("initial dir" + this.direction);
        this.waiting = true;
        yield return new WaitForSeconds(3);
        randomDirection(Random.value);
        print(this.direction);
        this.waiting = false;

    }

    public void randomDirection(float num)
    {
        if (this.direction == Vector2.up)
        {
            if (num > 0.00 && num < 0.50)
            {
                this.direction = Vector2.left;
            }
            else if (num>0.50 && num < 1)
            {
                this.direction = Vector2.up;
            }

        }
        if (this.direction == Vector2.right)
        {
            if (num > 0.00 && num < 0.50)
            {
                this.direction = Vector2.down;
            }
            else if (num > 0.50 && num < 1)
            {
                this.direction = Vector2.right;
            }
        }
        if (this.direction == Vector2.left)
        {
            if (num > 0.00 && num < 0.50)
            {
                this.direction = Vector2.up;
            }
            else if (num > 0.50 && num < 1)
            {
                this.direction = Vector2.left;
            }
        }
        if (this.direction == Vector2.down)
        {
            if (num > 0.00 && num < 0.50)
            {
                this.direction = Vector2.right;
            }
            else if (num > 0.50 && num < 1)
            {
                this.direction = Vector2.down;
            }
        }
    }
    new void Corre()
    {
        if (cubitoCount != stellaValue * stellaValue)   // si la estela no es del tamaño de estela, agregar uno mas
        {

            UnityEngine.Transform cubito = Instantiate(stellaCube, panell).transform;
            cubito.position = this.transform.position - this.transform.right * 9;

            cubitoCount++;
        }
        else
        {
            if (this.gameObject.activeSelf) // si es del tamaño que se espera, y la moto aun esta en pantalla, buscar cubito y eliminarlo
            {
                this.panell.GetChild(0).SetParent(this.transform);
                Destroy(this.transform.GetChild(0).gameObject);
                cubitoCount--;
            }
        }
        if ((this.direction == Vector2.right) || (this.direction == Vector2.left))
        {
            this.stellaCube.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 30);
        }
        else if ((this.direction == Vector2.up) || (this.direction == Vector2.down))
        {
            this.stellaCube.GetComponent<RectTransform>().sizeDelta = new Vector2(30, 60);
        }

    }

}
