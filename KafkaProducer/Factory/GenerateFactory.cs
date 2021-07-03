using Confluent.Kafka;
using KafkaProducer.Configurations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaProducer.Factory
{
    public interface IGenerateFactory
    {
        IConfigurationRoot _Configuration { get; set; }

        ClientConfig GenerateClientConfig();
        ProducerClass GenerateProducerClass();
    }

    public class GenerateFactory : IGenerateFactory
    {
        public IConfigurationRoot _Configuration { get; set; }
        public GenerateFactory(IConfigurationRoot Configuration)
        {
            _Configuration = Configuration;
        }
        public ProducerClass GenerateProducerClass()
        {
            return new ProducerClass(RetriveConfigurations.getTopic(_Configuration));
        }

        public ClientConfig GenerateClientConfig()
        {
            ClientConfig config = new ClientConfig();
            config.BootstrapServers = RetriveConfigurations.getKafkaBroker(_Configuration);
            return config;
        }

    }
}
