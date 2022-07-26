
namespace DesignPatterns.Patterns.Creational
{
    using System;

    /// <summary>
    /// Frequency of use: 5/5.
    /// Short: Creates an instance of several derived classes.
    /// Description:
    /// Define an interface for creating an object, but let subclasses decide which class to instantiate.
    /// Factory Method lets a class defer instantiation to subclasses.
    /// </summary>
    /// 

    public interface IProduct
    {
        string Operation();
    }

    internal class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct1}";
        }
    }

    internal class ConcreteProduct2 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct2}";
        }
    }

    internal abstract class Creator
    {
        public abstract IProduct FactoryMethod();

        public string SomeOperation()
        {
            // Call the factory method to create a Product object.
            IProduct product = FactoryMethod();
            // Now, use the product.
            string result = "Creator: The same creator's code has just worked with "
                + product.Operation();

            return result;
        }
    }

    internal class ConcreteCreator1 : Creator
    {

        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    internal class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }

    internal class Client
    {
        public void Main()
        {
            Console.WriteLine("App: Launched with the ConcreteCreator1.");
            ClientCode(new ConcreteCreator1());

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the ConcreteCreator2.");
            ClientCode(new ConcreteCreator2());
        }

        public void ClientCode(Creator creator)
        {
            Console.WriteLine("Client: I'm not aware of the creator's class," +
                "but it still works.\n" + creator.SomeOperation());
        }
    }

    internal class FactoryMethod
    {
        private static void Main()
        {
            new Client().Main();
        }
    }
}