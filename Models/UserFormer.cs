using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Vovk_Chat.Models
{
    //Клас для створення унікальних користувачів
    public class UserFormer: IUserFormer
    {
        protected readonly IChatDB _chatDB;
        protected readonly IServiceProvider _serviceProvider;

        public UserFormer(IChatDB chatDB, IServiceProvider serviceProvider)
        {
            this._chatDB = chatDB;
            this._serviceProvider = serviceProvider;
        }
        public IUser CreateUniqueUser(string UserName)
        {
            Random rand = new Random();
            var NewUser = _serviceProvider.GetService<IUser>();
            NewUser.Username = UserName;
            int id;
            do
            {
                id = rand.Next(1, int.MaxValue);
            }
            while (this._chatDB.GetUser(id) != null);
            NewUser.UserID = id;
            return NewUser;
        }

    }
}
