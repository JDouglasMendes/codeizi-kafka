using Codeizi.Producer.Kafka;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Codeizi.Producer.Functional.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerKafka producer;

        public ProducerController(IProducerKafka producer)
            => this.producer = producer;

        [HttpPost]
        public async Task<IActionResult> PostAsync(string message)
        {
            await producer.SendMessage("Topic_Test", new { Message = message });
            return Ok();
        }
    }
}