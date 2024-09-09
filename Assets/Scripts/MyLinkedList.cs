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
    public class MyLinkedList<T>
    {

        public Nodo<T> Primero { get; private set; }
        public Nodo<T> Ultimo { get; private set; }
        public int size { get; private set; }


        public MyLinkedList()
        {
            this.Primero = null;
            this.Ultimo = null;
        }


        public void Agregar(T dato)
        {
            Nodo<T> newNodo = new Nodo<T>(dato);

            if (Primero == null)
            {
                Primero = newNodo;
                Ultimo = newNodo;
            }
            else
            {
                // Agregar al final de la lista
                Ultimo.Siguiente = newNodo;
                Ultimo = newNodo;
            }

            size++;
        }

        public void Borrar()
        {
            Primero = Primero.Siguiente;
            size--;
        }

        public void Ver()
        {
            Nodo<T> actual = Primero;
            while (actual != null)
            {
                Debug.Log(actual.Dato.ToString());
                actual = actual.Siguiente;
            }
        }

    }



}
    
