using RabbitMq.Domain.Models.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMq.Domain.Commands.v1.ConsultRabbitMq
{
    public class ConsultRabbitMqCommandResponse
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
