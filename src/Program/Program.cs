using System;

namespace roleplay
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear nodos con nombres y edades
            Nodo abuelo = new Nodo("Abuelo", 80);
            Nodo abuela = new Nodo("Abuela", 78);
            Nodo padre = new Nodo("Padre", 55);
            Nodo madre = new Nodo("Madre", 53);
            Nodo hijo = new Nodo("Hijo", 30);
            Nodo esposaHijo = new Nodo("Esposa del Hijo", 28);
            Nodo nieto1 = new Nodo("Nieto 1", 5);
            Nodo nieto2 = new Nodo("Nieto 2", 3);

            // Construir árbol
            padre.PadreIzquierdo = abuelo;
            padre.PadreDerecho = abuela;

            hijo.PadreIzquierdo = padre;
            hijo.PadreDerecho = madre;

            // Añadir relaciones adicionales
            hijo.Hijos.Add(nieto1);
            hijo.Hijos.Add(nieto2);
            hijo.Hijos.Add(esposaHijo);

            esposaHijo.PadreDerecho = null;
            esposaHijo.PadreIzquierdo = null;
            // Mostrar la jerarquía desde el hijo hacia arriba
            Arbol arbol = new Arbol();
            arbol.MostrarJerarquia(hijo);
        }
    }
}