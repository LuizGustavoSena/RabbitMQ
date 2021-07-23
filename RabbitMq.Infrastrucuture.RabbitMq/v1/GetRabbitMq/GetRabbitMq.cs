using Microsoft.Extensions.Options;
using RabbitMq.CrossCutting;
using RabbitMq.Domain.Interface.Tools;
using RabbitMq.Domain.Models.Tools;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMq.Infrastrucuture.RabbitMq.v1.GetRabbitMq
{
    public class GetRabbitMq : IGetRabbitMq
    {
        private readonly IOptions<AppSettings> _appSettings;

        public GetRabbitMq(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public Person Get()
        {
            var factory = new ConnectionFactory() { HostName = _appSettings.Value.Rabbit.ServerName };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: _appSettings.Value.Rabbit.queue,
                                 durable: _appSettings.Value.Rabbit.durable,
                                 exclusive: _appSettings.Value.Rabbit.exclusive,
                                 autoDelete: _appSettings.Value.Rabbit.autoDelete,
                                 arguments: _appSettings.Value.Rabbit.arguments);

            var data = channel.BasicGet(_appSettings.Value.Rabbit.queue, _appSettings.Value.Rabbit.autoAck);
            var json = Encoding.UTF8.GetString(data.Body.ToArray());

            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Person>(json);

            return obj;
        }

    }
}
