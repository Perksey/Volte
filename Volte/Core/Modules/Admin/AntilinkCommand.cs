﻿using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Volte.Core.Files.Readers;
using Volte.Helpers;

namespace Volte.Core.Modules.Admin {
    public partial class AdminModule : VolteModule {
        [Command("Antilink"), Alias("Al")]
        [Summary("Enable/Disable Antilink for the current guild.")]
        [Remarks("Usage: |prefix|antilink {true|false}")]
        public async Task Antilink(bool alIsEnabled) {
            if (!UserUtils.IsAdmin(Context)) {
                await React(Context.SMessage, RawEmoji.X);
                return;
            }

            var config = Db.GetConfig(Context.Guild);
            config.Antilink = alIsEnabled;
            var isEnabled = alIsEnabled ? "Antilink has been enabled." : "Antilink has been disabled.";
            await Reply(Context.Channel, CreateEmbed(Context, isEnabled));
        }
    }
}