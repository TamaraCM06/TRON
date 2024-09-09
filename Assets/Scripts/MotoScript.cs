using CLinkedList;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Moto {

    public class MotoScript : MonoBehaviour

    {
        public Image fuelBar;
        public float movingCost;
        public float speed = 1;
        public int stellaValue = 3;
        public int cubitoCount = 0;

        public Vector2 direction = Vector2.right;


        public MyLinkedList<UnityEngine.Transform> stella;
        public UnityEngine.Transform stellaCube;


        [SerializeField] public float fuel, maxfuel;
        public UnityEngine.Transform panell;

        private void Start()
        {
            speed = 1;
            stella = new MyLinkedList<UnityEngine.Transform>();
        }

        void Update()
        {
            Corre();

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = Vector2.right;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = Vector2.left;
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = Vector2.up;
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = Vector2.down;
                transform.rotation = Quaternion.Euler(0, 0, 270);
                stella.Ver();
            }

                
           

            fuel -= movingCost * Time.deltaTime;
            if (fuel < 0) fuel = 0;
            fuelBar.fillAmount = fuel / maxfuel;
            if (fuel == 0)
            {
                if (this.GetComponent<Collisionn>().lives == 3)
                {
                    this.GetComponent<Collisionn>().heart3.gameObject.SetActive(false);
                    this.transform.SetPositionAndRotation(new UnityEngine.Vector3(-47, -10, 0), UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0, 0, 0)));
                    this.gameObject.SetActive(true);
                    this.GetComponent<Moto.MotoScript>().direction = UnityEngine.Vector2.right;
                    this.GetComponent<Moto.MotoScript>().fuel = 100;


                    this.GetComponent<Collisionn>().lives--;
                }
                else if (this.GetComponent<Collisionn>().lives == 2)
                {
                    this.GetComponent<Collisionn>().heart2.gameObject.SetActive(false);
                    this.transform.SetPositionAndRotation(new UnityEngine.Vector3(-47, -10, 0), UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0, 0, 0)));
                    this.gameObject.SetActive(true);
                    this.GetComponent<Moto.MotoScript>().direction = UnityEngine.Vector2.right;
                    this.GetComponent<Moto.MotoScript>().fuel = 100;

                    this.GetComponent<Collisionn>().lives--;
                }
                else if (this.GetComponent<Collisionn>().lives == 1)
                {
                    this.GetComponent<Collisionn>().heart1.gameObject.SetActive(false);
                    this.GetComponent<Collisionn>().GameOverScreen.SetActive(true);

                    this.GetComponent<Collisionn>().lives--;
                }
            }
        }

        void FixedUpdate()
        {
            this.transform.position = new Vector3(
                this.transform.position.x + (direction.x / 2) * (speed / 2),
                this.transform.position.y + (direction.y / 2) * (speed / 2),
                0);
        }

        public void Corre()
        {
            if (cubitoCount != stellaValue*stellaValue)
            {

                UnityEngine.Transform cubito = Instantiate(stellaCube, panell).transform;
                cubito.position = this.transform.position - this.transform.right * 9;
                this.stella.Agregar(cubito);

                cubitoCount++;
            }
            else
            {
                stella.Borrar();
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

    }
