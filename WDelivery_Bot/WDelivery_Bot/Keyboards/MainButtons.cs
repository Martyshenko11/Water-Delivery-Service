using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace WDelivery_Bot.Keyboards
{
     class MainButtons
    {

        public static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "💧 Замовити" }, new KeyboardButton { Text = "🛒 Кошик" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "ℹ️ FAQ" }, new KeyboardButton { Text = "⚙️ Налаштування" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "🧾 Створені доставки" } }
                },
                ResizeKeyboard = true
            };
        }

        public static IReplyMarkup GetSettingsButtons()
        {
            return new ReplyKeyboardMarkup

            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "🌆 Мiсто" }, KeyboardButton.WithRequestContact("📱 Телефон") },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "🔙 Назад" }, new KeyboardButton { Text = "🏠 Адреса" } }
                },
                ResizeKeyboard = true
            };
        }

        public static IReplyMarkup GetSettingsButtonsForAdmin()
        {
            return new ReplyKeyboardMarkup

            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "🌆 Мiсто" }, new KeyboardButton { Text = "📱 Телефон" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "🔙 Назад" }, new KeyboardButton { Text = "🏠 Адреса" } }
                },
                ResizeKeyboard = true
            };
        }

        public static IReplyMarkup DeleteTrashItems()
        {
            return new ReplyKeyboardMarkup

            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "☑️ Додати інший товар" }, new KeyboardButton { Text = "❌ Видалити товари з корзини" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "💵 Оформити замовлення" }, new KeyboardButton { Text = "🔙 Назад" } }
                },
                ResizeKeyboard = true
            };
        }

        public static IReplyMarkup DeleteItemsAgree()
        {
            return new ReplyKeyboardMarkup

            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "☑️ Підтвердити видалення" }, new KeyboardButton { Text = "🔙 Скасувати видалення" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "🔙 Назад" } }
                },
                ResizeKeyboard = true
            };
        }

        public static IReplyMarkup SecondMenuItems()
        {
            return new ReplyKeyboardMarkup

            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "☑️ Додати інший товар" }, new KeyboardButton { Text = "🛒 Кошик" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "🔙 Назад" } }
                },
                ResizeKeyboard = true
            };
        }


        public static IReplyMarkup MenuWithInfo()
        {
            return new ReplyKeyboardMarkup

            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "💼 Про нас" }, new KeyboardButton { Text = "💲 Оплата" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "💧 Обмін тар" }, new KeyboardButton { Text = "🔄 Оновлення даних" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "🔙 Назад" }, new KeyboardButton { Text = "➕ Створення доставки" } }

                },
                ResizeKeyboard = true
            };
        }

        public static IReplyMarkup AdminKeyboard()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "🟢 Активні доставки" }, new KeyboardButton { Text = "🔍 Пошук доставки за Id" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "📲 Пошук користувача за номером" }, new KeyboardButton { Text = "🆔 Пошук користувача за Id" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "❌ Видалити доставку" }, new KeyboardButton { Text = "✅ Підтвердити доставку" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "📝 Облік продажів" }, new KeyboardButton { Text = "➕ Створити доставку" } }

                },
                ResizeKeyboard = true
            };
        }
    }
}
