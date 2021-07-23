using AutoMapper;
using MediatR;
using RabbitMq.Domain.Interface.Tools;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMq.Domain.Commands.v1.ConsultRabbitMq
{
    public class ConsultRabbitMqCommandHandler : IRequestHandler<ConsultRabbitMqCommand, ConsultRabbitMqCommandResponse>
    {
        private readonly IGetRabbitMq _getRabbitMq;
        private readonly IMapper _mapper;

        public ConsultRabbitMqCommandHandler(IGetRabbitMq getRabbitMq, IMapper mapper)
        {
            _getRabbitMq = getRabbitMq;
            _mapper = mapper;
        }

        public Task<ConsultRabbitMqCommandResponse> Handle(ConsultRabbitMqCommand request, CancellationToken cancellationToken)
        {
            ConsultRabbitMqCommandResponse response = _mapper.Map<ConsultRabbitMqCommandResponse>(_getRabbitMq.Get());

            return Task.FromResult(response);
        }
    }
}
