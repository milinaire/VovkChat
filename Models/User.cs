using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vovk_Chat.Models
{
    //Клас для збереження користувачів
    public class User : IUser
    {
        public User(int UserID, string UserName)
        {
            this.UserID = UserID;
            this.RegistrationDate = DateTime.Now;
            this.Username = UserName;
        }

        public User() : this(0, " ")
        {
        }

        public string Username { get; set; }

        public int UserID { get; set; }

        public DateTime RegistrationDate { get; }

    }
}
