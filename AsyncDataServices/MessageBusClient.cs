using System.Text;
using System.Text.Json;
using aninja_anime_service.Dtos;
using RabbitMQ.Client;

namespace aninja_anime_service.AsyncDataServices;

public class MessageBusClient : IMessageBusClient
{
    private readonly IConfiguration _configuration;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public MessageBusClient(IConfiguration configuration)
    {
        _configuration = configuration;
        var factory = new ConnectionFactory()
        {
            HostName = _configuration["RabbitMQHost"], Port = int.Parse(_configuration["RabbitMQPort"])
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        
        _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

        _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;


    }

    private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
    {
        
    }
    
    
    public void PublishNewAnime(AnimePublishedDto animePublishedDto)
    {
        var message = JsonSerializer.Serialize(animePublishedDto);

        if (_connection.IsOpen)
        {
            SendMessage(message);
        }
    }

    public void PublishAnimeUpdate(AnimePublishedDto animePublishedDto)
    {
        var message = JsonSerializer.Serialize(animePublishedDto);

        if (_connection.IsOpen)
        {
            SendMessage(message);
        }
    }

    public void Dispose()
    {
        if (_channel.IsOpen)
        {
            _channel.Close();
            _connection.Close();
        }
    }

    private void SendMessage(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(exchange: "trigger", routingKey: "", basicProperties: null, body: body);
    }
}