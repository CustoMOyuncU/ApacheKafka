using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.ApacheKafka.Abstract
{
    public interface IApacheKafkaRepository
    {
        IResult SendMessage(string topic, string message);
    }
}
