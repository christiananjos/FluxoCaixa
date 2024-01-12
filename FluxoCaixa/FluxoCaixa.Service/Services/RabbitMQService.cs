using FluxoCaixa.Services.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace FluxoCaixa.Services.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        public void PublicarMensagem(string mensagem)
        {
            try
            {
                var factory = new ConnectionFactory { HostName = "localhost" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: "Queue_transacao",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(mensagem);

                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: "Queue_transacao",
                                     basicProperties: null,
                                     body: body);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
