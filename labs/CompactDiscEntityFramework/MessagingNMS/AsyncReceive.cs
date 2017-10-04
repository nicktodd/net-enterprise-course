using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.Util;

namespace MessagingNMS
{
    public class AsyncReceive
    {
        public static void Main()
        {
            Uri connecturi = new Uri("activemq:tcp://localhost:61616");
            IConnectionFactory factory = new NMSConnectionFactory(connecturi);
            using (IConnection connection = factory.CreateConnection())
            using (ISession session = connection.CreateSession())
            {
                IDestination destination = SessionUtil.GetDestination(session, "queue://testQueue");
                using (IMessageConsumer consumer = session.CreateConsumer(destination))
                {
                    consumer.Listener += new MessageListener(OnMessage);
                    connection.Start();
                    Console.ReadKey();
                }
            }


        }

        protected static void OnMessage(IMessage receivedMsg)
        {
            var message = receivedMsg as ITextMessage;
            Console.WriteLine(message.Text);
        }

    }
}
