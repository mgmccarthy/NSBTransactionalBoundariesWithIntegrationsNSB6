using NSBTransactionalBoundariesWithIntegrations.Data;
using NServiceBus.Features;

namespace NSBTransactionalBoundariesWithIntegrations.OrderEndpoint
{
    public class EnsureTablesAreCreatedWhenConfiguringEndpoint : Feature
    {
        public EnsureTablesAreCreatedWhenConfiguringEndpoint()
        {
            using (var context = new Context())
            {
                context.Database.Initialize(false);
            }
        }

        protected override void Setup(FeatureConfigurationContext context)
        {
        }
    }
}
