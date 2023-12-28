using FluxoCaixa.Services.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace FluxoCaixa.Services.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQService()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost", // Substitua pelo endereço do seu servidor RabbitMQ
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void PublicarMensagem(string mensagem)
        {
            _channel.QueueDeclare("saldo_queue", durable: true, false, false, null);
            var body = Encoding.UTF8.GetBytes(mensagem);

            _channel.BasicPublish(exchange: "", routingKey: "saldo_queue", basicProperties: null, body: body);
        }
    }
}
