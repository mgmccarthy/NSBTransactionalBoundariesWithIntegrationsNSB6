using System;
using System.Threading.Tasks;
using NSBTransactionalBoundariesWithIntegrations.Messages.Commands;
using NServiceBus;

namespace NSBTransactionalBoundariesWithIntegrations.ConsoleClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        private static async Task AsyncMain()
        {
            await Endpoint.Init();

            Console.WriteLine("Press 'Enter' to place an Order. To exit, Ctrl + C");

            while (Console.ReadLine() != null)
            {
                await Endpoint.Instance.Send(new PlaceOrder { OrderId = Guid.NewGuid(), CustomerId = 1, ProductId = 1, Quantity = 101 });
            }
        }
    }
}
