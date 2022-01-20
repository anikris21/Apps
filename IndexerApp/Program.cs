using IndexerApp;

namespace App
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("----------------- IndexerApp -------------------");
            PersonCollection<Person> collection = new PersonCollection<Person>();
            collection[0] = new Person("P1");
            collection[1] = new Person("P11");

            Console.WriteLine(collection[0].Name, collection[0].Id);
            Console.WriteLine(collection[1].Name, collection[1].Id);


            Person[] people = new Person[2];
            people[0] = new Person("P00");
            people[1] = new Person("P001");

            PersonCollection personCollection = new PersonCollection(people);

            try
            {
                Console.WriteLine(personCollection[2].Name, personCollection[2].Id);
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(personCollection[0].Name, personCollection[0].Id);
            Console.WriteLine(personCollection[1].Name, personCollection[1].Id);

            Console.ReadKey();
            Console.WriteLine("------------------------------------------------");
        }
    }
}