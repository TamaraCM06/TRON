using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using System.Threading;
using Unity.VisualScripting;
using System.Numerics;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Moto;
using CLinkedList;

namespace Moto
{


    public class Collisionn : MonoBehaviour
    {
        public Transform bombI;
        public Transform fuelI;
        public Transform stellaI;
        public Transform shieldI;
        public Transform hypervelI;
        public GameObject heart3;
        public GameObject heart2;
        public GameObject heart1;
        public GameObject GameOverScreen;
        public GameObject stellaLight;
        [SerializeField] GameObject powersBar;
        [SerializeField] GameObject shieldPrefab;
        [SerializeField] GameObject hypervelPrefab;
        public Collider2D other;
        public int lives = 3;

        public itemQueue<UnityEngine.Transform> Items;
        public powerStack<UnityEngine.Transform> Powers;
        public UnityEngine.Transform bombInstance;
        public UnityEngine.Transform fuelInstance;
        public UnityEngine.Transform stellaInstance;
        public UnityEngine.Transform shieldInstance;
        public UnityEngine.Transform hypervelInstance;


        public void OnTriggerEnter2D(Collider2D other)
        {

            //Si moto choca con map borders
            if (other is BoxCollider2D)
            {


                this.gameObject.SetActive(false);
                Debug.Log("Died");
                Debug.Log(other);

                if (lives == 3)
                {
                    heart3.gameObject.SetActive(false);
                    this.transform.SetPositionAndRotation(new UnityEngine.Vector3(-47, -10, 0), UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0, 0, 0)));
                    this.gameObject.SetActive(true);
                    this.GetComponent<Moto.MotoScript>().direction = UnityEngine.Vector2.right;
                    this.GetComponent<Moto.MotoScript>().fuel = 100;

                    lives--;
                }
                else if (lives == 2)
                {
                    heart2.gameObject.SetActive(false);
                    this.transform.SetPositionAndRotation(new UnityEngine.Vector3(-47, -10, 0), UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0, 0, 0)));
                    this.gameObject.SetActive(true);
                    this.GetComponent<Moto.MotoScript>().direction = UnityEngine.Vector2.right;
                    this.GetComponent<Moto.MotoScript>().fuel = 100;

