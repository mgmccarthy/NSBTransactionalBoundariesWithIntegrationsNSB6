﻿using System;
using System.Threading.Tasks;
using NServiceBus;

namespace NSBTransactionalBoundariesWithIntegrations.ConsoleClient
{
    public static class Endpoint
    {
        public static IEndpointInstance Instance { get; private set; }

        public static async Task Init()
        {
            Console.Title = "NSBTransactionalBoundariesWithIntegrations.ConsoleClient";

            var endpointConfiguration = new EndpointConfiguration("NSBTransactionalBoundariesWithIntegrations.ConsoleClient");
            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.UseSerialization<JsonSerializer>();
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.SendOnly();

            Instance = await NServiceBus.Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
        }
    }
}
