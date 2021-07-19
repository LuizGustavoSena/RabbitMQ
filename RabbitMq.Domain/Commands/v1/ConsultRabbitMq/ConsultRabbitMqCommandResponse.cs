using RabbitMq.Domain.Models.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMq.Domain.Commands.v1.ConsultRabbitMq
{
    public class ConsultRabbitMqCommandResponse
    {
        public Person Person { get; set; }
    }
}
