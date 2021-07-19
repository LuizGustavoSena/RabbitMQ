using MediatR;

namespace RabbitMq.Domain.Commands.v1.InsertRabbitMq
{
    public class InsertRabbitMqCommand : IRequest<InsertRabbitMqCommandResponse>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
