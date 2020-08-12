using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vovk_Chat.Models
{
    public interface IUser
    {
        string Username { get; set; }
        DateTime RegistrationDate { get; }
        int UserID { get; set; }
    }

    public interface IMessage
    {
        string MessageText { get; set; }
        int SenderID { get; set; }
    }

    public interface IMessageFormer
    {
        IMessage CreateMessage(IUser Sender, string text);
    }

    public interface IUserFormer
    {
        IUser CreateUniqueUser(string username);
    }

    public interface IChatDB
    {
        Dictionary<int, IUser> GetActiveUsers();
        List<IMessage> GetChatHistory();
        IMessage GetMessage(int MessageId);
        IUser GetUser(int UserID);

        int AddUser(IUser User);
        int DeleteUser(int ID);
        void ClearUsers();
        void ClearChatHistory();
        void AddMessage(IMessage Message);

    }

   
}
