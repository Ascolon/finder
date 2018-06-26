using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FindAny.Helpers;

namespace FindAny.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        ConfigMethods config;
        ViewManagment View;
        MainWindow win;
        public Login()
        {
            InitializeComponent();
            config = new ConfigMethods();
            View = new ViewManagment();
            win = Application.Current.Windows.OfType<MainWindow>().First();
            NamePlayer.Text = config.GetPlayerName().Length > 0 ? config.GetPlayerName() : String.Empty;
        }

        private void SetName(object sender, RoutedEventArgs e)
        {
            if (NamePlayer.Text.Length == 0)
                return;
            config.SetPlayerName(NamePlayer.Text);
            win.EnableTimer = (Boolean)EnableTimer.IsChecked;
            switch (config.GetLevel())
            {
                case "1":
                    View.RedirectUrl("FirstLevel.xaml");
                    break;
                case "2":
                    View.RedirectUrl("SecondLevel.xaml");
                    break;
                case "3":
                    View.RedirectUrl("ThirdLevel.xaml");
                    break;
                default: break;
            }
            var w = Application.Current.Windows.OfType<MainWindow>().First();
            w.Player.Text += config.GetPlayerName();        
        }

        private void SetLevelBtn(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;

            foreach (var item in LevelsBtn.Children)
            {
                (item as Button).Background = new SolidColorBrush(Colors.Transparent);
            }

            btn.Background = new SolidColorBrush(Color.FromRgb(221,221,221));
            config.SetLevel(btn.Content.ToString());
        }

        private void Rating(object sender, RoutedEventArgs e)
        {
            win.RatingPage.Visibility = Visibility.Visible;
            if (DataBase.GetData().Count == 0) 
            {
                win.Danger.Visibility = Visibility.Visible;
                return;
            }
            if (DataBase.GetData().Count > 0)
            {
                win.Danger.Visibility = Visibility.Hidden;
                win.PlayerRating.ItemsSource = DataBase.GetData();
                return;
            }
        }

    }
}
