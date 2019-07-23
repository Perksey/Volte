using System;
using Discord;
using Discord.WebSocket;
using Gommon;
using Microsoft.Extensions.DependencyInjection;
using Volte.Commands;
using Volte.Data.Models.Guild;
using Volte.Services;

namespace Volte.Data.Models.EventArgs
{
    public sealed class MessageReceivedEventArgs : System.EventArgs
    {
        private readonly DatabaseService _db;
        public SocketUserMessage Message { get; }
        public VolteContext Context { get; }
        public GuildData Data { get; }

        public MessageReceivedEventArgs(SocketMessage s, IServiceProvider provider)
        {
            Message = s.Cast<SocketUserMessage>();
            _db = provider.GetRequiredService<DatabaseService>();
            Context = new VolteContext(provider.GetRequiredService<DiscordShardedClient>(), Message, provider);
            Data = _db.GetData(Context.Guild);
        }
    }
}