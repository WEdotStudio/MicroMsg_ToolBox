using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MicroMsg_Emotion_Center.Resources;
using Microsoft.Phone.Tasks;
using MicroMsg.sdk;
using System.Windows.Resources;
using System.IO;

namespace MicroMsg_Emotion_Center
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EmojiCenter.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FilePicker.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DialogSelecter.xaml", UriKind.Relative));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask mk = new MarketplaceReviewTask();
            mk.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string AppID = AppConfig.wechatID;
            int scene = SendMessageToWX.Req.WXSceneChooseByUser;
            WXBaseMessage message = null;
            WXWebpageMessage msg = new WXWebpageMessage();

            byte[] png = readRes("Assets/SquareTile71x71.png");
            msg.Title = "微信工具箱WP版";
            msg.Description = "你的微信好助手";
            msg.ThumbData = png;

            msg.WebpageUrl = "http://www.wotingbook.cn";

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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Tail.xaml", UriKind.Relative));
        }
        
    }
}