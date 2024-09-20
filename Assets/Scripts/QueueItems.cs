using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using CLinkedList;
using System.Collections;
using UnityEngine.UI;

namespace CLinkedList
{
    public class itemQueue
    {
        public Nodo<string> firstItem { get; private set; }
        public Nodo<string> lastItem { get; private set; }

        public itemQueue()
        {
            this.firstItem = null;
            this.lastItem = null;
        }

        public bool isEmpty()
        {
            if (firstItem == null && lastItem == null)
            {
                Debug.Log("Item Queue is empty");
                return true;
            }
            else
            {
                Debug.Log("Item Queue is not empty");
                return false;
            }
        }

        public void enqueue(string item)
        {
            Nodo<string> newNode = new Nodo<string>(item);
            if (lastItem == null)
            {
                firstItem = lastItem = newNode;
            }
            lastItem.Siguiente = newNode;
            lastItem = newNode;
        }
        public void dequeue()
        {
            if (isEmpty())
            {
                Debug.Log("Queue Underflow");
            }
            firstItem = firstItem.Siguiente;
            if(firstItem == null)
            {
                lastItem= null;
            }
        }
        public string getfirstItem()
        {
            if (isEmpty() == true)
            {
                Debug.Log("Item Queue is empty");
            }
            else
            {
                Debug.Log(firstItem.Dato.ToString());
            }
            return firstItem.Dato;
        }
        public string getlastItem()
        {
            if (isEmpty())
            {
                Debug.Log("Item Queue is empty");
            }
            return lastItem.Dato;
        }
    }


}
