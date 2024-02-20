using Microsoft.AspNetCore.Components;

namespace EventsBroker.Components
{
    public class CountState
    {

        private HashSet<CountStateChangedSubscription> _changeSubscriptions = new();

        public IDisposable Subscribe(EventCallback callback)
        {
            var subscription =new  CountStateChangedSubscription(this, callback);
            _changeSubscriptions.Add(subscription);
            return subscription;
        }

        private Task PublishAsync() => Task.WhenAll(_changeSubscriptions.Select(s => s.NotifyAsync()));

        public Task Refresh () => PublishAsync();

        private class CountStateChangedSubscription(CountState Owner, EventCallback Callback) : IDisposable
        {
            public Task NotifyAsync() => Callback.InvokeAsync();
            public void Dispose() => Owner._changeSubscriptions.Remove(this);
        }
    }
}
