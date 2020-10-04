using Codeizi.Producer.Kafka;

namespace Codeizi.Producer.Functional.Test.ViewModels
{
    [Topic("Topic_Test")]
    public class MessageViewModel
    {
        public string Message { get; set; }
    }
}