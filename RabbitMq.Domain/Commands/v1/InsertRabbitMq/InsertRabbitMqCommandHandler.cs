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

        public InsertRabbitMqCommandHandler(ISetRabbitMq setRabbitMq)
        {
            _setRabbitMq = setRabbitMq;
        }

        public Task<InsertRabbitMqCommandResponse> Handle(InsertRabbitMqCommand request, CancellationToken cancellationToken)
        {
            Person person = new Person
            {
                Name = request.Name,
                LastName = request.LastName,
                Age = request.Age
            };

            _setRabbitMq.Set(person);

            return Task.FromResult(new InsertRabbitMqCommandResponse
            {
                Result = "Created"
            });
        }
    }
}
