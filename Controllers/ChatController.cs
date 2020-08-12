using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using Vovk_Chat.Models;

namespace Vovk_Chat.Controllers
{
    //Контроллер чату, дозволяє надсилати повідомлення та переглядати історію чату в сирому виді і як HTML
    [ApiController]
    [Route("chat")]
    public class ChatController : BaseController
    {
        protected IMessageFormer _messageFormer;

        public ChatController(IChatDB ChatDB, IServiceProvider serviceProvider, IMessageFormer messageFormer): base(ChatDB, serviceProvider)
        {
            this._messageFormer = messageFormer;
        }

        //Вивести чат
        [HttpGet]
        public ActionResult GetChat()
        {
            string HTML = "";

            HTML += "<html><head><title>Vovk Chat</title></head><body>";

            var Chat = this._chatdb.GetChatHistory();

            foreach (var item in Chat)
            {
                HTML += this._chatdb.GetUser(item.SenderID).Username + ": " + item.MessageText + "</br>";
            }

            HTML += "</body></html>";

            return Content(HTML, "text/html");
        }

        //Получити дані чату в сирому форматі
        [HttpGet("raw")]
        public IEnumerable<IMessage> GetRaw()
        {
            return this._chatdb.GetChatHistory();
        }

        //Написати повідомлення від імені {id} з текстом {text} переданим через посилання
        [HttpPut("{id}/{text}")]
        public ActionResult PutWithLink([FromRoute]int id, [FromRoute]string text)
        {
            return PutWithLinkAndBody(id, text);
        }
        //Написати повідомлення від імені {id} з текстом {text} переданим через тіло JSON запиту
        [HttpPut("{id}")]
        public ActionResult PutWithLinkAndBody([FromRoute]int id, [FromBody]string text)
        {
            if (this._chatdb.GetUser(id) == null)
            {
                return NotFound();
            }
            else
            {
                this._chatdb.AddMessage(this._messageFormer.CreateMessage(this._chatdb.GetUser(id), text));
                return Ok();
            }
        }
    }
}
