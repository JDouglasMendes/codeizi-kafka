using System;

namespace Codeizi.Producer.Kafka
{
    public class CodeiziProducerKafkaException : Exception
    {
        public CodeiziProducerKafkaException(string message)
            : base(message)
        { }
        public CodeiziProducerKafkaException(
            string message,
            string source,
            string stackTrace) :
            base($" MESSAGE: {message} \n SOURCE: {source} \n STACKTRACE: {stackTrace}")
        { }

        public CodeiziProducerKafkaException()
        {
        }

        public CodeiziProducerKafkaException(
            string message,
            Exception innerException)
            : base(message, innerException)
        { }
    }
}