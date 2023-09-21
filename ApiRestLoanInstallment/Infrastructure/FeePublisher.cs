using ApiRestLoanInstallment.Models;
using RabbitMQ.Client;
using System.Text;

namespace ApiRestLoanInstallment.Infrastructure
{
    public class FeePublisher : ConnectionBuilderBase, IMessageProducer
    {

        public FeePublisher(IConfiguration configuration) : base(configuration) { }

        public void Produce(string message)
        {
            var factory = GetConnection;

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "",
                                 routingKey: _queueName,
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($" [x] Rabbit sent message type: {typeof(MonthlyFee)} - body {message}");

        }

    }
}
