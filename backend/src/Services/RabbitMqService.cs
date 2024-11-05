using System.Text;
using RabbitMQ.Client;

public class RabbitMqService
{
    private readonly IConnectionFactory _connectionFactory;

    public RabbitMqService(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public void SendMessage(string message)
    {
        using var connection = _connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: "contatos", durable: false, exclusive: false, autoDelete: false, arguments: null);
        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: "", routingKey: "contatos", basicProperties: null, body: body);
    }
}