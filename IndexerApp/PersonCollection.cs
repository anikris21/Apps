using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerApp
{
    class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        private Random random = new Random();

        public Person(string name)
        {
            Name = name;
            Id = random.Next(100);
            Console.WriteLine("Id - ", Id);
        }
    }

    internal class PersonCollection<T>
    {
        private T[] array = new T[100];

        public T this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }
    }

    class PersonCollection
    {
        private Person[] people1;
        public PersonCollection(Person[] people)
        {
            people1 = new Person[people.Length];
            for (int i = 0; i < people.Length; i++)
            {
                people1[i] = people[i];
            }
        }

        public Person this[int index]
        {
            get
            {
                if(index >= people1.Length)
                {
                    throw new IndexOutOfRangeException("Index > initialized index");
                }
                return people1[index];
            }
            set { people1[index] = value; }
        }
    }
}