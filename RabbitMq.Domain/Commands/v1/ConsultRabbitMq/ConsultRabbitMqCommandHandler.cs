using MediatR;
using RabbitMq.Domain.Interface.Tools;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMq.Domain.Commands.v1.ConsultRabbitMq
{
    public class ConsultRabbitMqCommandHandler : IRequestHandler<ConsultRabbitMqCommand, ConsultRabbitMqCommandResponse>
    {
        private readonly IGetRabbitMq _getRabbitMq;
        public Task<ConsultRabbitMqCommandResponse> Handle(ConsultRabbitMqCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ConsultRabbitMqCommandResponse
            {
                Result = "Hello World Get"
            });
        }
    }
}
