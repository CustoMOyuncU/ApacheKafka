using Core.DataAccess.ApacheKafka.Abstract;
using Core.Utilities.Results;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.ApacheKafka
{
    public class ApacheKafkaRepositoryBase : IApacheKafkaRepository
    {
        public IResult SendMessage(string topic,string message)
        {
            //FOR EKLE 100 adet veri girişi için !
            var kafkaOptions = new KafkaOptions(new Uri("http://localhost:9092"));
            var brokerRouter = new BrokerRouter(kafkaOptions);
            var producer = new Producer(brokerRouter);
            producer.SendMessageAsync(topic, new[]
            {
                new Message(message)
            }).Wait();
            return new SuccessResult("Message Sent Successful");
        }
    }
}
