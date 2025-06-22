using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Microsoft.Extensions.Configuration;



namespace Bot
{
    class Program
    {


        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var botToken = config["BotConfiguration:BotToken"];
            var _botClient = new TelegramBotClient(botToken);
            
            
            var me = await _botClient.GetMe();
            Console.WriteLine($"Бот запущен: @{me.Username}");

            _botClient.StartReceiving(
            updateHandler: HandleUpdate,
            errorHandler: HandleError,
            receiverOptions: null,
            cancellationToken: new CancellationTokenSource().Token
            );

            Console.WriteLine("Бот слушает сообщения...");
            Console.ReadLine();
        }


        private static async Task HandleUpdate(ITelegramBotClient bot, Update update, CancellationToken ct)
        {
            switch (update.Message?.Text)
            {
                case "/start":
                    await BotCommands.StartCommand(bot, update.Message, ct);
                    break;
                case "/help":
                    await BotCommands.HelpCommand(bot, update.Message, ct);
                    break;
                case "/contacts":
                    await BotCommands.ContactCommand(bot, update.Message, ct);
                    break;
                default:
                    await BotCommands.ErrorCommand(bot, update.Message, ct);
                    break;
            }
        }

        private static Task HandleError(ITelegramBotClient bot, Exception ex, CancellationToken ct)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            return Task.CompletedTask;
        }
    }
}
