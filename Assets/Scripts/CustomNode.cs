using UnityEngine;

public class Node<T>
{
    //propiedades
    public T value;
    public Node<T> next;
    public Node<T> prev;

    //getters
    public T Value => value;
    public Node<T> Next => next;
    public Node<T> Prev => prev;

    //Constructor
    public Node(T value)
    {
        this.value = value;
        this.next = null;
        this.prev = null;
    }
    public void SetNext(Node<T> next)
    {
        this.next = next;
    }
    public void setPrev(Node<T> prev)
    {
        this.prev = prev;
    }
}