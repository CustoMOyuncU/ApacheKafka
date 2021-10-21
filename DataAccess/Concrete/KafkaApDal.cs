using Core.DataAccess.ApacheKafka;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class KafkaApDal: ApacheKafkaRepositoryBase ,IKafkaApDal
    {
    }
}
