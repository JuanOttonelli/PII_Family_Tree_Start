using System;
using System.Collections.Generic;
using Ucu.Poo.Persons;

namespace Library
{
    public class Arbol
    {
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

            // Imprimir los niveles de arriba hacia abajo con indentación
            int indentacion = 0;
            for (int i = 0; i < niveles.Count; i++)
            {
                List<Node<Person>> nivel = niveles[i];

                // Imprimir el nivel actual con la indentación correspondiente
                Console.WriteLine(new string(' ', indentacion) + string.Join("   ", nivel.ConvertAll(n => $"{n.Value.Name} ({n.Value.Age} años)")));

                // Agregar líneas de conexión si hay un nivel debajo
                if (i < niveles.Count - 1 && nivel.Count == 2)
                {
                    Console.WriteLine(new string(' ', indentacion) + "          \\             /");
                }
                else if (i < niveles.Count - 1 && nivel.Count == 1)
                {
                    Console.WriteLine(new string(' ', indentacion) + "    |");
                }
                else if (i < niveles.Count - 1 && nivel.Count == 4)
                {
                    Console.WriteLine(new string(' ', indentacion) + "        \\             /                \\             /");
                }

                // Incrementar la indentación para el siguiente nivel
                indentacion += 10;
            }
        }
    }
}
