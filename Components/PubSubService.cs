using Microsoft.AspNetCore.Components;

namespace EventsBroker.Components
{
    public class PubSubService : IPubSubService
    {
        private HashSet<Subscription> _subscriptions = new();

        public IDisposable Subscribe(EventCallback callback)
        {
            var subscription = new Subscription(this, callback);
            _subscriptions.Add(subscription);
            return subscription;
        }

        protected Task PublishAsync() => Task.WhenAll(_subscriptions.Select(s => s.NotifyAsync()));

        private class Subscription(PubSubService Owner, EventCallback Callback) : IDisposable
        {
            public Task NotifyAsync() => Callback.InvokeAsync();
            public void Dispose() => Owner._subscriptions.Remove(this);
        }
    }
}
