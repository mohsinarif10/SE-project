using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace masood_lab.AbstractFactory
{
    

    public interface IAbstractFactory
    {
        ITextBooks CreateTextBooks();

        IRefrenceBooks CreateRefrenceBooks();
    }

    
    class EngineeringFactory : IAbstractFactory
    {
        public ITextBooks CreateTextBooks()
        {
            return new EngineeringTextBooks();
        }

        public IRefrenceBooks CreateRefrenceBooks()
        {
            return new EngineeringREfrenceBooks();
        }
    }

    class CSFactory : IAbstractFactory
    {
        public ITextBooks CreateTextBooks()
        {
            return new CSTextBooks();
        }

        public IRefrenceBooks CreateRefrenceBooks()
        {
            return new CSRefrenceBooks();
        }
    }

    
    public interface ITextBooks
    {
        string UsefulFunctionA();
    }

    class EngineeringTextBooks : ITextBooks
    {
        public string UsefulFunctionA()
        {
            return "The result of the product A1.";
        }
    }

    class CSTextBooks : ITextBooks
    {
        public string UsefulFunctionA()
        {
            return "The result of the product A2.";
        }
    }

    
    public interface IRefrenceBooks
    {
        string UsefulFunctionB();

       
        string AnotherUsefulFunctionB(ITextBooks collaborator);
    }

    class EngineeringREfrenceBooks : IRefrenceBooks
    {
        public string UsefulFunctionB()
        {
            return "The result of the product B1.";
        }

      
        public string AnotherUsefulFunctionB(ITextBooks collaborator)
        {
            var result = collaborator.UsefulFunctionA();

            return $"The result of the B1 collaborating with the ({result})";
        }
    }

    class CSRefrenceBooks : IRefrenceBooks
    {
        public string UsefulFunctionB()
        {
            return "The result of the product B2.";
        }

       
        public string AnotherUsefulFunctionB(ITextBooks collaborator)
        {
            var result = collaborator.UsefulFunctionA();

            return $"The result of the B2 collaborating with the ({result})";
        }
    }

    class Client
    {
        public void Main()
        {
            // The client code can work with any concrete factory class.
            Console.WriteLine("Client: Testing client code with the first factory type...");
            ClientMethod(new EngineeringFactory());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the second factory type...");
            ClientMethod(new CSFactory());
        }

        public void ClientMethod(IAbstractFactory factory)
        {
            var productA = factory.CreateTextBooks();
            var productB = factory.CreateRefrenceBooks();

            Console.WriteLine(productB.UsefulFunctionB());
            Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
        }
    }


}