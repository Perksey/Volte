﻿using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Gommon;
using Qmmands;
using Volte.Commands.Results;

namespace Volte.Commands.Modules
{
    public sealed partial class UtilityModule : VolteModule
    {
        [Command("Color", "Colour")]
        [Description("Shows the Hex and RGB representation for a given role in the current server.")]
        [Remarks("Usage: |prefix|color {role}")]
        public async Task<ActionResult> RoleColorAsync([Remainder] SocketRole role)
        {
            if (role.Color.RawValue is 0) return BadRequest("Role does not have a color.");

            await Context.Channel.SendFileAsync(await role.Color.ToPureColorImageAsync(), "color.png", null, embed: Context.CreateEmbedBuilder(new StringBuilder()
                    .AppendLine($"**Dec:** {role.Color.RawValue}")
                    .AppendLine($"**RGB:** {role.Color.R}, {role.Color.G}, {role.Color.B}")
                    .ToString())
                .WithTitle($"Color of Role \"{role.Name}\"")
                .WithImageUrl("attachment://color.png")
                .Build());
            return None();

        }
    }
}