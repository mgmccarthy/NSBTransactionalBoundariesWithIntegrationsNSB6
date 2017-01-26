using System;
using System.Threading.Tasks;
using NSBTransactionalBoundariesWithIntegrations.Messages.Commands;
using NServiceBus;

namespace NSBTransactionalBoundariesWithIntegrations.EventEndpoint
{
    public class InvokeWebServiceHandler : IHandleMessages<InvokeWebService>
    {
        public Task Handle(InvokeWebService message, IMessageHandlerContext context)
        {
            throw new Exception("the web service call failed");
        }
    }
}
