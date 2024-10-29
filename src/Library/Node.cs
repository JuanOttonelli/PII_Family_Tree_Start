using System.Collections.Generic;

namespace roleplay
{
    public class Nodo
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public Nodo PadreIzquierdo { get; set; }
        public Nodo PadreDerecho { get; set; }
        public List<Nodo> Hijos { get; set; } = new List<Nodo>();

        public Nodo(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
        }
    }
}