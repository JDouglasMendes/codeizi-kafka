using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Codeizi.Producer.Kafka
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddProducerKafka(
            this IServiceCollection services,
            string server)
        {
            services.AddScoped(typeof(IProducerKafka), x => new ProducerKafka(server));
            return services;
        }

        /// <summary>
        /// Find Key KafkaServer in configuration
        /// When not found throws ArgumentException
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IServiceCollection AddProducerKafka(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var server = configuration.GetSection("KafkaServer")?.Value ?? throw new ArgumentException($"Not found key 'KafkaServer' in {configuration}");
            return AddProducerKafka(services, server);
        }
    }
}