using System;
using Ucu.Poo.Persons;

namespace Library;

public class SumaEdadVisitor: IVisitor<Person>
{
    public int EdadTotal { get; set; }
    
    public void Visit(Node<Person> node)
    {
        EdadTotal += node.Value.Age;
        
        foreach (Node<Person> child in node.Children)
        {
            Console.WriteLine(child.Value.Age);
            Visit(child);  // Recursivamente visita cada nodo
        }
    }
    
}