using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;

namespace ScopedVSTransient
{

    public class ScopedClass
    {
    }

    public class TransientClass
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            var collection = new ServiceCollection();
            collection.AddScoped<ScopedClass>();
            collection.AddTransient<TransientClass>();

            var builder = collection.BuildServiceProvider();

            Console.Clear();
            Parallel.For(1, 10, i => {
                Console.WriteLine($"Scoped ID = {builder.GetService<ScopedClass>().GetHashCode().ToString()}");
                Console.WriteLine($"Transient ID = {builder.GetService<TransientClass>().GetHashCode().ToString()}");
            });


            Console.WriteLine("Press a key");
            Console.ReadKey();
        }
    }
}
