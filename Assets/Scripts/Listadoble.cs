using UnityEngine;

namespace ListaDoble
{
    public abstract class Listadoble<T> : MonoBehaviour
    {
        public Node<T> lastNode;
        public Node<T> Head;
        public Node<T> Peak;
        public int count = 0;

        public virtual void Añade(T value)
        {
            Node<T> Newnode = new Node<T>(value);
            count++;

            if (Head == null)
            {
                lastNode = Newnode;
                Head = Newnode;
                Peak = Head;
                return;
            }

            lastNode.SetNext(Newnode);
            Newnode.setPrev(lastNode);
            lastNode = Newnode;
            Peak.SetNext(Newnode);
            Newnode.setPrev(Peak);
            Peak= Newnode;
        }

        public virtual void MoverAdelante()
        {
            if (Peak != null && Peak.next != null)
            {
                Peak = Peak.next;
                Debug.Log("Moviste al turno: " + Peak.value);
            }
            else
            {
                Debug.Log("No hay mas nodos.");
            }
        }

        public virtual void MoverAtras()
        {
            if (Peak != null && Peak.prev != null)
            {
                Peak = Peak.prev;
                Debug.Log("Moviste al turno: " + Peak.value);
            }
            else
            {
                Debug.Log("No hay mas nodos.");
            }
        }
    }
}
