using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DalleBot
{
    public class Program
    {
		//Runs the async main method
		public static void Main(string[] args)
			=> new Program().MainAsync().GetAwaiter().GetResult();

		public async Task MainAsync()
		{
			using (var services = ConfigureServices())
            {
				var client = services.GetRequiredService<DiscordSocketClient>();
				//Add logging
				client.Log += Log;
				services.GetRequiredService<CommandService>().Log += Log;

				//Extract token
				var token = Environment.GetEnvironmentVariable("token");

				await client.LoginAsync(TokenType.Bot, token);
				await client.StartAsync();

				await services.GetRequiredService<CommandHandler>().InstallCommandsAsync();

				await Task.Delay(-1);
			}
		}


		//Logging
		private Task Log(LogMessage message)
		{
			Console.WriteLine(message.ToString());
			return Task.CompletedTask;
		}

		public ServiceProvider ConfigureServices()
        {
			return new ServiceCollection()
				.AddSingleton<DiscordSocketClient>()
				.AddSingleton<CommandService>()
				.AddSingleton<CommandHandler>()
				.AddSingleton<CommandModule>()
				.BuildServiceProvider();
		}
	}
}
