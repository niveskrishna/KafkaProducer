using Confluent.Kafka;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace KafkaProducer
{
    public interface IProducerClass
    {
        void Produce(ClientConfig config);
    }

    public class ProducerClass : IProducerClass
    {
        String _topic;
        public ProducerClass(String topic)
        {           
           _topic=topic ;
        }
        public void Produce(ClientConfig config)
        {
            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                int numMessages = 5;
                for (int i = 0; i < numMessages; ++i)
                {
                    var key = "Key " + i;
                    var val = "Value " + i;

                    Console.WriteLine($"Producing record: {key} {val}");

                    producer.Produce(_topic, new Message<string, string> { Key = key, Value = val });
                }
            }
        }

    }
}
