using System;
using Discord.Commands;
using System.Threading.Tasks;

namespace DalleBot
{

    public class CommandModule : ModuleBase<SocketCommandContext>
    {
        [Command("is it friday?")]
        [Alias("ask")]
        public async Task askIsItFriday([Remainder]string args = null)
        {
            await ReplyAsync(IsItFriday());
        }

        public string IsItFriday()
        {
            var currentDay = DateTime.Now.DayOfWeek.ToString();
            if (currentDay == "Friday")
            {
                return "I AM GONNA POOOOOG ITS FRIDAY ANY JAMMERS?";
            }
            return "not friday thats a bruh momento";
        }

        [Command("am i gay?")]
        public async Task amIGay([Remainder] string args = null)
        {
            await ReplyAsync(amIGay());
        }

        public string amIGay()
        {
            Random rand = new Random();
            int number = rand.Next(1, 2);

            if (number == 1)
            {
                return "YES";
            }
            return "no :c";
        }

        [Command("deez")]
        public async Task Deez([Remainder] string args = null)
        {
            var user = Context.User;

            await ReplyAsync("you are a nut" + " " + user.ToString());
        }
    }
}