                    lives--;
                }
                else if (lives == 1)
                {
                    heart1.gameObject.SetActive(false);
                    GameOverScreen.SetActive(true);
                    lives--;
                }

            }
            else
            {
                if (other.transform.childCount != 0)
                {
                    Debug.Log(other.transform.GetChild(0));

                    bombI = other.transform.Find("bomb(Clone)");
                    fuelI = other.transform.Find("fuel(Clone)");
                    stellaI = other.transform.Find("stella(Clone)");
                    shieldI = other.transform.Find("shield(Clone)");
                    hypervelI = other.transform.Find("hypervel(Clone)");


                    //Check if collision with a bomb / Item
                    if (bombI != null)
                    {
                        
                        Debug.Log("BombItem here");
                        //UnityEngine.Transform bomb = Instantiate(this.bombInstance, other.transform).transform;
                        //Items.enqueue(bomb);
                        //Items.getfirstItem();
                        other.transform.DetachChildren();
                        this.gameObject.SetActive(false);
                        if (lives == 3)
                        {
                            heart3.gameObject.SetActive(false);
                            this.transform.SetPositionAndRotation(new UnityEngine.Vector3(-47, -10, 0), UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0, 0, 0)));
                            this.gameObject.SetActive(true);
                            this.GetComponent<Moto.MotoScript>().direction = UnityEngine.Vector2.right;
                            this.GetComponent<Moto.MotoScript>().fuel = 100;


                            lives--;
                        }
                        else if (lives == 2)
                        {
                            heart2.gameObject.SetActive(false);
                            this.transform.SetPositionAndRotation(new UnityEngine.Vector3(-47, -10, 0), UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0, 0, 0)));
                            this.gameObject.SetActive(true);
                            this.GetComponent<Moto.MotoScript>().direction = UnityEngine.Vector2.right;
                            this.GetComponent<Moto.MotoScript>().fuel = 100;

                            lives--;
                        }
                        else if (lives == 1)
                        {
                            heart1.gameObject.SetActive(false);
                            GameOverScreen.SetActive(true);

                            lives--;
                        }
                    }
                    else if (fuelI != null)
                    {
                        Debug.Log("FuelItem here!");
                        //UnityEngine.Transform fuel = Instantiate(this.fuelInstance, other.transform).transform;
                        //Items.enqueue(fuel);
                        //Items.getfirstItem();
                        other.transform.DetachChildren();
                        this.GetComponent<Moto.MotoScript>().fuel += UnityEngine.Random.Range(10, 20);
                    }
                    else if (stellaI != null)
                    {
                        Debug.Log("StellaItem here!");
                        //UnityEngine.Transform stella = Instantiate(this.stellaInstance, other.transform).transform;
                        //Items.enqueue(stella);
                        //Items.getfirstItem();
                        other.transform.DetachChildren();
                        this.GetComponent<MotoScript>().stellaValue += UnityEngine.Random.Range(1, 10);
                        if ((this.GetComponent<MotoScript>().stellaValue + UnityEngine.Random.Range(1, 10)) >= 10)
                        {
                            this.GetComponent<MotoScript>().stellaValue = 10;
                        }
                    }
                    else if (shieldI != null)
                    {
                        StartCoroutine("Invencible"); // aplicar cuando space
                        //UnityEngine.Transform shield = Instantiate(this.shieldInstance, other.transform).transform;
                        //Powers.push(shield);
                        //Powers.peek();
                        other.transform.DetachChildren();
                        if (powersBar.transform.GetChild(4).childCount != 0)
                        {
                            if (powersBar.transform.GetChild(3).childCount != 0)
                            {
                                if (powersBar.transform.GetChild(2).childCount != 0)
                                {
                                    if (powersBar.transform.GetChild(1).childCount != 0)
                                    {
                                        if (powersBar.transform.GetChild(0).childCount != 0)
                                        {
                                            print("Power Bar full");
                                        }
                                        else
                                        {
                                            Instantiate(shieldPrefab, powersBar.transform.GetChild(0));
                                        }
                                    }
                                    else
                                    {
                                        Instantiate(shieldPrefab, powersBar.transform.GetChild(1));

                                    }
                                }
                                else
                                {
                                    Instantiate(shieldPrefab, powersBar.transform.GetChild(2));
                                }
                            }
                            else
                            {
                                Instantiate(shieldPrefab, powersBar.transform.GetChild(3));
                            }
                        }
                        else
                        {
                            Instantiate(shieldPrefab, powersBar.transform.GetChild(4));
                        }
                    }
                    else if (hypervelI != null)
                    {
                        StartCoroutine("HyperVelocity"); // aplicar cuando space esto no va aqui xd
                        //UnityEngine.Transform hypervel = Instantiate(this.hypervelInstance, other.transform).transform;
                        //Powers.push(hypervel);
                        //Powers.peek();
                        other.transform.DetachChildren();
                        if (powersBar.transform.GetChild(4).childCount != 0)
                        {
                            if (powersBar.transform.GetChild(3).childCount != 0)
                            {
                                if (powersBar.transform.GetChild(2).childCount != 0)
                                {
                                    if (powersBar.transform.GetChild(1).childCount != 0)
                                    {
                                        if (powersBar.transform.GetChild(0).childCount != 0)
                                        {
                                            print("Power Bar full");
                                        }
                                        else
                                        {
                                            Instantiate(hypervelPrefab, powersBar.transform.GetChild(0));
                                        }
                                    }
                                    else
                                    {
                                        Instantiate(hypervelPrefab, powersBar.transform.GetChild(1));

                                    }
                                }
                                else
                                {
                                    Instantiate(hypervelPrefab, powersBar.transform.GetChild(2));
                                }
                            }
                            else
                            {
                                Instantiate(hypervelPrefab, powersBar.transform.GetChild(3));
                            }
                        }
                        else
                        {
                            Instantiate(hypervelPrefab, powersBar.transform.GetChild(4));
                        }
                    }
                }
            }


        }

        IEnumerator Invencible()
        {
            Invencibilidad(true);
            yield return new WaitForSeconds(5);
            Invencibilidad(false);
        }
        IEnumerator HyperVelocity()
        {
            this.GetComponent<MotoScript>().speed += UnityEngine.Random.Range(1, 5);
            yield return new WaitForSeconds(5);
            this.GetComponent<MotoScript>().speed = 1;
        }
        void Invencibilidad(bool shield)
        {
            if (shield == true)
            {
                if (bombI != null)
                {
                    print("bombItem here - Invencible");
                }
                else if (other is BoxCollider2D)
                {
                    print("border reached - Invencible");
                }
                //stella collision
            }
        }
    }

}