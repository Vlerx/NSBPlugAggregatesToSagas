using System.Linq;
using System.Threading.Tasks;
using Domain;
using NServiceBus;

namespace EndPoint.NservicebusExtensions
{
    public static class NservicebusDDDExtensions
    {
        public static async Task PublishDomainEventsOf(this IPipelineContext context, AggregateRoot aggregate)
        {
            await Task.WhenAll(aggregate.NewEvents.Select(context.Publish));
            aggregate.ForgetNewEvents();
        }
    }
}