using AutoMapper;
using MediatR;
using RabbitMq.Domain.Interface.Tools;
using RabbitMq.Domain.Models.Tools;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMq.Domain.Commands.v1.InsertRabbitMq
{
    public class InsertRabbitMqCommandHandler : IRequestHandler<InsertRabbitMqCommand, InsertRabbitMqCommandResponse>
    {
        private readonly ISetRabbitMq _setRabbitMq;
        private readonly IMapper _mapper;
        public InsertRabbitMqCommandHandler(ISetRabbitMq setRabbitMq, IMapper mapper)
        {
            _setRabbitMq = setRabbitMq;
            _mapper = mapper;
        }

        public Task<InsertRabbitMqCommandResponse> Handle(InsertRabbitMqCommand request, CancellationToken cancellationToken)
        {

            Person person = _mapper.Map<Person>(request);

            _setRabbitMq.Set(person);

            return Task.FromResult(new InsertRabbitMqCommandResponse
            {
                Result = "Created"
            });
        }
    }
}
