using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IKafkaService
    {
        IResult SendMessage(string topic, string message);
    }
}
