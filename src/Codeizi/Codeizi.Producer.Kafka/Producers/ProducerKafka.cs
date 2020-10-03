using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Codeizi.Producer.Kafka
{
    public class ProducerKafka : IProducerKafka
    {
        private readonly string _endpointServer;

        public ProducerKafka(string endpointServer)
            => _endpointServer = endpointServer;

        public async Task SendMessage<T>(T message) where T : class
        {
            var topicAttribute = GetTopic(message);
            await InternalSendMessage(topicAttribute.Topic, message);
        }

        public Task SendMessage<T>(params T[] messages) where T : class
        {
            CheckIfNull.Is(messages);
            Array.ForEach(messages, async (message) => await SendMessage(message));
            return Task.CompletedTask;
        }

        public async Task SendMessage<T>(string topic, T message) where T : class
            => await InternalSendMessage(topic, message);

        public Task SendMessage<T>(string topic, params T[] messages) where T : class
        {
            CheckIfNull.Is(topic);
            CheckIfNull.Is(messages);
            Array.ForEach(messages, async (message) => await SendMessage(topic, message));
            return Task.CompletedTask;
        }

        private async Task InternalSendMessage<T>(string topic, T t) where T : class
        {
            var config = new ProducerConfig { BootstrapServers = _endpointServer };
            using var producer = new ProducerBuilder<Null, string>(config).Build();
            var message = JsonConvert.SerializeObject(t);
            try
            {
                var sendResult = await producer
                                    .ProduceAsync(topic, new Message<Null, string> { Value = message });
            }
            catch (ProduceException<Null, string> e)
            {
                throw new CodeiziProducerKafkaException(e.Message, e.Source, e.StackTrace);
            }
        }

        private static TopicAttribute GetTopic<T>(T message) where T : class
        {
            var topicAttribute = message.GetType().GetCustomAttribute<TopicAttribute>(false);
            if (topicAttribute == null || string.IsNullOrEmpty(topicAttribute.Topic))
                throw new CodeiziProducerKafkaException($"The type {message.GetType().FullName} does not contain attribute {nameof(TopicAttribute)}");
            return topicAttribute;
        }
    }
}