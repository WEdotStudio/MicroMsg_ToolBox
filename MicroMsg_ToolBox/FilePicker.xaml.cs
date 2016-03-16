using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Storage.Pickers;
using Windows.Storage;
using MicroMsg.sdk;
using System.Windows.Resources;
using System.IO;
using Windows.Storage.Streams;

namespace MicroMsg_ToolBox
{
    public partial class FilePicker : PhoneApplicationPage
    {
        bool isfilepickstart = false;

        public FilePicker()
        {
            InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.NavigationMode == NavigationMode.Back && PickFiles.PickedFiles.Count > 0 && isfilepickstart)
            {
                isfilepickstart = false;
                StorageFile file = PickFiles.PickedFiles[0];
                string name = file.Name;
                IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                Stream stream = WindowsRuntimeStreamExtensions.AsStreamForRead(fileStream.GetInputStreamAt(0));
                MemoryStream ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                
                string AppID = AppConfig.wechatID;
                int scene = SendMessageToWX.Req.WXSceneSession;
                WXBaseMessage message = null;
                byte[] wxfile = ms.ToArray();
                byte[] thumb = readRes("Assets/fileinwc.png");
                WXFileMessage msg = new WXFileMessage();
                msg.Title = "微信工具箱,只属于WP";
                msg.Description = "分享文件：" + name;
                msg.ThumbData = thumb;


                msg.FileData = wxfile;
                msg.FileName = name;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            isfilepickstart = true;
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.FileTypeFilter.Add("*");
            openPicker.PickSingleFileAndContinue();
        }
    }
}