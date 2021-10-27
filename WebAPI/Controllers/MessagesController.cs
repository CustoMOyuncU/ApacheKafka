using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        IKafkaService _kafkaService;

        public MessagesController(IKafkaService kafkaService)
        {
            _kafkaService = kafkaService;
        }

        [HttpPost("sendmessage")]
        public IActionResult SendMessageToKafka(Produce produce)
        {
            var result = _kafkaService.SendMessage(produce);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("sendmessages")]
        public IActionResult SendMessagesToKafka(Produce produce)
        {
            var result = _kafkaService.SendMessages(produce);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("createtopic")]
        public IActionResult CreateTopic(Topic topic)
        {
            var result = _kafkaService.CreateTopic(topic);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
