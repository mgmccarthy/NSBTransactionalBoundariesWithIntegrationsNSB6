using System.Threading.Tasks;
using NSBTransactionalBoundariesWithIntegrations.Data;
using NSBTransactionalBoundariesWithIntegrations.Messages.Commands;
using NSBTransactionalBoundariesWithIntegrations.Messages.Events;
using NServiceBus;

namespace NSBTransactionalBoundariesWithIntegrations.OrderEndpoint
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public async Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            using (var dbContext = new Context())
            {
                dbContext.Order.Add(new Data.Order { OrderId = message.OrderId, ProductId = message.ProductId, CustomerId = message.CustomerId, Quantity = message.Quantity });
                await dbContext.SaveChangesAsync();
            }
            await context.Publish(new OrderPlaced { OrderId = message.OrderId, CustomerId = message.CustomerId });
        }
    }
}

