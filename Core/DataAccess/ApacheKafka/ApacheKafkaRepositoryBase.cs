using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Core.DataAccess.ApacheKafka.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.ApacheKafka
{
    public class ApacheKafkaRepositoryBase : IApacheKafkaRepository
    {
        IProducer<Null, string> _producer;
        IAdminClient _adminClient;
        public ApacheKafkaRepositoryBase()
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9092,192.168.20.131:9092"
            };
            _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
            var adminConfig = new AdminClientConfig {
                BootstrapServers = "localhost:9092,192.168.20.131:9092"
            };
            _adminClient = new AdminClientBuilder(adminConfig).Build();
        }
        public IResult SendMessage(Produce produce)
        {
            _producer
                .ProduceAsync(new TopicPartition(produce.Topic, produce.Partition)
                , new Message<Null, string> { Value = produce.Message });
            return new SuccessResult();
        }
        public IResult SendMessages(Produce produce)
        {
            for (int i = 0; i < 100; i++)
            {
                _producer
                    .ProduceAsync(new TopicPartition(produce.Topic, produce.Partition)
                    , new Message<Null, string> { Value = produce.Message + "-BackEnd" + i });
            }

            return new SuccessResult();
        }
        public IResult CreateTopic(Topic topic)
        {
            try
            {
                _adminClient.CreateTopicsAsync(new TopicSpecification[] {
                    new TopicSpecification {
                        Name = topic.TopicName, ReplicationFactor = 1, NumPartitions = topic.MaxPartition
                    }
                });
                return new SuccessResult();
            }
            catch (CreateTopicsException e)
            {
                return new ErrorResult($"An error occured creating topic {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
            }
        }
    }
}
