using System;
using System.Collections.Generic;
using Ucu.Poo.Persons;

namespace Library;
public class Visitor
{
//public class SumaEdadVisitor: IVisitor<Person>
    public void MostrarJerarquia(Node<Person> nodoInicial)
    {
        // Lista para almacenar cada nivel de ancestros
        List<List<Node<Person>>> niveles = new List<List<Node<Person>>>();
        Queue<Node<Person>> cola = new Queue<Node<Person>>();
        cola.Enqueue(nodoInicial);

        // Búsqueda de amplitud desde el hijo hacia los ancestros
        while (cola.Count > 0)
        {
            List<Node<Person>> nivel = new List<Node<Person>>();
            int tamañoNivel = cola.Count;

            for (int i = 0; i < tamañoNivel; i++)
            {
                Node<Person> actual = cola.Dequeue();
                nivel.Add(actual);

                // Agregar padres y cónyuge a la cola
                if (actual.PadreIzquierdo != null) cola.Enqueue(actual.PadreIzquierdo);
                if (actual.PadreDerecho != null) cola.Enqueue(actual.PadreDerecho);
                        
                // Agregar hijos a la cola
                foreach (var hijo in actual.Children)
                {
                    cola.Enqueue(hijo);
                }
            }

            niveles.Insert(0, nivel); // Insertar al inicio para que el nivel superior esté primero
        }
    }
}
        
    

//public int EdadTotal { get; set; }
    
//public void Visit(Node<Person> node)
//{
//EdadTotal += node.Value.Age;
        
//foreach (Node<Person> child in node.Children)
//{
//Console.WriteLine(child.Value.Age);
//Visit(child);  // Recursivamente visita cada nodo
//}
//}