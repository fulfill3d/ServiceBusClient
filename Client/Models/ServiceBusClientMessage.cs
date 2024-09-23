using System.Text;
using Azure.Messaging.ServiceBus;

namespace Client.Models
{
    public class ServiceBusClientMessage
    {
        public string Message { get; set; }
        public string QueueOrTopicName { get; set; }
        public string? SessionId { get; set; }

        public async Task SendMessage(Client.Options.ServiceBusClientOptions options)
        {
            
            await using var client = new Azure.Messaging.ServiceBus.ServiceBusClient(options.ConnectionString);

            var sender = client.CreateSender(QueueOrTopicName);

            var serviceBusMessage = CreateServiceBusMessage();

            await sender.SendMessageAsync(serviceBusMessage);
        }

        public async Task SendMessageWithTimeout(Client.Options.ServiceBusClientOptions options, CancellationToken cancellationToken)
        {
            
            await using var client = new Azure.Messaging.ServiceBus.ServiceBusClient(options.ConnectionString);

            var sender = client.CreateSender(QueueOrTopicName);

            var serviceBusMessage = CreateServiceBusMessage();

            await sender.SendMessageAsync(serviceBusMessage, cancellationToken);
        }

        private ServiceBusMessage CreateServiceBusMessage()
        {
            
            if (SessionId == null)
            {
                return new ServiceBusMessage(Encoding.UTF8.GetBytes(Message));
            }
            
            return new ServiceBusMessage(Encoding.UTF8.GetBytes(Message))
            {
                SessionId = SessionId
            };
        }
    }
}