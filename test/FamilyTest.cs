using NUnit.Framework;
using Library;
using Ucu.Poo.Persons;

namespace FamilyTreeTests
{
    [TestFixture]
    public class FamilyTreeTests
    {
        private Node<Person> padreNode;
        private Node<Person> madreNode;
        private Node<Person> hijoNode;
        private Node<Person> nietoNode;
        private SumaEdadVisitor sumaVisitor;
        private HijoMayorVisitor hijoMayorVisitor;
        private NombreMasLargoVisitor nombreMasLargoVisitor;

        [SetUp]
        public void Setup()
        {
            // Crear instancias de personas y nodos como en el programa principal
            var abuelo = new Person("Kazuke", "Hyuga", new DateOnly(1943, 11, 21));
            var abuela = new Person("Lucia", "Punales", new DateOnly(1946, 03, 05));
            var padre = new Person("Minato", "Uzumaki", new DateOnly(1969, 09, 18));
            var madre = new Person("Marcela", "Arrate", new DateOnly(1971, 01, 27));
            var hijo = new Person("Naruto", "Uzumaki", new DateOnly(1994, 06, 02));
            var esposaHijo = new Person("Hinata", "Hyuga", new DateOnly(1995, 12, 15));
            var nieto = new Person("Manuel", "Chouhy", new DateOnly(2021, 08, 09));

            // Crear nodos de personas
            var abueloNode = new Node<Person>(abuelo);
            var abuelaNode = new Node<Person>(abuela);
            padreNode = new Node<Person>(padre);
            madreNode = new Node<Person>(madre);
            hijoNode = new Node<Person>(hijo);
            var esposaHijoNode = new Node<Person>(esposaHijo);
            nietoNode = new Node<Person>(nieto);

            // Asignar padres
            hijoNode.PadreIzquierdo = padreNode;
            hijoNode.PadreDerecho = madreNode;

            esposaHijoNode.PadreDerecho = abueloNode;
            esposaHijoNode.PadreIzquierdo = abuelaNode;

            nietoNode.PadreDerecho = esposaHijoNode;
            nietoNode.PadreIzquierdo = hijoNode;

            // Inicializar visitantes
            sumaVisitor = new SumaEdadVisitor();
            hijoMayorVisitor = new HijoMayorVisitor();
            nombreMasLargoVisitor = new NombreMasLargoVisitor();
        }

        [Test]
        public void TestSumaEdades()
        {
            sumaVisitor.Visit(nietoNode);
            Assert.AreEqual(327, sumaVisitor.EdadTotal);
        }

        [Test]
        public void TestHijoMayor()
        {
            hijoMayorVisitor.Visit(nietoNode);
            Assert.AreEqual("Kazuke Hyuga", hijoMayorVisitor.HijoMayor.FullName);
        }

        [Test]
        public void TestNombreMasLargo()
        {
            nombreMasLargoVisitor.Visit(nietoNode);
            
            // Verificar que las tres personas con el nombre más largo están en la lista
            Assert.AreEqual(3, nombreMasLargoVisitor.PersonasNombreCompletoMasLargo.Count);
            Assert.Contains(hijoNode.Value, nombreMasLargoVisitor.PersonasNombreCompletoMasLargo);
            Assert.Contains(padreNode.Value, nombreMasLargoVisitor.PersonasNombreCompletoMasLargo);
            Assert.Contains(madreNode.Value, nombreMasLargoVisitor.PersonasNombreCompletoMasLargo);
        }
    }
}
