using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://tqlppzrj:9rQtfXQ7aapr-TXu7Q1hkrn2N6EhUvK3@sparrow.rmq.cloudamqp.com/tqlppzrj");

using (IConnection connection = factory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
	channel.QueueDeclare("mesajkuyrugu", true, false, false, null);
	channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);


	EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
	channel.BasicConsume("mesajkuyrugu", false, consumer);
	consumer.Received += (sender, e) =>
	{
		//Thread.Sleep(int.Parse(args[0]));
		//e.Body : Kuyruktaki mesajı verir.
		Console.WriteLine(Encoding.UTF8.GetString(e.Body.ToArray()));
		channel.BasicAck(e.DeliveryTag, false);
	};
	Console.Read();
}