using Client.Models;

namespace Client.Interfaces
{
    public interface IServiceBusClient
    {
        public Task SendMessage(ServiceBusClientMessage message);
        public Task SendMessageWithTimeout(ServiceBusClientMessage message, CancellationToken cancellationToken);
    }
}