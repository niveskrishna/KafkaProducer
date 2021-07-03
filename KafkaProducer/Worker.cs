using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using KafkaProducer.Configurations;
using KafkaProducer.Factory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KafkaProducer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public IConfigurationRoot Configuration { get; set; }
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
          var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
          Configuration = builder.Build();
          GenerateFactory generateFactory = new GenerateFactory(Configuration);
          ProducerClass producerClass = generateFactory.GenerateProducerClass();
          ClientConfig clientConfig = generateFactory.GenerateClientConfig();
          producerClass.Produce(clientConfig);
        }
    }
}
