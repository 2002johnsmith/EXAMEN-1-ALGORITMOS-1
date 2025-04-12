using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor.Experimental.GraphView;

namespace ListaDoble
{
    public class ListaDoblemeneteEnlazada<T> : Listadoble<T> 
    {
        public override void Añade(T value)
        {
            base.Añade(value);  
        }

        public override void MoverAdelante()
        {
            base.MoverAdelante();  
        }

        public override void MoverAtras()
        {
            base.MoverAtras();  
        }

        public virtual void Remove(T objective)
        {
            Node<T> nodeToRemove = Seek(objective);

            if (nodeToRemove == null)
            {
                Debug.Log("No se encontró el elemento para eliminar.");
                return;
            }

            if (nodeToRemove == Head)
            {
                Head = nodeToRemove.Next;
                if (Head != null)
                {
                    Head.setPrev(null);
                }
            }
            else if (nodeToRemove == lastNode)
            {
                lastNode = nodeToRemove.Prev;
                if (lastNode != null)
                {
                    lastNode.SetNext(null);
                }
            }
            else
            {
                nodeToRemove.Prev.SetNext(nodeToRemove.Next);
                nodeToRemove.Next.setPrev(nodeToRemove.Prev);
            }
            count--;
        }
        public void ResetearLista()
        {
            Head = null;
            lastNode = null;
            Peak = null;
            count = 0;
        }
        public Node<T> Seek(T objective, Node<T> _head = null, int deep = 0)
        {
            if (Head == null || deep >= count)
            {
                Debug.Log("No hay elemento en la lista o nose enconro el que buscas");
                return null;
            }
            if (_head == null) { _head = Head; }
            if (_head.Value.Equals(objective))
            {
                Debug.Log("Elemeneto encontrado: " + _head.Value.ToString());
                Debug.Log("Se encontro en la posicion: " + deep);
                return _head;
            }
            else
            {
                return Seek(objective, _head.Next, deep + 1);
            }
        }
        public virtual void ReadAllShifts(Node<T> _head = null, int deep = 0)
        {
            if (Head == null || deep >= count) return;
            if (_head == null)
            {
                _head = Head;
            }
            Debug.Log("Turno: " + deep + " " + _head.Value.ToString());
            Debug.Log("Siguiente");
            ReadAllShifts(_head.Next, deep + 1);
        }
        public void EliminarNodosDespuesDePeakRecursivo(Node<T> current)
        {
            if (current == null)
                return;  

            Node<T> next = current.next;
            current.setPrev(null);
            current.SetNext(null);
            count--;  

            EliminarNodosDespuesDePeakRecursivo(next);
        }

        public void EliminarNodosDespuesDePeak()
        {
            if (Peak == null || Peak.next == null)
                return; 

            EliminarNodosDespuesDePeakRecursivo(Peak.next);

            Peak.next = null;
            lastNode = Peak; 
        }

    }
}