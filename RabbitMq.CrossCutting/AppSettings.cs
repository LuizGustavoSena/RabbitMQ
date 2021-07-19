using RabbitMq.CrossCutting.AppModels;

namespace RabbitMq.CrossCutting
{
    public class AppSettings
    {
        public const string ActionName = "MyConfig";

        public Rabbit Rabbit { get; set; }
    }
}
