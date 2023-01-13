using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading;
using Telegram.Bot.Examples.Polling;
using Telegram.Bot.Polling;


namespace Telegram_bot
{
    internal class Program
    {
        private static string token { get; set; } = "5855008572:AAGjfG2GTFHV_EkcDP4RJIIKTxrR-sy0HWQ";
        private static TelegramBotClient Bot;
        static void Main(string[] args)
        {
            Bot = new TelegramBotClient(token);

            using var cts = new CancellationTokenSource();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new() { AllowedUpdates = { } };
            Bot.StartReceiving(Handlers.HandleUpdateAsync,
                               Handlers.HandleErrorAsync,
                               receiverOptions,
                               cts.Token);

            Console.WriteLine($"Бот запущен и ждет сообщения...");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();
        }
    }
}