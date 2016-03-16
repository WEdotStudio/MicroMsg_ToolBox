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

namespace MicroMsg_ToolBox
{
    public partial class EntryPage :WXEntryBasePage
    {
        internal static GetMessageFromWX.Req lastRequest;

        public EntryPage()
        {
            InitializeComponent();
        }

        /*
         * 微信拉起App来获得数据的入口
         */
        public override void On_GetMessageFromWX_Request(GetMessageFromWX.Req request)
        {
            if (request != null)
            {
                lastRequest = request;
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        /*
        * 发送消息后，微信返回成功或失败的相应，不关注结果goback处理
        */
        public override void On_SendMessageToWX_Response(SendMessageToWX.Resp response)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            else
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                NavigationService.RemoveBackEntry();
            }
        }

        /*
         *未实现
        * 暂时不支持
         * 
        */
        public override void On_SendAuth_Response(SendAuth.Resp response)
        {
            //if (response != null && response.ErrCode == ErrorCode.ERR_USER_CANCEL)
            //{
            //    MessageBox.Show("授权取消");
            //}
            //else if (response != null && response.Code != null)
            //{
            //    MessageBox.Show("授权成功,code = " + response.Code + "\n state = " + response.State + "\n url = " + response.Url);
            //}
            //else
            //{
            //    MessageBox.Show("授权失败");
            //}

            //if (NavigationService.CanGoBack)
            //{
            //    NavigationService.GoBack();
            //}
            //else
            //{
            //    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            //    NavigationService.RemoveBackEntry();
            //}
        }

        /*
         * 可暂忽略的函数
        * 微信请求应用显示特定的消息数据（数据在request.Message中）
        */
        public override void On_ShowMessageFromWX_Request(ShowMessageFromWX.Req request)
        {
        }
    }
}