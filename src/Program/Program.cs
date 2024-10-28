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
            
            Person abuelo = new Person("Carlos", "Gomez", DateOnly.Parse("1945-04-10"));
            Person padre = new Person("Luis", "Gomez", DateOnly.Parse("1975-08-22"));
            Person hijo1 = new Person("Juan", "Gomez", DateOnly.Parse("2000-07-13"));
            Person hijo2 = new Person("Ana", "Gomez", DateOnly.Parse("2003-12-15"));
            Person nieto1 = new Person("Manolo", "Gomez", DateOnly.Parse("2023-11-25"));
            Person nieto2 = new Person("Juancito", "Gomez", DateOnly.Parse("2024-01-18"));
            Person nieto3 = new Person("Pepe", "Gomez", DateOnly.Parse("2022-09-10"));
            
            Node<Person> nodoAbuelo = new Node<Person>(abuelo);
            Node<Person> nodoPadre = new Node<Person>(padre);
            Node<Person> nodoHijo1 = new Node<Person>(hijo1);
            Node<Person> nodoHijo2 = new Node<Person>(hijo2);
            Node<Person> nodoNieto1 = new Node<Person>(nieto1);
            Node<Person> nodoNieto2 = new Node<Person>(nieto2);
            Node<Person> nodoNieto3 = new Node<Person>(nieto3);

            nodoAbuelo.AddChildren(nodoPadre);
            nodoPadre.AddChildren(nodoHijo1);
            nodoPadre.AddChildren(nodoHijo2);
            nodoHijo1.AddChildren(nodoNieto1);
            nodoHijo1.AddChildren(nodoNieto2);
            nodoHijo2.AddChildren(nodoNieto3);
            MostrarArbol(nodoAbuelo, "");

        }
        static void MostrarArbol(Node<Person> nodo, string indentacion)
        {
            if (nodo == null) return;
            Console.WriteLine($"{indentacion}- {nodo.Data.FullName}, {nodo.Data.Age} años");
            foreach (var hijo in nodo.Children)
            {
                MostrarArbol(hijo, indentacion + "   ");
            }
        }
    }
}