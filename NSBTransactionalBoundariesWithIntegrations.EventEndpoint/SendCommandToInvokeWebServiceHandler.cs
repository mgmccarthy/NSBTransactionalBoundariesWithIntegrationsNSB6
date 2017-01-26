using System;
using System.Threading.Tasks;
using NSBTransactionalBoundariesWithIntegrations.Messages.Commands;
using NSBTransactionalBoundariesWithIntegrations.Messages.Events;
using NServiceBus;

namespace NSBTransactionalBoundariesWithIntegrations.EventEndpoint
{
    public class SendCommandToInvokeWebServiceHandler : IHandleMessages<OrderPlaced>
    {
        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        //public async Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            throw new Exception("the web service call failed");
            //await context .SendLocal(new InvokeWebService { OrderId = message.OrderId, CustomerId = message.CustomerId });
        }
    }
}
