using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Declarations : MonoBehaviour
{
    public Collisionn collisionStellaLight;

    public class Stella
    {
        public string stellaString { get; set; }

        public Stella(string strin)
        {
            strin = stellaString;
        }

    }



    public class Node
    {
        public Stella Dato { get; set; }
        public Node Siguiente { get; set; }

        public Node(Stella Dato)
        {
            this.Dato = Dato;
            this.Siguiente = null;
        }

    }
}
    public class LinkedListMoto 
    {
        private Declarations.Node head;


        public LinkedListMoto()
        {
            this.head = null;
        }
        public void AddStellaLight(Declarations.Stella newStella, Vector3 position)
        {
        Declarations.Node newNode = new Declarations.Node(newStella);

            if (this.head == null)
            {
                this.head = newNode;
                //UnityEngine.Object.Instantiate(collisionStellaLight.stellaLight, position, Quaternion.Euler(0, 0, 0)); 
            }
            else
            {
            Declarations.Node actual = head;
                while(actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = newNode;
            }
        }

        public void displayList()
        {
            if (head == null)
            {
                Debug.Log("Lista esta vacia");
            }

        Declarations.Node actual = head;

            while (actual != null)
            {
                Debug.Log(actual.Dato.ToString());
                actual = actual.Siguiente;
            }
        }
    }

