using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class KafkaManager : IKafkaService
    {
        IKafkaApDal _kafkaApDal;

        public KafkaManager(IKafkaApDal kafkaApDal)
        {
            _kafkaApDal = kafkaApDal;
        }

        public IResult SendMessage(Produce produce)
        {
            _kafkaApDal.SendMessage(produce);
            return new SuccessResult(Messages.MessageSentSuccess);
        }

        public IResult SendMessages(Produce produce)
        {
            _kafkaApDal.SendMessages(produce);
            return new SuccessResult(Messages.MessagesSentSuccess);
        }
        public IResult CreateTopic(Topic topic)
        {
            var result = _kafkaApDal.CreateTopic(topic);
            if (result.Success)
            {
                return new SuccessResult(Messages.TopicCreated);
            }
            return new ErrorResult(result.Message);
        }
    }
}
