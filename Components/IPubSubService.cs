using Microsoft.AspNetCore.Components;

namespace EventsBroker.Components
{
    public interface IPubSubService
    {
        IDisposable Subscribe(EventCallback callback);
    }
}