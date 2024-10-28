//-------------------------------------------------------------------------
// <copyright file="Person.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------
using System;

namespace Ucu.Poo.Persons
{
    /// <summary>
    /// Esta clase representa una persona con clase y apellido.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Person"/> con el nombre y apellidos recibidos como argumento.
        /// </summary>
        /// <param name="name">El nombre de la persona.</param>
        /// <param name="familyName">El apellido de la persona.</param>
        public Person(string name, string familyName, DateOnly birthDate)
        {
            this.Name = name;
            this.FamilyName = familyName;
            this.BirthDate = birthDate;
        }

        /// <summary>
        /// Obtiene o establece el nombre de la persona. El texto no tiene espacios al comienzo ni al final -los espacios son removidos al asignar el texto-.
        /// </summary>
        /// <value>El nombre de la persona.</value>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido de la persona. El texto no tiene espacios al comienzo ni al final -los espacios son removidos al asignar el texto-.
        /// </summary>
        /// <value>El apellido de la persona.</value>
        public string FamilyName { get; set; }

        /// <summary>
        ///  Obtiene el nombre completo de la persona concatenando el nombre y el apellido.
        /// </summary>
        public string FullName
        {
            get
            {
                return $"{this.Name+" "+this.FamilyName}";
            }
        }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento de la persona.
        /// </summary>
        public DateOnly BirthDate { get; set; }

        /// <summary>
        /// Obtiene la edad de la persona al día de hoy.
        /// </summary>
        public int Age
        {
            get
            {
                
                DateTime today = DateTime.Today;
                int age =  today.Year - this.BirthDate.Year ;
                if (today.Month < this.BirthDate.Month || (today.Month == this.BirthDate.Month && today.Day < this.BirthDate.Day))
                {
                    age -= 1;
                    return age;
                }

                return age;
            }
        }

        /// <summary>
        /// Esta persona se presenta con otra.
        /// </summary>
        /// <param name="person">La persona a la cual presentarse.</param>
        public void IntroduceTo(Person person)
        {
            if (person != null)
            {
                Console.WriteLine($"Hola, {person.Name}, mi nombre es {this.Name}");
            }
        }

    
        /// <summary>
        /// Compara dos objetos para determinar si son iguales.
        /// </summary>
        /// <param name="a">Uno de los objetos a comparar.</param>
        /// <param name="b">El otro objeto a comparar.</param>
        /// <returns><c>True</c> si el primer objeto es igual al segundo; <c>False</c> en caso contrario.</returns>
        public static bool operator == (Person a, Person b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compara dos objetos para determinar si son diferentes.
        /// </summary>
        /// <param name="a">Uno de los objetos a comparar.</param>
        /// <param name="b">El otro objeto a comparar.</param>
        /// <returns><c>True</c> si el primer objeto no es igual al segundo; <c>False</c> en caso contrario.</returns>
        public static bool operator != (Person a, Person b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// Determina cuándo esta persona es igual a otra que se recibe como parámetro.
        /// </summary>
        /// <param name="obj">El objeto a comparar.</param>
        /// <returns><c>True</c> si este objeto es igual al que se recibe como parámetro; <c>False</c> en caso
        /// contrario.</returns>
        public override bool Equals(object obj)
        {
            // Si el otro objeto es null no puede ser igual a este objeto que no es null; retornar False
            if (obj == null)
            {
                return false;
            }
            // Si el otro objeto no es del mismo tipo que este objeto no pueden ser iguales; retornar False
            else if  (!this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            // Retornar True si el otro objeto tiene el mismo texto que este objeto; y False en caso contrario
            else
            {
                return this.FullName.Equals(((Person)obj).FullName);
            }
        }

        /// <summary>
        /// Genera un código hash para este objeto.
        /// </summary>
        /// <returns>El código hash generado.</returns>
        public override int GetHashCode()
        {
            return this.FullName.GetHashCode();
        }
    
    }
}
