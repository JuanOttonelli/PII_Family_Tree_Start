using System;
using Ucu.Poo.Persons;

namespace Library;

public class NombreMayorVisitor
{
    public Person HijoMayor { get; set; }
    
    public void Visit(Node<Person> node)
    {
        HijoMayor ??= new Person("","Dummy",DateOnly.FromDateTime(DateTime.Now));
        
        
        foreach (Node<Person> child in node.Children)
        {
            if (child.Value.Name.Length > HijoMayor.Name.Length)
            {
                HijoMayor = child.Value;
            }
            Visit(child);  // Recursivamente visita cada nodo
        }
    }
}