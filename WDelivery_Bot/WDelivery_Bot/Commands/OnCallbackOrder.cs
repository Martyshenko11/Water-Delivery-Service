using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Telegram.Bot.Args;
using WDelivery_Bot.Model;
using WDelivery_Bot.Keyboards;
using Newtonsoft.Json;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;

namespace WDelivery_Bot.Commands
{
    class OnCallbackOrder
    {
        public static async void OnClientOnCallbackQuery(object sender, CallbackQueryEventArgs ev)
        {

            string apiAddress = $"https://apiwaterdelivery.azurewebsites.net";//"https://localhost:44347"; //"https://wdeliveryapi.azurewebsites.net";
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiAddress);

            var message = ev.CallbackQuery.Message;



            if (ev.CallbackQuery.Data == "Помпa")
            {
                var person = new OrderBrandResponse();

                person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                person.Water_Brand = "Помпa";

                var json = JsonConvert.SerializeObject(person);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var patch = await client.PatchAsync("Order/update/water_brand", data);

                var patchcontent = patch.Content.ReadAsStringAsync().Result;

                Console.WriteLine(patchcontent);


                    await Program.client.SendPhotoAsync(
             chatId: ev.CallbackQuery.Message.Chat,
             photo: "https://content.rozetka.com.ua/goods/images/big/283802252.jpg",
             replyMarkup: MainButtons.GetButtons());


                await Program.client.EditMessageReplyMarkupAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               messageId: ev.CallbackQuery.Message.MessageId,
               replyMarkup: null);

                await Program.SendInlineKeyboard(
               chatId: ev.CallbackQuery.Message.Chat.Id,
               text: "*Помпa* \n\nЦіна: 80 грн - 20 л., 48 грн - 12 л. або ж 40 грн - 10 л. відповідно. \n\n" +
               "Використовується для бутлів 20 л. (5 галонів), для бутля 12 л. (3 галона) та для бутля 10 літрів, працює при натисканні рукою" +
               "на верхній стакан-кнопку. Помпа виробляється в біло/блакитному кольорі 🚰",
               inlineKeyboard: Inline.VolumeKeyboard);


