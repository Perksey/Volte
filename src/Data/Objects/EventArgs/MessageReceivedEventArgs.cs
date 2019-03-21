using Discord;
using Discord.WebSocket;
using Volte.Commands;
using Volte.Discord;
using Volte.Services;

namespace Volte.Data.Objects.EventArgs
{
    public class MessageReceivedEventArgs : System.EventArgs
    {
        private readonly DatabaseService _db = VolteBot.GetRequiredService<DatabaseService>();
        public IUserMessage Message { get; }
        public VolteContext Context { get; }
        public DiscordServer Config { get; }

        public MessageReceivedEventArgs(SocketMessage s)
        {
            Message = s as IUserMessage;
            Context = new VolteContext(VolteBot.Client, Message, VolteBot.ServiceProvider);
            Config = _db.GetConfig(Context.Guild);
        }
    }
}