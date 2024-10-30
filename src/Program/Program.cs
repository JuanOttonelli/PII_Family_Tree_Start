using System;

namespace roleplay
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear nodos con nombres y edades
            Nodo abuelo = new Nodo("Kazuke", 80);
            Nodo abuela = new Nodo("Lucia", 78);
            Nodo padre = new Nodo("Minato", 55);
            Nodo madre = new Nodo("Kushina", 53);
            Nodo hijo = new Nodo("Naruto", 30);
            Nodo esposaHijo = new Nodo("Hinata", 28);
            Nodo nieto = new Nodo("Manuel", 3);

            // Construir árbol
            padre.PadreIzquierdo = null;
            padre.PadreDerecho = null;

            hijo.PadreIzquierdo = padre;
            hijo.PadreDerecho = madre;
            
            esposaHijo.PadreDerecho = abuelo;
            esposaHijo.PadreIzquierdo = abuela;

            nieto.PadreDerecho = esposaHijo;
            nieto.PadreIzquierdo = hijo;
            
            // Mostrar la jerarquía desde el hijo hacia arriba
            Arbol arbol = new Arbol();
            arbol.MostrarJerarquia(nieto);
        }
    }
}