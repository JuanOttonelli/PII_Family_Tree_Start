using System;
using System.Collections.Generic;

namespace roleplay
{
    public class Arbol
    {
        public void MostrarJerarquia(Nodo nodoInicial)
        {
            // Lista para almacenar cada nivel de ancestros
            List<List<Nodo>> niveles = new List<List<Nodo>>();
            Queue<Nodo> cola = new Queue<Nodo>();
            cola.Enqueue(nodoInicial);

            // Búsqueda de amplitud desde el hijo hacia los ancestros
            while (cola.Count > 0)
            {
                List<Nodo> nivel = new List<Nodo>();
                int tamañoNivel = cola.Count;

                for (int i = 0; i < tamañoNivel; i++)
                {
                    Nodo actual = cola.Dequeue();
                    nivel.Add(actual);

                    // Agregar padres y cónyuge a la cola
                    if (actual.PadreIzquierdo != null) cola.Enqueue(actual.PadreIzquierdo);
                    if (actual.PadreDerecho != null) cola.Enqueue(actual.PadreDerecho);
                    
                    // Agregar hijos a la cola
                    foreach (var hijo in actual.Hijos)
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
                List<Nodo> nivel = niveles[i];

                // Imprimir el nivel actual con la indentación correspondiente
                Console.WriteLine(new string(' ', indentacion) + string.Join("  ", nivel.ConvertAll(n => $"{n.Nombre} ({n.Edad} años)")));

                // Agregar líneas de conexión si hay un nivel debajo
                if (i < niveles.Count - 1 && nivel.Count == 2)
                {
                    Console.WriteLine(new string(' ', indentacion) + "   \\             /");
                }
                else if (i < niveles.Count - 1 && nivel.Count == 1)
                {
                    Console.WriteLine(new string(' ', indentacion) + "    |");
                }

                // Incrementar la indentación para el siguiente nivel
                indentacion += 5;
            }
        }
    }
}
