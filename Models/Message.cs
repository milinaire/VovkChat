namespace Vovk_Chat.Models
{
    //Простий клас для повідомлень
    public class Message : IMessage
    {
        public Message(string MessageText, int SenderID)
        {
            this.MessageText = MessageText;
            this.SenderID = SenderID;
        }

        public Message() : this(" ", 0)
        {
        }

        public int SenderID { get; set; }
        public virtual string MessageText { get; set; }
    }

}
