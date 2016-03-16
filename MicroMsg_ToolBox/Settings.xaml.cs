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

namespace MicroMsg_ToolBox
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (IsolatedStorageSettings.ApplicationSettings.Contains("ChoosedByUser"))
            {
                this.ChoosedByUser.IsChecked = true;
            }
            else
            {
                this.ChoosedByUser.IsChecked = false;
            }
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("ChoosedByUser"))
            {
                settings.Add("ChoosedByUser", "1");
            }
            else
            {
                settings["ChoosedByUser"] = "1";
            }
            settings.Save();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains("ChoosedByUser"))
            {
                IsolatedStorageSettings.ApplicationSettings.Remove("ChoosedByUser");
            }

        }
    }
}