using Apache.NMS;
using Apache.NMS.Util;
using System;
namespace MessagingExample
{
    internal class BasicSender
    {
        public static void Main(string[] args)
        {
            Uri connecturi = new Uri("activemq:tcp://localhost:61616");
            IConnectionFactory factory = new NMSConnectionFactory(connecturi);
            using (IConnection connection = factory.CreateConnection())
            using (ISession session = connection.CreateSession())
            {
                IDestination destination = SessionUtil.GetDestination(session, "queue://testQueue");
                using (IMessageProducer producer = session.CreateProducer(destination))
                {
                    connection.Start();
                    ITextMessage request = session.CreateTextMessage("Hello World!");
                    producer.Send(request);
                }
            }
        }
    }
}
