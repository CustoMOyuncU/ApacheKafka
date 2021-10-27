using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.ApacheKafka.Abstract
{
    public interface IApacheKafkaRepository
    {
        IResult SendMessage(Produce produce);
        IResult SendMessages(Produce produce);
        IResult CreateTopic(Topic topic);
    }
}
