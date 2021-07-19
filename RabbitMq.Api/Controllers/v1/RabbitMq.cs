using MediatR;
using Microsoft.AspNetCore.Mvc;
using RabbitMq.Domain.Commands.v1.ConsultRabbitMq;
using RabbitMq.Domain.Commands.v1.InsertRabbitMq;
using System.Threading.Tasks;

namespace RabbitMq.Api.Controllers.v1
{
    [Route("api/v1/rabbitmq")]
    [ApiController]
    public class RabbitMq : ControllerBase
    {
        private readonly IMediator _serviceMediator;

        public RabbitMq(IMediator serviceMediator)
        {
            _serviceMediator = serviceMediator;
        }

        [HttpGet("test")]
        public Task<InsertRabbitMqCommandResponse> Test()
        {
            return _serviceMediator.Send(new InsertRabbitMqCommand());
        }

        [HttpGet("test2")]
        public Task<ConsultRabbitMqCommandResponse> Test2()
        {
            return _serviceMediator.Send(new ConsultRabbitMqCommand());
        }
    }
}
