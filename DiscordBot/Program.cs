﻿using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using Discord;
using System.IO;

namespace SIVA
{
    internal class Program
    {
        private DiscordSocketClient _client;
        private MessageHandler _handler;

        private static void Main()
        {
            Console.Title = "SIVA";
            Console.CursorVisible = false;
            new Program().StartAsync().GetAwaiter().GetResult();
        }

        public async Task StartAsync()
        {
            if (string.IsNullOrEmpty(Config.bot.Token))
            {
                Console.WriteLine("Token not specified.");
                Console.ReadLine();
                return;
            }
            _client = new DiscordSocketClient(new DiscordSocketConfig{LogLevel = LogSeverity.Verbose});
            _client.Log += Log;
            await _client.LoginAsync(TokenType.Bot, Config.bot.Token);
            await _client.StartAsync();
            await _client.SetGameAsync(Config.bot.BotGameToSet, $"https://twitch.tv/{Config.bot.TwitchStreamer}", StreamType.Twitch);
            await _client.SetStatusAsync(UserStatus.DoNotDisturb);
            _handler = new MessageHandler();
            await _handler.InitializeAsync(_client);
            Console.WriteLine("Use this to invite the bot into your server: https://discordapp.com/oauth2/authorize?scope=bot&client_id=410547925597421571&permissions=8");
            await Task.Delay(-1);
        }

        private static async Task Log(LogMessage msg)
        {
            if (!Config.bot.Debug) return;
            Console.WriteLine("debug: " + msg.Message);
            try
            {
                File.AppendAllText("Log.txt", $"{msg.Message}\n");
            }
            catch (FileNotFoundException)
            {
                File.WriteAllText("Log.txt", msg.Message);
            }
        }
    }
}