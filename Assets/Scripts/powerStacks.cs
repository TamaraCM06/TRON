using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using CLinkedList;
using System.Collections;
using UnityEngine.UI;
using UnityEditorInternal.VersionControl;

namespace CLinkedList
{
    public class powerStack
    {
        public Nodo<string> firstPower { get; private set; }

        public powerStack()
        {
            this.firstPower = null;
        }

        public bool isEmpty()
        {
            if (firstPower == null)
            {
                Debug.Log("Power Queue is empty");
                return true;
            }
            else
            {
                Debug.Log("Power Queue is not empty");
                return false;
            }
        }

        public void push(string power)
        {
            Nodo<string> newNode = new Nodo<string>(power);
            if (newNode == null)
            {
                Debug.Log("\nStack Overflow");
            }
            newNode.Siguiente = firstPower;
            firstPower = newNode;
        }
        public void pop()
        {
            if (this.isEmpty())
            {
                Debug.Log("Stack Underflow");
            }
            else
            {
                firstPower = firstPower.Siguiente;
            }
        }
        public string peek()
        {
            if (isEmpty())
            {
                Debug.Log("Item Queue is empty");
            }
            return firstPower.Dato;
        }
    }


}
