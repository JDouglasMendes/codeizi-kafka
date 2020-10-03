using System;

namespace Codeizi.Producer.Kafka
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class TopicAttribute : Attribute
    {
        public string Topic { get; }
        public TopicAttribute(string topic)
            => Topic = topic;
    }
}