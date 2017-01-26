using System.Data.Entity;
using System.Threading.Tasks;
using NSBTransactionalBoundariesWithIntegrations.Data;
using NSBTransactionalBoundariesWithIntegrations.Messages.Events;
using NServiceBus;

namespace NSBTransactionalBoundariesWithIntegrations.EventEndpoint
{
    public class ChangeCustomerPreferredStatusHandler : IHandleMessages<OrderPlaced>
    {
        public async Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            using (var dbContext = new Context())
            {
                var customerPreferred = await dbContext.CustomerPreferred.SingleOrDefaultAsync(x => x.CustomerId == message.CustomerId);
                if (customerPreferred != null)
                {
                    return;
                }

                if (message.CustomerId == 1)
                {
                    dbContext.CustomerPreferred.Add(new CustomerPreferred { CustomerId = message.CustomerId, IsPreferred = true });
                }
                
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
