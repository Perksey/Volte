﻿using System.Diagnostics;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Volte.Core.Discord;
using Volte.Core.Extensions;

namespace Volte.Core.Commands.Modules.Utility {
    public partial class UtilityModule : VolteModule {
        [Command("Ping")]
        [Summary("Show the Gateway latency to Discord.")]
        [Remarks("Usage: |prefix|ping")]
        public async Task Ping() {
            var e = Context.CreateEmbed("Pinging...").ToEmbedBuilder();
            var sw = new Stopwatch();
            sw.Start();
            var msg = await e.SendTo(Context.Channel);
            sw.Stop();
            await msg.ModifyAsync(x => {
                e.WithDescription(
                    $"{RawEmoji.CLAP} **Ping**: {sw.ElapsedMilliseconds}ms \n" +
                    $"{RawEmoji.OK_HAND} **API**: {VolteBot.Client.Latency}ms");
                x.Embed = e.Build();
            });
        }
    }
}