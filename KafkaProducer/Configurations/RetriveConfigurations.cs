using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaProducer.Configurations
{

    public class RetriveConfigurations 
    {
        public static string getTopic(IConfigurationRoot Configuration)
        {
            return Configuration.GetSection("topic").Value;
        }

        public static string getKafkaBroker(IConfigurationRoot Configuration)
        {
            return Configuration.GetSection("BootstrapServers").Value;
        }
    }
}
