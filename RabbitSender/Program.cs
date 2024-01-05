using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
factory.ClientProvidedName = "Rabbit Sender App";
IConnection connection = factory.CreateConnection();
IModel channel = connection.CreateModel();
 
string exChangeName  = "DemoExchange";
string routingKey = "demo-routing-key";
string queueName = "DemoQueue";
 
channel.ExchangeDeclare(exChangeName, ExchangeType.Direct);
channel.QueueDeclare(queueName, false, false, false, null);
channel.QueueBind(queueName, exChangeName, routingKey,null);

for (int i = 0; i < 60; i++)
{
    Console.WriteLine($"Sending message: {i}");
    byte[] messageBodyBytes = Encoding.UTF8.GetBytes($"Message #{i}");
    channel.BasicPublish(exChangeName, routingKey, null, messageBodyBytes);
    Thread.Sleep(1000);
}
channel.Close();
connection.Close();