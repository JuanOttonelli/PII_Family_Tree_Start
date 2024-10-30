using System;
using Ucu.Poo.Persons;

namespace Library;

public class HijoMayorVisitor: IVisitor<Person>
{
    public Person HijoMayor { get; set; }
    
    public void Visit(Node<Person> node)
    {
        HijoMayor ??= new Person("Dummy","Dummy",DateOnly.FromDateTime(DateTime.Now));
        
        
        foreach (Node<Person> child in node.Children)
        {
            if (child.Value.Age > HijoMayor.Age)
            {
                HijoMayor = child.Value;
            }
            Visit(child);  // Recursivamente visita cada nodo
        }
    }
}