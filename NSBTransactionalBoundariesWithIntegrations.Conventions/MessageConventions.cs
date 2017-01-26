﻿using System;
using NServiceBus;

namespace NSBTransactionalBoundariesWithIntegrations.Conventions
{
    public class MessageConventions : INeedInitialization
    {
        public void Customize(EndpointConfiguration configuration)
        {
            configuration.Conventions()
                .DefiningCommandsAs(t => IsFromMessageAssembly(t) && t.Namespace.EndsWith("Commands"))
                .DefiningEventsAs(t => IsFromMessageAssembly(t) && t.Namespace.EndsWith("Events"))
                .DefiningMessagesAs(t => IsFromMessageAssembly(t) && t.Namespace.EndsWith("InternalMessages"));
        }

        private static bool IsFromMessageAssembly(Type t)
        {
            return t.Namespace != null
                && !t.Namespace.StartsWith("NServiceBus.")
                && !t.Namespace.StartsWith("System.");
        }
    }
}
