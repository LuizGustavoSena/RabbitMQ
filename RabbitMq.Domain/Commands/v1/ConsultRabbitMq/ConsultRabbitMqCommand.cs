using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMq.Domain.Commands.v1.ConsultRabbitMq
{
    public class ConsultRabbitMqCommand : IRequest<ConsultRabbitMqCommandResponse>
    {
    }
}
