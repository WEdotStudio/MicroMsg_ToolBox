using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using MicroMsg.sdk;

namespace MicroMsg_ToolBox
{
    
    public partial class Tail : PhoneApplicationPage
    {
        public Tail()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.howto.IsOpen = false;
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("tname") && settings.Contains("tid"))
            {
                tname.Text = settings["tname"] as string;
                tid.Text = settings["tid"] as string;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (tname.Text == "")
            {
                MessageBox.Show("请输入尾巴名字");
            }
            else if (tid.Text == "")
            {
                MessageBox.Show("请输入尾巴AppID");
            }
            else if (tcontent.Text == "")
            {
                MessageBox.Show("请输入发送内容");
            }
            else
            {
                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                if (!settings.Contains("tname"))
                {
                    settings.Add("tname", tname.Text);
                }
                else
                {
                    settings["tname"] = tname.Text;
                }
                if (!settings.Contains("tid"))
                {
                    settings.Add("tid", tid.Text);
                }
                else
                {
                    settings["tid"] = tid.Text;
                }
                settings.Save();

                string AppID = tid.Text;
                int scene = SendMessageToWX.Req.WXSceneChooseByUser;
                WXBaseMessage message = null;
                WXTextMessage msg = new WXTextMessage();
                msg.Title = tname.Text;
                msg.ThumbData = null;
                msg.Text = tcontent.Text;
                message = msg;
                try
                {
                    SendMessageToWX.Req req = new SendMessageToWX.Req(message, scene);
                    IWXAPI api = WXAPIFactory.CreateWXAPI(AppID);
                    api.SendReq(req);
                }
                catch (WXException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.howto.IsOpen = true;
        }
    }
}