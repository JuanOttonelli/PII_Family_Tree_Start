using System;
using System.Collections.Generic;
using Ucu.Poo.Persons;

namespace Library
{
    public class NombreMayorVisitor : IVisitor<Person>
    {
        public int EdadTotal { get; private set; } = 0;

        public Person PersonaNombreCompletoMasLargo { get; private set; }
        public List<Person> PersonasNombreCompletoMasLargo { get; private set; } = new List<Person>();

        public void Visit(Node<Person> nodoInicial)
        {
            // Inicializar con un valor por defecto para PersonaNombreCompletoMasLargo
            PersonaNombreCompletoMasLargo = new Person("P", "Dummy", new DateOnly(2022, 02, 13));

            // Usar una lista como cola para recorrer los nodos
            List<Node<Person>> cola = new List<Node<Person>>();
            cola.Add(nodoInicial);

            while (cola.Count > 0)
            {
                // Tomar el primer elemento de la cola
                List<Node<Person>> nivel = new List<Node<Person>>();
                int tamañoNivel = cola.Count;
                for (int i = 0; i < tamañoNivel; i++)
                {
                    
                    Node<Person> actual = cola[0];
                    cola.RemoveAt(0); // Eliminamos el primer elemento (simulando Dequeue)
                    nivel.Add(actual);
                    // Sumar la edad del nodo actual
                    int longitudNombreCompletoActual = actual.Value.Name.Length + actual.Value.FamilyName.Length;
                    int longitudNombreCompletoMayor = PersonaNombreCompletoMasLargo.Name.Length + PersonaNombreCompletoMasLargo.FamilyName.Length;

                    if (longitudNombreCompletoActual > longitudNombreCompletoMayor)
                    {
                        // Si encontramos un nombre más largo, actualizamos la persona y reiniciamos la lista
                        PersonaNombreCompletoMasLargo = actual.Value;
                        PersonasNombreCompletoMasLargo.Clear();
                        PersonasNombreCompletoMasLargo.Add(actual.Value);
                    }
                    else if (longitudNombreCompletoActual == longitudNombreCompletoMayor)
                    {
                        // Si encontramos otro nombre con la misma longitud máxima, lo agregamos a la lista
                        PersonasNombreCompletoMasLargo.Add(actual.Value);
                    }


                    // Agregar los padres a la lista para continuar hacia arriba
                    if (actual.PadreIzquierdo != null) cola.Add(actual.PadreIzquierdo);
                    if (actual.PadreDerecho != null) cola.Add(actual.PadreDerecho);
                }
             
            }
        }
    }
}





//public class NombreMayorVisitor :IVisitor<Person>
//{
//public Person HijoMayor { get; set; }
    
//public void Visit(Node<Person> node)
//{
//HijoMayor ??= new Person("","Dummy",DateOnly.FromDateTime(DateTime.Now));
        
        
//foreach (Node<Person> child in node.Children)
//{
//if (child.Value.Name.Length > HijoMayor.Name.Length)
//{
//HijoMayor = child.Value;
//}
//Visit(child);  // Recursivamente visita cada nodo
//}
//}
//}