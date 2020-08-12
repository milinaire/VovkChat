using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Vovk_Chat.Models;

namespace Vovk_Chat.Controllers
{
    //Контроллер користувачів, дозволяє добавляти/видаляти/взнавати активних користувачів
    [ApiController]
    [Route("api/users")]
    public class UsersController : BaseController
    {
        protected readonly IUserFormer _userFormer;

        public UsersController(IChatDB ChatDB, IServiceProvider serviceProvider, IUserFormer userFormer):base(ChatDB, serviceProvider)
        {
            this._userFormer = userFormer;
        }

        // Список користувачів (для дебагів, по задумці в релізній версії відключений для приватності)
        [HttpGet]
        public IEnumerable<IUser> Get()
        {
            return _chatdb.GetActiveUsers().Values.ToList();
        }

        // Получити дані користувача з {id}
        [HttpGet("{id}")]
        public IUser Get([FromRoute]int id)
        {
            return _chatdb.GetUser(id);
        }

        //Створити користувача {UserName}, повертає унікальний {id} для повідомлень
        [HttpPut("{UserName}")]
        public ActionResult<int> Put([FromRoute]string UserName)
        {
            var User = this._userFormer.CreateUniqueUser(UserName);
            this._chatdb.AddUser(User);
            return User.UserID;
        }

        //Видалити користувача з ID
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            if (_chatdb.DeleteUser(id) != -1)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
