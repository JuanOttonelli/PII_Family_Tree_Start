using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    // La clase Node representa un nodo en un árbol genérico, donde cada nodo puede contener cualquier tipo de datos.
    public class Node<T>
    {
        // Campo privado que almacena el dato del nodo de tipo genérico T.
        private T data;
        
        // Lista privada que contiene los nodos hijos de este nodo.
        private List<Node<T>> children = new List<Node<T>>();

        // Propiedad que devuelve el dato almacenado en el nodo. Es de solo lectura.
        public T Data
        {
            get { return this.data; }
        }

        // Propiedad que devuelve una colección de solo lectura de los nodos hijos.
        public ReadOnlyCollection<Node<T>> Children
        {
            get { return this.children.AsReadOnly(); }
        }

        // Constructor que inicializa el nodo con el dato proporcionado como argumento.
        public Node(T data)
        {
            this.data = data; // Asigna el dato al campo data del nodo.
        }

        // Método que agrega un nodo hijo a la lista de hijos del nodo actual.
        public void AddChildren(Node<T> child)
        {
            this.children.Add(child); // Añade el nodo hijo a la lista de hijos.
        }
    }
}
//La T en la clase Node<T> indica un parámetro de tipo genérico,
//lo que permite que el tipo de datos almacenado en el nodo sea definido cuando se instancia la clase.
//Por ejemplo, Node<int> crea un nodo que almacena enteros, mientras que Node<Person> almacena objetos Person.
//La ventaja de usar T es que hace la clase más flexible,
//ya que puede usarse con cualquier tipo sin necesidad de escribir una implementación específica para cada uno.






