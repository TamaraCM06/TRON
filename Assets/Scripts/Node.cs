using UnityEditor.Experimental.GraphView;
using System;
using CLinkedList;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace CLinkedList
{
    public class Nodo<T>
    {
        public T Dato { get; set; }

        public Nodo<T> Siguiente { get; internal set; }

        public Nodo(T dato)
        {
            this.Dato = dato;
        }
    }
}
