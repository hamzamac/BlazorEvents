using Microsoft.AspNetCore.Components;

namespace EventsBroker.Components
{
    public class CountState: PubSubService
    {
        public Task Refresh () => PublishAsync();
    }
}
