using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Vovk_Chat.Models
{
    //Клас для створення повідомлень
    public class MessageFormer : IMessageFormer
    {
        protected readonly IServiceProvider serviceProvider;

        public MessageFormer(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMessage CreateMessage(IUser Sender, string text)
        {
            var Message = this.serviceProvider.GetService<IMessage>();
            Message.MessageText = text;
            Message.SenderID = Sender.UserID;

            return Message;
        }
    }
}
