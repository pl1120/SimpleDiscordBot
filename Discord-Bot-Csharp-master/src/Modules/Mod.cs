using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Discord_Bot
{
    public class Mod : ModuleBase<SocketCommandContext>
    {
        [Command("kick")]
        [Summary("Kick a user from the server.")]
        [RequireBotPermission(GuildPermission.KickMembers)]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task Kick(SocketGuildUser targetUser, [Remainder] string reason = "No reason provided.")
        {
            await targetUser.KickAsync(reason);
            await ReplyAsync($"**{targetUser}** has been kicked. Bye bye :wave:");
        }

        [Command("reloadconfig")]
        [Summary("Reloads the config and applies changes")] 
        [RequireOwner] // Require the bot owner to execute the command successfully.
        public async Task ReloadConfig()
        {
            await Functions.SetBotStatusAsync(Context.Client);
            await ReplyAsync("Reloaded!");
        }
    }
}
