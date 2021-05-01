namespace DesignPatterns.Patterns.Creational
{
    using System;
    /// <summary>
    /// Frequency of use: 5/5.
    /// Short: Creates an instance of several families of classes.
    /// Description: 
    /// Provide an interface for creating families of related or dependent objects without specifying their concrete classes.
    /// </summary>
   
    interface IPackageFactory
    {
        IColor GetColor();
        ISize GetSize();
    }

    class SantasHouse : IPackageFactory
    {
        public IColor GetColor()
        {
            return new Red();
        }

        public ISize GetSize()
        {
            return new Small();
        }
    }

    class GrandmasHouse : IPackageFactory
    {
        public IColor GetColor()
        {
            return new Green();
        }

        public ISize GetSize()
        {
            return new Large();
        }
    }

    internal class Red : IColor
    {
        public string GetColor()
        {
            return "I'm Red!";
        }
    }

    internal class Green : IColor
    {
        public string GetColor()
        {
            return "I'm Green!";
        }
    }

    internal class Small : ISize
    {
        public string GetSize()
        {
            return "I'm a small package!";
        }
    }

    internal class Large : ISize
    {
        public string GetSize()
        {
            return "I'm a large package!";
        }
    }

    internal interface ISize
    {
        string GetSize();
    }

    internal interface IColor
    {
        string GetColor();
    }

    class PresentDistributer
    {
        internal IPackageFactory PackageFactory { get; set; }

        public void CreatePackageWithColor(string from)
        {
            if (from.ToLower() == "santa")
            {
                PackageFactory = new SantasHouse();
                Console.WriteLine($"I have a {PackageFactory.GetSize()} package for you in {PackageFactory.GetColor()}!");

            }
            else if (from.ToLower() == "grandma")
            {
                PackageFactory = new GrandmasHouse();
                Console.WriteLine($"I have a {PackageFactory.GetSize()} package for you in {PackageFactory.GetColor()}!");
            }
        }
    }

    internal class AbstractFactory
    {
        static void Main()
        {
            Console.Write("**** Welcome to Abstract Factory pattern *******\n Let's first go to Santa for a present and then go to grandma.");
            PresentDistributer rudolph = new PresentDistributer();
            rudolph.CreatePackageWithColor("santa");
            rudolph.CreatePackageWithColor("grandma");
            Console.ReadLine();
        } 
    }
}