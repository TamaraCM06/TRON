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
        public string Dato { get; set; }
        public Nodo<string> Siguiente { get; internal set; }

        public Nodo(string dato)
        {
            this.Dato = dato;
        }
    }
}
