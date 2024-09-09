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
    public class itemQueue<T>
    {
        public Nodo<T> firstItem { get; private set; }
        public Nodo<T> lastItem { get; private set; }

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

        public void enqueue(T item)
        {
            Nodo<T> newNode = new Nodo<T>(item);
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
        public T getfirstItem()
        {
            if (isEmpty())
            {
                Debug.Log("Item Queue is empty");
            }
            return firstItem.Dato;
        }
        public T getlastItem()
        {
            if (isEmpty())
            {
                Debug.Log("Item Queue is empty");
            }
            return lastItem.Dato;
        }
    }


}
