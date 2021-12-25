using System;
using Microsoft.Extensions.DependencyInjection;

namespace Coupling
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IDataAccess, DataAccess>();
            collection.AddScoped<IBusiness, BusinessV2>();
            
            var provider = collection.BuildServiceProvider();

            IBusiness biz = provider.GetService<IBusiness>();

            var uerInterface = new UserInterface(biz);
            
        }
    }

    public class UserInterface
    {
        private readonly IBusiness _business;
        public UserInterface(IBusiness business)
        {
            _business = business;
        }
        public void GetData()
        {
            Console.Write("Enter your username:");
            var userName = Console.ReadLine();

            Console.Write("Enter your password");
            var password = Console.ReadLine();
            _business.SignUp(userName, password);    
        }
    }

    public class Business : IBusiness
    {
        private readonly IDataAccess _dataAccess;
        public Business(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public void SignUp(string userName, string password)
        {
            // validation
            _dataAccess.Store(userName, password);
        }
    }


    public class BusinessV2 : IBusiness
    {
        private readonly IDataAccess _dataAccess;
        public BusinessV2(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public void SignUp(string userName, string password)
        {
            //
        }
    }
    public class DataAccess : IDataAccess
    {
        public void Store(string userName, string password)
        {
            // write the data to the db
        }
    }

    public interface IBusiness
    {
        void SignUp(string userName, string password);
    }

    public interface IDataAccess
    {
        void Store(string userName, string password);
    }
}
