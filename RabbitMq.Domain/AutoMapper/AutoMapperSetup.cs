using AutoMapper;
using RabbitMq.Domain.Commands.v1.ConsultRabbitMq;
using RabbitMq.Domain.Commands.v1.InsertRabbitMq;
using RabbitMq.Domain.Models.Tools;

namespace RabbitMq.Domain.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            CreateMap<InsertRabbitMqCommand, Person>();
            CreateMap<Person, ConsultRabbitMqCommandResponse>();
        }
    }
}