                    try
                    {
                        await Program.client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id);
                    }
                    catch (Telegram.Bot.Exceptions.InvalidParameterException)
                    {
                        Console.WriteLine("Telegram.Bot.Exceptions.InvalidParameterException");
                        await Program.client.SendTextMessageAsync(chatId: ev.CallbackQuery.Message.Chat, "There is something wrong, please repeat your request.", replyMarkup: MainButtons.GetButtons());
                    }

            }


            else if (ev.CallbackQuery.Data == "Bissleri")
            {
                var person = new OrderBrandResponse();

                person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                person.Water_Brand = "Bissleri";

                var json = JsonConvert.SerializeObject(person);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var patch = await client.PatchAsync("Order/update/water_brand", data);

                var patchcontent = patch.Content.ReadAsStringAsync().Result;

                Console.WriteLine(patchcontent);


                    await Program.client.SendPhotoAsync(
             chatId: ev.CallbackQuery.Message.Chat,
             photo: "https://i2.wp.com/bookacan.com/wp-content/uploads/2015/11/kingfisher-20liter-250x3001.png?fit=250%2C375&ssl=1",
             replyMarkup: MainButtons.GetButtons());

                await Program.client.EditMessageReplyMarkupAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               messageId: ev.CallbackQuery.Message.MessageId,
               replyMarkup: null);

                await Program.SendInlineKeyboard(
               chatId: ev.CallbackQuery.Message.Chat.Id,
               text: "Вода *Bissleri*\n\nЦіна: 80 грн - 20 л., 48 грн - 12 л. або ж 40 грн - 10 л. відповідно. \n\nУ тарі місткістю 20, 12 або 10 л з " +
               "оптимальним вмістом мінеральних речовин, природна, негазована, без консервантів, без введення будь-яких мікро- та макроелементів 💠", 
               inlineKeyboard: Inline.VolumeKeyboard);


                    try
                    {
                        await Program.client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id);
                    }
                    catch (Telegram.Bot.Exceptions.InvalidParameterException)
                    {
                        Console.WriteLine("Telegram.Bot.Exceptions.InvalidParameterException");
                        await Program.client.SendTextMessageAsync(chatId: ev.CallbackQuery.Message.Chat, "There is something wrong, please repeat your request.", replyMarkup: MainButtons.GetButtons());
                    }

            }
      
           
            else if (ev.CallbackQuery.Data == "Natture")
            {
                var person = new OrderBrandResponse();

                person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                person.Water_Brand = "Natture";

                var json = JsonConvert.SerializeObject(person);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var patch = await client.PatchAsync("Order/update/water_brand", data);

                var patchcontent = patch.Content.ReadAsStringAsync().Result;

                Console.WriteLine(patchcontent);



                    await Program.client.SendPhotoAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               photo: "https://i0.wp.com/bookacan.com/wp-content/uploads/2019/04/download-1.png?w=300&ssl=1",
               replyMarkup: MainButtons.GetButtons());


                await Program.client.EditMessageReplyMarkupAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               messageId: ev.CallbackQuery.Message.MessageId,
               replyMarkup: null);

                await Program.SendInlineKeyboard(
               chatId: ev.CallbackQuery.Message.Chat.Id,
               text: "Вода *Natture*\n\nЦіна: 80 грн - 20 л., 48 грн - 12 л. або ж 40 грн - 10 л. відповідно. \n\nУ тарі місткістю 20, 12 або 10 л з " +
               "оптимальним вмістом мінеральних речовин, природна, негазована, без консервантів, без введення будь-яких мікро- та макроелементів 💠", 
               inlineKeyboard: Inline.VolumeKeyboard);


                    try
                    {
                        await Program.client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id);
                    }
                    catch (Telegram.Bot.Exceptions.InvalidParameterException)
                    {
                        Console.WriteLine("Telegram.Bot.Exceptions.InvalidParameterException");
                        await Program.client.SendTextMessageAsync(chatId: ev.CallbackQuery.Message.Chat, "There is something wrong, please repeat your request.", replyMarkup: MainButtons.GetButtons());
                    }

            }


            else if (ev.CallbackQuery.Data == "Jerrasic Water")
            {
                var person = new OrderBrandResponse();

                person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                person.Water_Brand = "Jerrasic Water";

                var json = JsonConvert.SerializeObject(person);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var patch = await client.PatchAsync("Order/update/water_brand", data);

                var patchcontent = patch.Content.ReadAsStringAsync().Result;

                Console.WriteLine(patchcontent);



                    await Program.client.SendPhotoAsync(
              chatId: ev.CallbackQuery.Message.Chat,
              photo: "https://i1.wp.com/bookacan.com/wp-content/uploads/2017/05/Jeevika-20-Litre-Water-Can-Home-Delivery.jpg?w=300&ssl=1",
              replyMarkup: MainButtons.GetButtons());


                await Program.client.EditMessageReplyMarkupAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               messageId: ev.CallbackQuery.Message.MessageId,
               replyMarkup: null);

                await Program.SendInlineKeyboard(
               chatId: ev.CallbackQuery.Message.Chat.Id,
               text: "Вода *Jerrasic Water*\n\nЦіна: 80 грн - 20 л., 48 грн - 12 л. або ж 40 грн - 10 л. відповідно. \n\nУ тарі місткістю 20, 12 або 10 л з " +
               "оптимальним вмістом мінеральних речовин, природна, негазована, без консервантів, без введення будь-яких мікро- та макроелементів 💠",
               inlineKeyboard: Inline.VolumeKeyboard);


                    try
                    {
                        await Program.client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id);
                    }
                    catch (Telegram.Bot.Exceptions.InvalidParameterException)
                    {
                        Console.WriteLine("Telegram.Bot.Exceptions.InvalidParameterException");
                        await Program.client.SendTextMessageAsync(chatId: ev.CallbackQuery.Message.Chat, "There is something wrong, please repeat your request.", replyMarkup: MainButtons.GetButtons());
                    }

            }


            else if (ev.CallbackQuery.Data == "20 л.")
            {
             
                var person = new OrderVolumeResponse();

                person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                person.Volume = "20";

                var json = JsonConvert.SerializeObject(person);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var patch = await client.PatchAsync("Order/update/volume", data);

                var patchcontent = patch.Content.ReadAsStringAsync().Result;

                Console.WriteLine(patchcontent);

                await Program.client.EditMessageReplyMarkupAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               messageId: ev.CallbackQuery.Message.MessageId,
               replyMarkup: null);

                if (ev.CallbackQuery.From.Id != 1)
                {
                    await Program.client.SendTextMessageAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               text: "Введіть бажану кількість.\n" +
                "🛑 Зверніть увагу, максимальна кількість данного товару не може бути більше 15 🛑",
               replyMarkup: new ForceReplyMarkup() { Selective = true });
                }
                else
                {
                     await Program.client.SendTextMessageAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               text: "Введіть бажану кількість.",
               replyMarkup: new ForceReplyMarkup() { Selective = true });
                }

                    try
                    {
                        await Program.client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id);
                    }
                    catch (Telegram.Bot.Exceptions.InvalidParameterException)
                    {
                        Console.WriteLine("Telegram.Bot.Exceptions.InvalidParameterException");
                        await Program.client.SendTextMessageAsync(chatId: ev.CallbackQuery.Message.Chat, "There is something wrong, please repeat your request.", replyMarkup: MainButtons.GetButtons());
                    }
            }


            else if (ev.CallbackQuery.Data == "12 л.")
            {

                var person = new OrderVolumeResponse();

                person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                person.Volume = "12";

                var json = JsonConvert.SerializeObject(person);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var patch = await client.PatchAsync("Order/update/volume", data);

                var patchcontent = patch.Content.ReadAsStringAsync().Result;

                Console.WriteLine(patchcontent);

                await Program.client.EditMessageReplyMarkupAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               messageId: ev.CallbackQuery.Message.MessageId,
               replyMarkup: null);

                if (ev.CallbackQuery.From.Id != 1)
                {
                    await Program.client.SendTextMessageAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               text: "Введіть бажану кількість.\n" +
                "🛑 Зверніть увагу, максимальна кількість данного товару не може бути більше 15 🛑",
               replyMarkup: new ForceReplyMarkup() { Selective = true });
                }
                else
                {
                    await Program.client.SendTextMessageAsync(
              chatId: ev.CallbackQuery.Message.Chat,
              text: "Введіть бажану кількість.",
              replyMarkup: new ForceReplyMarkup() { Selective = true });
                }

                    try
                    {
                        await Program.client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id);
                    }
                    catch (Telegram.Bot.Exceptions.InvalidParameterException)
                    {
                        Console.WriteLine("Telegram.Bot.Exceptions.InvalidParameterException");
                        await Program.client.SendTextMessageAsync(chatId: ev.CallbackQuery.Message.Chat, "There is something wrong, please repeat your request.", replyMarkup: MainButtons.GetButtons());
                    }

            }


            else if (ev.CallbackQuery.Data == "10 л.")
            {

                var person = new OrderVolumeResponse();

                person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                person.Volume = "10";

                var json = JsonConvert.SerializeObject(person);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var patch = await client.PatchAsync("Order/update/volume", data);

                var patchcontent = patch.Content.ReadAsStringAsync().Result;

                Console.WriteLine(patchcontent);

                await Program.client.EditMessageReplyMarkupAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               messageId: ev.CallbackQuery.Message.MessageId,
               replyMarkup: null);

                if (ev.CallbackQuery.From.Id != 1)
                {
                    await Program.client.SendTextMessageAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               text: "Введіть бажану кількість.\n" +
                "🛑 Зверніть увагу, максимальна кількість данного товару не може бути більше 15 🛑",
               replyMarkup: new ForceReplyMarkup() { Selective = true });
                }
                else
                {
                    await Program.client.SendTextMessageAsync(
              chatId: ev.CallbackQuery.Message.Chat,
              text: "Введіть бажану кількість.",
              replyMarkup: new ForceReplyMarkup() { Selective = true });
                }


                    try
                    {
                        await Program.client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id);
                    }
                    catch (Telegram.Bot.Exceptions.InvalidParameterException)
                    {
                        Console.WriteLine("Telegram.Bot.Exceptions.InvalidParameterException");
                        await Program.client.SendTextMessageAsync(chatId: ev.CallbackQuery.Message.Chat, "There is something wrong, please repeat your request.", replyMarkup: MainButtons.GetButtons());
                    }

            }


            else if (ev.CallbackQuery.Data == "Назад до постачальників")
            {

                await Program.client.EditMessageReplyMarkupAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               messageId: ev.CallbackQuery.Message.MessageId,
               replyMarkup: Inline.MainOrderKeyboard);


                    try
                    {
                        await Program.client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id);
                    }
                    catch (Telegram.Bot.Exceptions.InvalidParameterException)
                    {
                        Console.WriteLine("Telegram.Bot.Exceptions.InvalidParameterException");
                        await Program.client.SendTextMessageAsync(chatId: ev.CallbackQuery.Message.Chat, "There is something wrong, please repeat your request.", replyMarkup: MainButtons.GetButtons());
                    }
            }



            else if (ev.CallbackQuery.Data == DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"))
            {

                string User_Id = Convert.ToString(ev.CallbackQuery.From.Id);

                var result = await client.GetAsync($"Order/get/totalorderinfo?User_Id={User_Id}");
                result.EnsureSuccessStatusCode();
                var content = result.Content.ReadAsStringAsync().Result;

                var info = JsonConvert.DeserializeObject<List<OrderTrashResponse>>(content);


                Console.WriteLine(ev.CallbackQuery.Message.Date.AddDays(1).ToShortDateString());


            foreach (var item in info)
            {
                var person = new OrderDateResponse();

                person.Order_Id = item.Order_Id;
                person.Order_Date = $"{ev.CallbackQuery.Message.Date.AddDays(1).ToShortDateString()}";

                var json = JsonConvert.SerializeObject(person);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var patch = await client.PatchAsync("Order/update/date", data);

                var patchcontent = patch.Content.ReadAsStringAsync().Result;

                Console.WriteLine(patchcontent);
                }

                await Program.client.EditMessageReplyMarkupAsync(
                chatId: ev.CallbackQuery.Message.Chat,
                messageId: ev.CallbackQuery.Message.MessageId,
                replyMarkup: Inline.DeliveryTime);



                    try
                    {
                        await Program.client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id);
                    }
                    catch (Telegram.Bot.Exceptions.InvalidParameterException)
                    {
                        Console.WriteLine("Telegram.Bot.Exceptions.InvalidParameterException");
                        await Program.client.SendTextMessageAsync(chatId: ev.CallbackQuery.Message.Chat, "There is something wrong, please repeat your request.", replyMarkup: MainButtons.GetButtons());
                    }
            }


            else if (ev.CallbackQuery.Data == DateTime.Now.AddDays(2).ToString("dd.MM.yyyy"))
            {
                string User_Id = Convert.ToString(ev.CallbackQuery.From.Id);

                var result = await client.GetAsync($"Order/get/totalorderinfo?User_Id={User_Id}");
                result.EnsureSuccessStatusCode();
                var content = result.Content.ReadAsStringAsync().Result;

                var info = JsonConvert.DeserializeObject<List<OrderTrashResponse>>(content);


                Console.WriteLine(ev.CallbackQuery.Message.Date.AddDays(2).ToShortDateString());

                foreach (var item in info)
                {
                    var person = new OrderDateResponse();

                    person.Order_Id = item.Order_Id;
                    person.Order_Date = $"{ev.CallbackQuery.Message.Date.AddDays(2).ToShortDateString()}";

                    var json = JsonConvert.SerializeObject(person);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var patch = await client.PatchAsync("Order/update/date", data);

                    var patchcontent = patch.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(patchcontent);
                }

                await Program.client.EditMessageReplyMarkupAsync(
                chatId: ev.CallbackQuery.Message.Chat,
                messageId: ev.CallbackQuery.Message.MessageId,
                replyMarkup: Inline.DeliveryTime);


                    try
                    {
                        await Program.client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id);
                    }
                    catch (Telegram.Bot.Exceptions.InvalidParameterException)
                    {
                        Console.WriteLine("Telegram.Bot.Exceptions.InvalidParameterException");
                        await Program.client.SendTextMessageAsync(chatId: ev.CallbackQuery.Message.Chat, "There is something wrong, please repeat your request.", replyMarkup: MainButtons.GetButtons());
                    }
            }


            else if (ev.CallbackQuery.Data == "9:00 - 12:00")
            {
                string User_Id = Convert.ToString(ev.CallbackQuery.From.Id);

                var result = await client.GetAsync($"Order/get/totalorderinfo?User_Id={User_Id}");
                result.EnsureSuccessStatusCode();
                var content = result.Content.ReadAsStringAsync().Result;

                var info = JsonConvert.DeserializeObject<List<OrderTrashResponse>>(content);


                foreach (var item in info)
                {
                    var person = new OrderTimeResponse();

                    person.Order_Id = item.Order_Id;
                    person.Order_Time = $"9:00 - 12:00";

                    var json = JsonConvert.SerializeObject(person);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var patch = await client.PatchAsync("Order/update/time", data);

                    var patchcontent = patch.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(patchcontent);
                }


                var person_checker = new UserStatusResponse();

                person_checker.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                if (ev.CallbackQuery.From.Id != 1)
                {
                    person_checker.Checker = "OK";
                }
                else
                {
                    person_checker.Checker = "Approved";

                }

                var json_checker = JsonConvert.SerializeObject(person_checker);
                var data_checker = new StringContent(json_checker, Encoding.UTF8, "application/json");

                var patch_cheker = await client.PatchAsync("Admin/update/checker", data_checker);

                var patchcontent_checker = patch_cheker.Content.ReadAsStringAsync().Result;

                Console.WriteLine(patchcontent_checker);



                var result_address = await client.GetAsync($"Order/get/useraddress?User_Id={ev.CallbackQuery.From.Id}");
                result_address.EnsureSuccessStatusCode();
                var content_address = result_address.Content.ReadAsStringAsync().Result;

                var info_address = JsonConvert.DeserializeObject<UserAddressResponse>(content_address);


                var result_city_address = await client.GetAsync($"Order/get/usercityaddress?User_Id={ev.CallbackQuery.From.Id}");
                result_city_address.EnsureSuccessStatusCode();
                var content_city_address = result_city_address.Content.ReadAsStringAsync().Result;

                var info_city_address = JsonConvert.DeserializeObject<UserCityResponse>(content_city_address);



                string User_Id_TotalInfo = Convert.ToString(ev.CallbackQuery.From.Id);

                var result_totalinfo = await client.GetAsync($"Order/get/totalorderinfo?User_Id={User_Id_TotalInfo}");
                result_totalinfo.EnsureSuccessStatusCode();
                var content_totalinfo = result_totalinfo.Content.ReadAsStringAsync().Result;

                var info_totalinfo = JsonConvert.DeserializeObject<List<OrderTrashResponse>>(content_totalinfo);

                var result_items_info = "";
                var total_sum_totalinfo = 0;
                var total_date = "";
                var total_time = "";
                var total_order_id = "";


                foreach (var item in info_totalinfo)
                {
                    result_items_info += item.Water_Brand + "\nКількість: " + item.Num_Water + " шт." + "\nЛітраж: " + item.Volume + " л." +
                        "\nЦіна: " + item.Price + "грн\n\n";
                    total_sum_totalinfo += Convert.ToInt32(item.Price);
                    total_date = item.Order_Date;
                    total_time = item.Order_Time;
                    total_order_id = item.Order_Id;
                }

                var total_order_id_accounting = Guid.NewGuid().ToString();
                var result_items_info_accounting = result_items_info;
                var total_sum_totalinfo_accounting = Convert.ToString(total_sum_totalinfo);
                var total_date_accounting = total_date;
                var total_time_accounting = total_time;
                
                var user_id_accounting = Convert.ToString(ev.CallbackQuery.From.Id);



                var result_for_info = await client.GetAsync($"Admin/get/userinfobyid?User_Id={ev.CallbackQuery.From.Id}");
                result_for_info.EnsureSuccessStatusCode();
                var content_for_info = result_for_info.Content.ReadAsStringAsync().Result;

                var info_for_info = JsonConvert.DeserializeObject<UserVerifyResponse>(content_for_info);



                var person_accounting = new AccountingDbRepository();

                person_accounting.Order_Id = total_order_id_accounting;
                person_accounting.Summary = result_items_info_accounting;
                person_accounting.Price = total_sum_totalinfo_accounting;
                person_accounting.Date_Acco = total_date_accounting;
                person_accounting.Time_Acco = total_time_accounting;
                person_accounting.Address = info_address.Address;
                person_accounting.City = info_city_address.City;
                person_accounting.Phone = info_for_info.Phone;
                if (ev.CallbackQuery.From.Id == 1)
                {
                    person_accounting.User_Id = person_accounting.Phone;
                }
                else {
                    person_accounting.User_Id = user_id_accounting;
                }
                

                    var json_accounting = JsonConvert.SerializeObject(person_accounting);
                    var data_accounting = new StringContent(json_accounting, Encoding.UTF8, "application/json");

                    var patch_accounting = await client.PatchAsync("Admin/update/accounting", data_accounting);

                    var patchcontent_accounting = patch_accounting.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(patchcontent_accounting);


                string User_Id_delete = Convert.ToString(ev.CallbackQuery.From.Id);

                var result_delete = await client.GetAsync($"Order/get/totalorderinfo?User_Id={User_Id_delete}");
                result_delete.EnsureSuccessStatusCode();
                var content_delete = result_delete.Content.ReadAsStringAsync().Result;

                var info_delete = JsonConvert.DeserializeObject<List<OrderTrashResponse>>(content_delete);


                foreach (var item in info_delete)
                {
                    var delete_trash = await client.DeleteAsync($"Order/delete/orderinfo?User_Id={item.Order_Id}");
                }


                if (ev.CallbackQuery.From.Id == 1)
                {
                    var person = new UserPhoneResponse();

                    person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                    person.Phone = "null";

                    var json = JsonConvert.SerializeObject(person);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var patch = await client.PatchAsync("Main/update/phone", data);

                    var patchcontent = patch.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(patchcontent);

                }

                if (ev.CallbackQuery.From.Id == 1)
                {
                    var person = new UserAddressResponse();

                    person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                    person.Address = "null";

                        var json = JsonConvert.SerializeObject(person);
                        var data = new StringContent(json, Encoding.UTF8, "application/json");

                        var patch = await client.PatchAsync("Main/update/address", data);

                        var patchcontent = patch.Content.ReadAsStringAsync().Result;

                        Console.WriteLine(patchcontent);
                  
                }

                if (ev.CallbackQuery.From.Id == 1)
                {
                    var person = new UserCityResponse();

                    person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                    person.City = "null";

                    var json = JsonConvert.SerializeObject(person);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var patch = await client.PatchAsync("Main/update/city", data);

                    var patchcontent = patch.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(patchcontent);
                }



                    await Program.client.SendTextMessageAsync(
                             chatId: ev.CallbackQuery.Message.Chat,
                             text: "Замовлення створено ✅",
                             replyMarkup: MainButtons.GetButtons());

                await Program.client.EditMessageReplyMarkupAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               messageId: ev.CallbackQuery.Message.MessageId,
               replyMarkup: null);


                    try
                    {
                        await Program.client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id);
                    }
                    catch (Telegram.Bot.Exceptions.InvalidParameterException)
                    {
                        Console.WriteLine("Telegram.Bot.Exceptions.InvalidParameterException");
                        await Program.client.SendTextMessageAsync(chatId: ev.CallbackQuery.Message.Chat, "There is something wrong, please repeat your request.", replyMarkup: MainButtons.GetButtons());
                    }
            }


            else if (ev.CallbackQuery.Data == "12:00 - 15:00")
            {
                string User_Id = Convert.ToString(ev.CallbackQuery.From.Id);

                var result = await client.GetAsync($"Order/get/totalorderinfo?User_Id={User_Id}");
                result.EnsureSuccessStatusCode();
                var content = result.Content.ReadAsStringAsync().Result;

                var info = JsonConvert.DeserializeObject<List<OrderTrashResponse>>(content);


                foreach (var item in info)
                {
                    var person = new OrderTimeResponse();

                    person.Order_Id = item.Order_Id;
                    person.Order_Time = $"12:00 - 15:00";

                    var json = JsonConvert.SerializeObject(person);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var patch = await client.PatchAsync("Order/update/time", data);

                    var patchcontent = patch.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(patchcontent);
                }


                var person_checker = new UserStatusResponse();

                person_checker.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                if (ev.CallbackQuery.From.Id != 1)
                {
                    person_checker.Checker = "OK";
                }
                else
                {
                    person_checker.Checker = "Approved";

                }
                var json_checker = JsonConvert.SerializeObject(person_checker);
                var data_checker = new StringContent(json_checker, Encoding.UTF8, "application/json");

                var patch_cheker = await client.PatchAsync("Admin/update/checker", data_checker);

                var patchcontent_checker = patch_cheker.Content.ReadAsStringAsync().Result;

                Console.WriteLine(patchcontent_checker);



                var result_address = await client.GetAsync($"Order/get/useraddress?User_Id={ev.CallbackQuery.From.Id}");
                result_address.EnsureSuccessStatusCode();
                var content_address = result_address.Content.ReadAsStringAsync().Result;

                var info_address = JsonConvert.DeserializeObject<UserAddressResponse>(content_address);


                var result_city_address = await client.GetAsync($"Order/get/usercityaddress?User_Id={ev.CallbackQuery.From.Id}");
                result_city_address.EnsureSuccessStatusCode();
                var content_city_address = result_city_address.Content.ReadAsStringAsync().Result;

                var info_city_address = JsonConvert.DeserializeObject<UserCityResponse>(content_city_address);



                string User_Id_TotalInfo = Convert.ToString(ev.CallbackQuery.From.Id);

                var result_totalinfo = await client.GetAsync($"Order/get/totalorderinfo?User_Id={User_Id_TotalInfo}");
                result_totalinfo.EnsureSuccessStatusCode();
                var content_totalinfo = result_totalinfo.Content.ReadAsStringAsync().Result;

                var info_totalinfo = JsonConvert.DeserializeObject<List<OrderTrashResponse>>(content_totalinfo);

                var result_items_info = "";
                var total_sum_totalinfo = 0;
                var total_date = "";
                var total_time = "";
                var total_order_id = "";


                foreach (var item in info_totalinfo)
                {
                    result_items_info += item.Water_Brand + "\nКількість: " + item.Num_Water + " шт." + "\nЛітраж: " + item.Volume + " л." +
                        "\nЦіна: " + item.Price + "грн\n\n";
                    total_sum_totalinfo += Convert.ToInt32(item.Price);
                    total_date = item.Order_Date;
                    total_time = item.Order_Time;
                    total_order_id = item.Order_Id;
                }

                var total_order_id_accounting = Guid.NewGuid().ToString();
                var result_items_info_accounting = result_items_info;
                var total_sum_totalinfo_accounting = Convert.ToString(total_sum_totalinfo);
                var total_date_accounting = total_date;
                var total_time_accounting = total_time;

                var user_id_accounting = Convert.ToString(ev.CallbackQuery.From.Id);




                var result_for_info = await client.GetAsync($"Admin/get/userinfobyid?User_Id={ev.CallbackQuery.From.Id}");
                result_for_info.EnsureSuccessStatusCode();
                var content_for_info = result_for_info.Content.ReadAsStringAsync().Result;

                var info_for_info = JsonConvert.DeserializeObject<UserVerifyResponse>(content_for_info);

                var person_accounting = new AccountingDbRepository();

                person_accounting.Order_Id = total_order_id_accounting;
                person_accounting.Summary = result_items_info_accounting;
                person_accounting.Price = total_sum_totalinfo_accounting;
                person_accounting.Date_Acco = total_date_accounting;
                person_accounting.Time_Acco = total_time_accounting;
                person_accounting.Address = info_address.Address;
                person_accounting.City = info_city_address.City;
                person_accounting.Phone = info_for_info.Phone;
                if (ev.CallbackQuery.From.Id == 1)
                {
                    person_accounting.User_Id = person_accounting.Phone;
                }
                else
                {
                    person_accounting.User_Id = user_id_accounting;
                }

                var json_accounting = JsonConvert.SerializeObject(person_accounting);
                var data_accounting = new StringContent(json_accounting, Encoding.UTF8, "application/json");

                var patch_accounting = await client.PatchAsync("Admin/update/accounting", data_accounting);

                var patchcontent_accounting = patch_accounting.Content.ReadAsStringAsync().Result;

                Console.WriteLine(patchcontent_accounting);


                string User_Id_delete = Convert.ToString(ev.CallbackQuery.From.Id);

                var result_delete = await client.GetAsync($"Order/get/totalorderinfo?User_Id={User_Id_delete}");
                result_delete.EnsureSuccessStatusCode();
                var content_delete = result_delete.Content.ReadAsStringAsync().Result;

                var info_delete = JsonConvert.DeserializeObject<List<OrderTrashResponse>>(content_delete);


                foreach (var item in info_delete)
                {
                    var delete_trash = await client.DeleteAsync($"Order/delete/orderinfo?User_Id={item.Order_Id}");
                }


                if (ev.CallbackQuery.From.Id == 1)
                {
                    var person = new UserPhoneResponse();

                    person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                    person.Phone = "null";

                    var json = JsonConvert.SerializeObject(person);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var patch = await client.PatchAsync("Main/update/phone", data);

                    var patchcontent = patch.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(patchcontent);

                }

                if (ev.CallbackQuery.From.Id == 1)
                {
                    var person = new UserAddressResponse();

                    person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                    person.Address = "null";

                    var json = JsonConvert.SerializeObject(person);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var patch = await client.PatchAsync("Main/update/address", data);

                    var patchcontent = patch.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(patchcontent);

                }

                if (ev.CallbackQuery.From.Id == 1)
                {
                    var person = new UserCityResponse();

                    person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                    person.City = "null";

                    var json = JsonConvert.SerializeObject(person);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var patch = await client.PatchAsync("Main/update/city", data);

                    var patchcontent = patch.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(patchcontent);
                }


                await Program.client.SendTextMessageAsync(
                         chatId: ev.CallbackQuery.Message.Chat,
                         text: "Замовлення створено ✅",
                         replyMarkup: MainButtons.GetButtons());

                await Program.client.EditMessageReplyMarkupAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               messageId: ev.CallbackQuery.Message.MessageId,
               replyMarkup: null);


                    try
                    {
                        await Program.client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id);
                    }
                    catch (Telegram.Bot.Exceptions.InvalidParameterException)
                    {
                        Console.WriteLine("Telegram.Bot.Exceptions.InvalidParameterException");
                        await Program.client.SendTextMessageAsync(chatId: ev.CallbackQuery.Message.Chat, "There is something wrong, please repeat your request.", replyMarkup: MainButtons.GetButtons());
                    }
            }
        


            else if (ev.CallbackQuery.Data == "15:00 - 18:00")
            {
                string User_Id = Convert.ToString(ev.CallbackQuery.From.Id);

                var result = await client.GetAsync($"Order/get/totalorderinfo?User_Id={User_Id}");
                result.EnsureSuccessStatusCode();
                var content = result.Content.ReadAsStringAsync().Result;

                var info = JsonConvert.DeserializeObject<List<OrderTrashResponse>>(content);


                foreach (var item in info)
                {
                    var person = new OrderTimeResponse();

                    person.Order_Id = item.Order_Id;
                    person.Order_Time = $"15:00 - 18:00";

                    var json = JsonConvert.SerializeObject(person);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var patch = await client.PatchAsync("Order/update/time", data);

                    var patchcontent = patch.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(patchcontent);
                }


                var person_checker = new UserStatusResponse();

                person_checker.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                if (ev.CallbackQuery.From.Id != 1)
                {
                    person_checker.Checker = "OK";
                }
                else
                {
                    person_checker.Checker = "Approved";

                }
                var json_checker = JsonConvert.SerializeObject(person_checker);
                var data_checker = new StringContent(json_checker, Encoding.UTF8, "application/json");

                var patch_cheker = await client.PatchAsync("Admin/update/checker", data_checker);

                var patchcontent_checker = patch_cheker.Content.ReadAsStringAsync().Result;

                Console.WriteLine(patchcontent_checker);



                var result_address = await client.GetAsync($"Order/get/useraddress?User_Id={ev.CallbackQuery.From.Id}");
                result_address.EnsureSuccessStatusCode();
                var content_address = result_address.Content.ReadAsStringAsync().Result;

                var info_address = JsonConvert.DeserializeObject<UserAddressResponse>(content_address);


                var result_city_address = await client.GetAsync($"Order/get/usercityaddress?User_Id={ev.CallbackQuery.From.Id}");
                result_city_address.EnsureSuccessStatusCode();
                var content_city_address = result_city_address.Content.ReadAsStringAsync().Result;

                var info_city_address = JsonConvert.DeserializeObject<UserCityResponse>(content_city_address);


                string User_Id_TotalInfo = Convert.ToString(ev.CallbackQuery.From.Id);

                var result_totalinfo = await client.GetAsync($"Order/get/totalorderinfo?User_Id={User_Id_TotalInfo}");
                result_totalinfo.EnsureSuccessStatusCode();
                var content_totalinfo = result_totalinfo.Content.ReadAsStringAsync().Result;

                var info_totalinfo = JsonConvert.DeserializeObject<List<OrderTrashResponse>>(content_totalinfo);

                var result_items_info = "";
                var total_sum_totalinfo = 0;
                var total_date = "";
                var total_time = "";
                var total_order_id = "";


                foreach (var item in info_totalinfo)
                {
                    result_items_info += item.Water_Brand + "\nКількість: " + item.Num_Water + " шт." + "\nЛітраж: " + item.Volume + " л." +
                        "\nЦіна: " + item.Price + "грн\n\n";
                    total_sum_totalinfo += Convert.ToInt32(item.Price);
                    total_date = item.Order_Date;
                    total_time = item.Order_Time;
                    total_order_id = item.Order_Id;
                }

                var total_order_id_accounting = Guid.NewGuid().ToString();
                var result_items_info_accounting = result_items_info;
                var total_sum_totalinfo_accounting = Convert.ToString(total_sum_totalinfo);
                var total_date_accounting = total_date;
                var total_time_accounting = total_time;

                var user_id_accounting = Convert.ToString(ev.CallbackQuery.From.Id);



                var result_for_info = await client.GetAsync($"Admin/get/userinfobyid?User_Id={ev.CallbackQuery.From.Id}");
                result_for_info.EnsureSuccessStatusCode();
                var content_for_info = result_for_info.Content.ReadAsStringAsync().Result;

                var info_for_info = JsonConvert.DeserializeObject<UserVerifyResponse>(content_for_info);


                var person_accounting = new AccountingDbRepository();

                person_accounting.Order_Id = total_order_id_accounting;
                person_accounting.Summary = result_items_info_accounting;
                person_accounting.Price = total_sum_totalinfo_accounting;
                person_accounting.Date_Acco = total_date_accounting;
                person_accounting.Time_Acco = total_time_accounting;
                person_accounting.Address = info_address.Address;
                person_accounting.City = info_city_address.City;
                person_accounting.Phone = info_for_info.Phone;
                if (ev.CallbackQuery.From.Id == 1)
                {
                    person_accounting.User_Id = person_accounting.Phone;
                }
                else
                {
                    person_accounting.User_Id = user_id_accounting;
                }

                var json_accounting = JsonConvert.SerializeObject(person_accounting);
                var data_accounting = new StringContent(json_accounting, Encoding.UTF8, "application/json");

                var patch_accounting = await client.PatchAsync("Admin/update/accounting", data_accounting);

                var patchcontent_accounting = patch_accounting.Content.ReadAsStringAsync().Result;

                Console.WriteLine(patchcontent_accounting);


                string User_Id_delete = Convert.ToString(ev.CallbackQuery.From.Id);

                var result_delete = await client.GetAsync($"Order/get/totalorderinfo?User_Id={User_Id_delete}");
                result_delete.EnsureSuccessStatusCode();
                var content_delete = result_delete.Content.ReadAsStringAsync().Result;

                var info_delete = JsonConvert.DeserializeObject<List<OrderTrashResponse>>(content_delete);


                foreach (var item in info_delete)
                {
                    var delete_trash = await client.DeleteAsync($"Order/delete/orderinfo?User_Id={item.Order_Id}");
                }


                if (ev.CallbackQuery.From.Id == 1)
                {
                    var person = new UserPhoneResponse();

                    person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                    person.Phone = "null";

                    var json = JsonConvert.SerializeObject(person);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var patch = await client.PatchAsync("Main/update/phone", data);

                    var patchcontent = patch.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(patchcontent);

                }

                if (ev.CallbackQuery.From.Id == 1)
                {
                    var person = new UserAddressResponse();

                    person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                    person.Address = "null";

                    var json = JsonConvert.SerializeObject(person);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var patch = await client.PatchAsync("Main/update/address", data);

                    var patchcontent = patch.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(patchcontent);

                }

                if (ev.CallbackQuery.From.Id == 1)
                {
                    var person = new UserCityResponse();

                    person.User_Id = Convert.ToString(ev.CallbackQuery.From.Id);
                    person.City = "null";

                    var json = JsonConvert.SerializeObject(person);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var patch = await client.PatchAsync("Main/update/city", data);

                    var patchcontent = patch.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(patchcontent);
                }



                await Program.client.SendTextMessageAsync(
                         chatId: ev.CallbackQuery.Message.Chat,
                         text: "Замовлення створено ✅",
                         replyMarkup: MainButtons.GetButtons());

                await Program.client.EditMessageReplyMarkupAsync(
               chatId: ev.CallbackQuery.Message.Chat,
               messageId: ev.CallbackQuery.Message.MessageId,
               replyMarkup: null);


                    try
                    {
                        await Program.client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id);
                    }
                    catch (Telegram.Bot.Exceptions.InvalidParameterException)
                    {
                        Console.WriteLine("Telegram.Bot.Exceptions.InvalidParameterException");
                        await Program.client.SendTextMessageAsync(chatId: ev.CallbackQuery.Message.Chat, "There is something wrong, please repeat your request.", replyMarkup: MainButtons.GetButtons());
                    }
            }


        }
    }
}
