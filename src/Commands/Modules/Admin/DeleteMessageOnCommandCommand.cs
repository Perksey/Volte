﻿using System.Threading.Tasks;
using Qmmands;
using Volte.Commands.Preconditions;
using Volte.Data.Models.Results;
using Volte.Extensions;

namespace Volte.Commands.Modules.Admin
{
    public partial class AdminModule : VolteModule
    {
        [Command("DeleteMessageOnCommand", "Dmoc")]
        [Description("Enable/Disable deleting the command message upon execution of a command for this guild.")]
        [Remarks("Usage: |prefix|deletemessageoncommand {true|false}")]
        [RequireGuildAdmin]
        public Task<VolteCommandResult> DeleteMessageOnCommandAsync(bool enabled)
        {
            var data = Db.GetData(Context.Guild);
            data.Configuration.DeleteMessageOnCommand = enabled;
            Db.UpdateData(data);
            return Ok(enabled
                ? "Enabled DeleteMessageOnCommand in this server."
                : "Disabled DeleteMessageOnCommand in this server.");
        }
    }
}