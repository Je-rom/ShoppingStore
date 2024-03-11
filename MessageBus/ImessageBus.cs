using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBus
{
    public interface IMessageBus
    {
        Task PublishMessage(object message, string topic_queue_name); //message signature
        //void Subscribe<T, TH>() where T : BaseMessage where TH : IMessageHandler<T>;
    }
}
