using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MicroMsg.sdk;
using System.Windows.Resources;
using System.IO;
using System.IO.IsolatedStorage;

namespace MicroMsg_Emotion_Center
{
    public partial class EmojiPicker2 : PhoneApplicationPage
    {
        private GetMessageFromWX.Req mRequest;
        public EmojiPicker2()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
        private void Button_Click_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string AppID = AppConfig.wechatID;
            int scene = SendMessageToWX.Req.WXSceneSession; 
            WXBaseMessage message = null;
            string data = "";
            if (IsolatedStorageSettings.ApplicationSettings.Contains("ChoosedByUser"))
            {
                scene = SendMessageToWX.Req.WXSceneChooseByUser;
            }
            if (sender == p1)
            {
                data = "1";
            }
            else if (sender == p2)
            {
                data = "2";
            }
            else if (sender == p3)
            {
                data = "3";
            }
            else if (sender == p4)
            {
                data = "4";
            }
            else if (sender == p5)
            {
                data = "5";
            }
            else if (sender == p6)
            {
                data = "6";
            }
            else if (sender == p7)
            {
                data = "7";
            }
            else if (sender == p8)
            {
                data = "8";
            }
            else if (sender == p9)
            {
                data = "9";
            }
            else if (sender == p10)
            {
                data = "10";
            }
            else if (sender == p11)
            {
                data = "11";
            }
            else if (sender == p12)
            {
                data = "12";
            }
            else if (sender == p13)
            {
                data = "13";
            }
            else if (sender == p14)
            {
                data = "14";
            }
            else if (sender == p15)
            {
                data = "15";
            }
            else if (sender == p16)
            {
                data = "16";
            }
            else if (sender == p17)
            {
                data = "17";
            }
            else if (sender == p18)
            {
                data = "18";
            }
            else if (sender == p19)
            {
                data = "19";
            }
            else if (sender == p20)
            {
                data = "20";
            }
            
            byte[] thumb = readRes("Res/cute_thumb/" + data + ".png");
            byte[] emoji = readRes("Res/cute/" + data + ".png");
            WXEmojiMessage msg = new WXEmojiMessage();
            msg.Title = "微信工具箱,只属于WP";
            msg.Description = "可爱表情";
            msg.ThumbData = thumb;
            msg.EmojiData = emoji;

            message = msg;
            try
            {
                SendMessageToWX.Req req = new SendMessageToWX.Req(message, scene);
                IWXAPI api = WXAPIFactory.CreateWXAPI(AppID);

                Console.WriteLine("api.SendReq in");
                api.SendReq(req);
            }
            catch (WXException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private byte[] readRes(string path)
        {
            StreamResourceInfo info = App.GetResourceStream(new Uri(path, UriKind.Relative));
            if (info == null) return null;
            Stream stream = info.Stream;
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, (int)stream.Length);
            return data;
        }

    }
}