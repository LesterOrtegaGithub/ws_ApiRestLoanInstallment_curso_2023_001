using RabbitMQ.Client;

namespace ApiRestLoanInstallment.Infrastructure
{
    public abstract class ConnectionBuilderBase
    {

        protected readonly string _rabbitMQHost;
        protected readonly string _rabbitMQPort;
        protected readonly string _rabbitMQUsername;
        protected readonly string _rabbitMQPassword;
        protected readonly string _exchangeName;
        protected readonly string _queueName;


        public ConnectionBuilderBase(IConfiguration configuration)
        {
            _rabbitMQHost = configuration["RabbitMQ:Host"];
            _rabbitMQUsername = configuration["RabbitMQ:UserName"];
            _rabbitMQPassword = configuration["RabbitMQ:Password"];
            _rabbitMQPort = configuration["RabbitMQ:Port"];
            _exchangeName = configuration["RabbitMQ:ExchangeName"];
            _queueName = configuration["RabbitMQ:QueueName"];
        }

        protected ConnectionFactory GetConnection =>
            new ConnectionFactory()
            {
                HostName = _rabbitMQHost,
                Port = int.Parse(_rabbitMQPort),
                UserName = _rabbitMQUsername,
                Password = _rabbitMQPassword

            };


    }
}
