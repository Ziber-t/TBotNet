using System;
//using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Runtime.Remoting.Channels;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tbot
{
    public partial class Form1 : Form
    {
        private BackgroundWorker bw;
        public Form1()
        {
            InitializeComponent();
            this.bw = new BackgroundWorker();
            this.bw.DoWork += this.bw_DoWork;
            textKey.Text = "713280704:AAEwVpLB0TpcLQHYSyaVx0vGDzC456gmhmE";
        }

        async void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var key = e.Argument as String;
            try
            {
                var Bot = new Telegram.Bot.TelegramBotClient(key);
                Console.WriteLine(key);
                await Bot.SetWebhookAsync("");
                int offset = 0;
                while (true)
                {
                    var updates = await Bot.GetUpdatesAsync(offset);
                    foreach (var update in updates)
                    {
                        var message = update.Message;
                        if (message != null && message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                        {
                            //if (message.Text == "/say")
                            //{
                            //    await Bot.SendTextMessageAsync(message.Chat.Id, "Здарова",
                            //        replyToMessageId: message.MessageId);
                            //}

                            switch (message.Text)
                            {
                                case "/say":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Здарова",
                                        replyToMessageId: message.MessageId);
                                    break;
                                case "/ты работаешь?":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Да, блять! Че ты хочешь?",
                                        replyToMessageId: message.MessageId);
                                    break;
                                case "/Ты работаешь?":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Да, блять! Че ты хочешь?",
                                        replyToMessageId: message.MessageId);
                                    break;
                                case "/ты работаешь":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Да, блять! Че ты хочешь?",
                                        replyToMessageId: message.MessageId);
                                    break;
                                case "/gena":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Гена - тыжпрограммист",
                                        replyToMessageId: message.MessageId);
                                    break;
                                case "Фристайло":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Ракамакафо!",
                                        replyToMessageId: message.MessageId);
                                    break;
                                case "/misha":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Моя броня 99 миллиметров! Что хочу ,то ворочу!",
                                        replyToMessageId: message.MessageId);
                                    break;
                                case "/help":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "/say \n /gena \n /rost \n /kat \n /ты работаешь?\n /misha \n /user \n",
                                        replyToMessageId: message.MessageId);
                                    break;
                                case "/user":
                                    //await Bot.SendTextMessageAsync(message.Chat.Id, message.From.FirstName,
                                    //    replyToMessageId: message.MessageId);
                                    if (message.From.FirstName != null )
                                    {
                                        await Bot.SendTextMessageAsync(message.Chat.Id, message.From.FirstName+"\n"+message.From.Id+"\n"+message.From.LastName+"\n",
                                            replyToMessageId: message.MessageId);
                                    }
                                   
                                    break;
                                case "/rost":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Медузаааа! Кутузав - без глАза!",
                                        replyToMessageId: message.MessageId);
                                    break;
                                case "/nik":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, " Так Promise или нет?)",
                                        replyToMessageId: message.MessageId);
                                    break;
                                case "/kat":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Катя пошла по шляпам!)",
                                        replyToMessageId: message.MessageId);
                                    break;
                                case "/getIP":
                                    string pubIp = new System.Net.WebClient().DownloadString("https://api.ipify.org");
                                    await Bot.SendTextMessageAsync(message.Chat.Id,pubIp,replyToMessageId:message.MessageId);
                                    break;
                                default:
                                    //await Bot.SendTextMessageAsync(message.Chat.Id, "Что то пошло не так...",
                                    //    replyToMessageId: message.MessageId);
                                    break;
                            }
                        }
                        //Console.WriteLine(update.Type);
                        offset = update.Id + 1;
                    }
                }
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        void BtnRunClick(object sender, EventArgs e)
        {
            var text = textKey.Text;
            if (this.bw.IsBusy != true)
            {
                this.bw.RunWorkerAsync(text);
                MessageBox.Show("Run");
            }
        }
    }
}
