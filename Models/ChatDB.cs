using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vovk_Chat.Models
{
    //Клас бази даних чату
    public class ChatDB : IChatDB
    {
        protected Dictionary<int, IUser> _users;
        protected List<IMessage> _messages;

        public ChatDB()
        {
            this._users = new Dictionary<int, IUser>();
            this._messages = new List<IMessage>();
        }

        public Dictionary<int, IUser> GetActiveUsers()
        {
            return this._users;
        }

        public int AddUser(IUser User)
        {
            if (!_users.ContainsKey(User.UserID))
            {
                _users.Add(User.UserID, User);
                return User.UserID;
            }
            else
            {
                return -1;
            }
        }

        public int DeleteUser(int ID)
        {
            if (_users.ContainsKey(ID))
            {
                _users.Remove(ID);
                return ID;
            }

            return -1;
        }

        public void ClearUsers()
        {
            _users.Clear();
        }

        public void ClearChatHistory()
        {
            _messages.Clear();
        }

        public List<IMessage> GetChatHistory()
        {
            return this._messages;
        }

        public IMessage GetMessage(int ID)
        {
            if (ID >= 0 && ID < _messages.Count)
            {
                return _messages.ElementAt(ID);
            }
            else
            {
                return null;
            }
        }

        public IUser GetUser(int ID)
        {
            if (ID == 0) return null;
            return _users.GetValueOrDefault(ID);
        }

        public void AddMessage(IMessage message)
        {
            this._messages.Add(message);
        }

    }
}
