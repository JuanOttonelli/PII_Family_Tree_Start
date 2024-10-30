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
            Person abuelo = new Person("Kazuke", "Hyuga", new DateOnly(1943, 11, 21)); // 80 años
            Person abuela = new Person("Lucia", "Punales", new DateOnly(1946, 03, 05));  // 78 años
            Person padre = new Person("Minato", "Uzumaki", new DateOnly(1969, 09, 18)); // 55 años
            Person madre = new Person("Marcela", "Arrate", new DateOnly(1971, 01, 27)); // 53 años
            Person hijo = new Person("Naruto", "Uzumaki", new DateOnly(1994, 06, 02)); // 30 años
            Person esposaHijo = new Person("Hinata", "Hyuga", new DateOnly(1995, 12, 15)); // 28 años
            Person nieto = new Person("Manuel", "Chouhy", new DateOnly(2021, 08, 09)); // 3 años
            
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
            visitor.Visit(nietoNode);
            Console.WriteLine($"La suma de edades es: {visitor.EdadTotal}");
            
            HijoMayorVisitor visitorMayor = new HijoMayorVisitor();
            visitorMayor.Visit(abueloNode);
            Console.WriteLine($"El hijo mayor es: {visitorMayor.HijoMayor.FullName}");
            
            NombreMayorVisitor visitorNombre = new NombreMayorVisitor();
            visitorNombre.Visit(abueloNode);
            Console.WriteLine($"El hijo con el nombre más largo es: {visitorNombre.HijoMayor.FullName}");

            
            
            // Mostrar la jerarquía desde el hijo hacia arriba
            Tree tree = new Tree();
            tree.MostrarJerarquia(nietoNode);
        }
    }
}