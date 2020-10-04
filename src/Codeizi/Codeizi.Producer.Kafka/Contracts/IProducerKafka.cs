using System.Threading.Tasks;

namespace Codeizi.Producer.Kafka
{
    public interface IProducerKafka
    {
        Task SendMessage<T>(T message) where T : class;
        Task SendMessage<T>(params T[] messages) where T : class;
        Task SendMessage<T>(string topic, T message) where T : class;
        Task SendMessage<T>(string topic, params T[] messages) where T : class;
    }
}