using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using WDelivery_Bot.Commands;


namespace WDelivery_Bot
{
    class Program
    {
        private static string Token { get; set; } = "";

        public static TelegramBotClient client;
        public static Dictionary<long, int> OpenOrderKeyboards = new Dictionary<long, int>();

        static void Main(string[] args)
        {
            client = new TelegramBotClient(Token);
            client.StartReceiving();
            client.OnMessage += OnHandle.OnMessageHandler;
            client.OnCallbackQuery += OnCallbackCity.OnClientOnCallbackQuery;
            client.OnCallbackQuery += OnCallbackOrder.OnClientOnCallbackQuery;
            Console.ReadLine();
            client.StopReceiving();
        }


        public static async Task RemovePreviousInlineKeyboard(long chatId)
        {
            if (OpenOrderKeyboards.ContainsKey(chatId))
            {
                int messageId = OpenOrderKeyboards[chatId];
                try
                {
                    await client.EditMessageReplyMarkupAsync(
                        chatId: chatId,
                        messageId: messageId,
                        replyMarkup: null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to remove previous inline keyboard: {ex.Message}");
                }
            }
        }

        public static async Task SendInlineKeyboard(long chatId, string text, InlineKeyboardMarkup inlineKeyboard)
        {
            await RemovePreviousInlineKeyboard(chatId);

            var message = await client.SendTextMessageAsync(
                chatId: chatId,
                text: text,
                replyMarkup: inlineKeyboard);

            if (OpenOrderKeyboards.ContainsKey(chatId))
            {
                OpenOrderKeyboards[chatId] = message.MessageId;
            }
            else
            {
                OpenOrderKeyboards.Add(chatId, message.MessageId);
            }
        }

    }
}