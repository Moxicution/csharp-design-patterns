namespace DesignPatterns.Patterns.Creational
{
    using System;

    /// <summary>
    /// Frequency of use: 3/5.
    /// Short: A fully initialized instance to be copied or cloned.
    /// Description:
    /// Specify the kind of objects to create using a prototypical instance, and create new objects by copying this prototype.
    /// </summary>

    internal class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return (Person)MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person)MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
#pragma warning disable CS0618 // Type or member is obsolete
            clone.Name = string.Copy(Name);
#pragma warning restore CS0618 // Type or member is obsolete
            return clone;
        }
    }

    internal class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            IdNumber = idNumber;
        }
    }

    internal class Prototype
    {
        private static void Main()
        {
            Person p1 = new Person
            {
                Age = 29,
                BirthDate = Convert.ToDateTime("1992-12-01"),
                Name = "Carlos Schipper",
                IdInfo = new IdInfo(777)
            };

            // Shallow copy p1 -> p2.
            Person p2 = p1.ShallowCopy();

            // Deep copy of p1 -> p3.
            Person p3 = p1.DeepCopy();

            // Display values of p1, p2 and p3.
            Console.WriteLine("Original values of p1, p2, p3:");
            Console.WriteLine("   p1 instance values: ");
           
            DisplayValues(p1);

            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);

            Console.WriteLine("   p3 instance values:");
            DisplayValues(p3);

            // Change the value of p1 properties and display the values of p1,
            // p2 and p3.
            p1.Age = 30;
            p1.BirthDate = Convert.ToDateTime("1992-12-01");
            p1.Name = "Future Carlito";
            p1.IdInfo.IdNumber = 7878;

            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values (reference values have changed):");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values (everything was kept the same):");
            DisplayValues(p3);
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                p.Name, p.Age, p.BirthDate);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }
    }
}