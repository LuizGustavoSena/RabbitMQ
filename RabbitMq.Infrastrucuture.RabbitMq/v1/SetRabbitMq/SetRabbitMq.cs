using Microsoft.Extensions.Options;
using RabbitMq.CrossCutting;
using RabbitMq.Domain.Interface.Tools;
using RabbitMq.Domain.Models.Tools;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMq.Infrastrucuture.RabbitMq.v1.SetRabbitMq
{
    public class SetRabbitMq : ISetRabbitMq
    {
        private readonly IOptions<AppSettings> _appSettings;

        public SetRabbitMq(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public void Set(Person person)
        {
            var factory = new ConnectionFactory() { HostName = _appSettings.Value.Rabbit.ServerName };

            using(var connection = factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.ConfirmSelect();

                    channel.QueueDeclare(queue: _appSettings.Value.Rabbit.queue,
                                         durable: _appSettings.Value.Rabbit.durable,
                                         exclusive: _appSettings.Value.Rabbit.exclusive,
                                         autoDelete: _appSettings.Value.Rabbit.autoDelete,
                                         arguments: _appSettings.Value.Rabbit.arguments);

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(person);

                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: _appSettings.Value.Rabbit.exchange,
                                         routingKey: _appSettings.Value.Rabbit.routingKey,
                                         basicProperties: _appSettings.Value.Rabbit.basicProperties,
                                         body: body);
                }
            }
        }
    }
}
