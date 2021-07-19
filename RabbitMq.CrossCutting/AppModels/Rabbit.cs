using RabbitMQ.Client;
using System.Collections.Generic;

namespace RabbitMq.CrossCutting.AppModels
{
    public class Rabbit
    {
        public string ServerName { get; set; }
        public string queue { get; set; }
        public bool durable { get; set; }
        public bool exclusive { get; set; }
        public bool autoDelete { get; set; }
        public IDictionary<string, object> arguments { get; set; }
        public string exchange { get; set; }
        public string routingKey { get; set; }
        public IBasicProperties basicProperties { get; set; }
        public bool autoAck { get; set; }
    }
}
