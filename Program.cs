using System;
using System.Text;
using System.Text.Json;
using Football_Transfers_Validation_API.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Welcome to the Transfer Validation System!\n");

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "guest",
    Password = "guest",
    VirtualHost = "/"
};

var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare("test", durable: true, exclusive: false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();

    var message = Encoding.UTF8.GetString(body);
    var transfer = JsonSerializer.Deserialize<Transfer>(message);

    Console.WriteLine($"TransferValue: {transfer?.TransferValue}\n");
    Console.WriteLine($"TransferState: {transfer?.TransferState.ToString()}\n");
};

channel.BasicConsume("test", autoAck: true, consumer);

Console.ReadLine();
