using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MicroMsg_Emotion_Center
{
    public partial class EmojiCenter : PhoneApplicationPage
    {
        public EmojiCenter()
        {
            InitializeComponent();
        }

        private void ListBoxItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (l1.IsSelected == true)
            {
                NavigationService.Navigate(new Uri("/EmojiPicker.xaml", UriKind.Relative));
            }
            else if (l2.IsSelected == true)
            {
                NavigationService.Navigate(new Uri("/EmojiPicker1.xaml", UriKind.Relative));
            }
            else if (l3.IsSelected == true)
            {
                NavigationService.Navigate(new Uri("/EmojiPicker2.xaml", UriKind.Relative));
            }
            else if (l4.IsSelected == true)
            {
                NavigationService.Navigate(new Uri("/EmojiPicker3.xaml", UriKind.Relative));
            }
            else if (l5.IsSelected == true)
            {
                NavigationService.Navigate(new Uri("/EmojiPicker4.xaml", UriKind.Relative));
            }
        }

    
    }
}