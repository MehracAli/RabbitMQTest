using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://tqlppzrj:9rQtfXQ7aapr-TXu7Q1hkrn2N6EhUvK3@sparrow.rmq.cloudamqp.com/tqlppzrj");


using (IConnection connection = factory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
	channel.QueueDeclare("mesajkuyrugu", true, false, false, null);
	for (int i = 1; i <= 100; i++)
	{
		byte[] bytemessage = Encoding.UTF8.GetBytes($"sebepsiz boş yere ayrılacaksan -> {i}");
		IBasicProperties properties = channel.CreateBasicProperties();
		properties.Persistent = true;
		channel.BasicPublish(exchange: "", routingKey: "mesajkuyrugu", body: bytemessage, basicProperties: properties);
	}
};