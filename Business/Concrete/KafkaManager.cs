using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
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

        public IResult SendMessage(string topic, string message)
        {
            return new SuccessResult(_kafkaApDal.SendMessage(topic, message).Message);
        }
    }
}
