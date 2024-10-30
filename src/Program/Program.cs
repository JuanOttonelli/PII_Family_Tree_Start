using System;
using System.Text.Json.Serialization;
using Library;
using Ucu.Poo.Persons;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
        
            
            // Crear personas
            Person abuelo = new Person("Kazuke", "Uzumaki", DateOnly.Parse("21/11/1943")); // 80 años
            Person abuela = new Person("Lucia", "Uzumaki", DateOnly.Parse("05/03/1946")); // 78 años
            Person padre = new Person("Minato", "Uzumaki", DateOnly.Parse("18/09/1969")); // 55 años
            Person madre = new Person("Kushina", "Uzumaki", DateOnly.Parse("27/01/1971")); // 53 años
            Person hijo = new Person("Naruto", "Uzumaki", DateOnly.Parse("02/06/1994")); // 30 años
            Person esposaHijo = new Person("Hinata", "Uzumaki", DateOnly.Parse("15/12/1995")); // 28 años
            Person nieto = new Person("Manuel", "Chouhy", DateOnly.Parse("09/08/2021")); // 3 años
            
            // Crear nodos de personas
            Node<Person> abueloNode = new Node<Person>(abuelo);
            Node<Person> abuelaNode = new Node<Person>(abuela);
            Node<Person> padreNode = new Node<Person>(padre);
            Node<Person> madreNode = new Node<Person>(madre);
            Node<Person> hijoNode = new Node<Person>(hijo);
            Node<Person> esposaHijoNode = new Node<Person>(esposaHijo);
            Node<Person> nietoNode = new Node<Person>(nieto);

            
            hijoNode.PadreIzquierdo = padreNode;
            hijoNode.PadreDerecho = madreNode;
            
            esposaHijoNode.PadreDerecho = abueloNode;
            esposaHijoNode.PadreIzquierdo = abuelaNode;

            nietoNode.PadreDerecho = esposaHijoNode;
            nietoNode.PadreIzquierdo = hijoNode;

           
            // visitar el árbol aquí
            SumaEdadVisitor visitor = new SumaEdadVisitor(); //como funcionan los nodos paralelos?
            visitor.Visit(abueloNode);
            Console.WriteLine($"La suma de edades es: {visitor.EdadTotal}");
            
            HijoMayorVisitor visitorMayor = new HijoMayorVisitor();
            visitorMayor.Visit(abueloNode);
            Console.WriteLine($"El hijo mayor es: {visitorMayor.HijoMayor.FullName}");
            
            NombreMayorVisitor visitorNombre = new NombreMayorVisitor();
            visitorNombre.Visit(abueloNode);
            Console.WriteLine($"El hijo con el nombre más largo es: {visitorNombre.HijoMayor.FullName}");

            
            
            // Mostrar la jerarquía desde el hijo hacia arriba
            Arbol arbol = new Arbol();
            arbol.MostrarJerarquia(nietoNode);
        }
    }
}