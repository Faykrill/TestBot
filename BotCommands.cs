using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot
{
    public class BotCommands
    {
        public static async Task ErrorCommand(ITelegramBotClient bot, Message message, CancellationToken ct)
        {
            long chatId = message.Chat.Id;
            await bot.SendMessage(chatId, "Ввели неккоректную команду.", cancellationToken: ct);
        }
        public static async Task StartCommand(ITelegramBotClient bot, Message message, CancellationToken ct)
        {
            long chatId = message.Chat.Id;
            await bot.SendMessage(chatId,
            text: $"Привет! Я работаю на новом API v20+, ваш ID: {chatId}.\nHelp - /help",
            cancellationToken: ct);

        }

        public static async Task HelpCommand(ITelegramBotClient bot, Message message, CancellationToken ct)
        {
            long chatId = message.Chat.Id;
            await bot.SendMessage(chatId,
            text: "I help you. \n1. /start - start bot\n2. /help - help bot\n3. /contacts",
            cancellationToken: ct);
        }

        public static async Task ContactCommand(ITelegramBotClient bot, Message message, CancellationToken ct)
        {
            long chatId = message.Chat.Id;
            await bot.SendMessage(chatId,
            text: "Контакты разработчиков: ТГ: @Faykrill",
            cancellationToken: ct);
        }
    }
}
