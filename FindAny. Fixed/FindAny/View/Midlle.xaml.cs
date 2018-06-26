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
    /// Interaction logic for Midlle.xaml
    /// </summary>
    public partial class Midlle : Page
    {
        ViewManagment View;
        ConfigMethods config;
        MainWindow win;
        public Midlle()
        {
            InitializeComponent();
            View = new ViewManagment();
            config = new ConfigMethods();
            win = Application.Current.Windows.OfType<MainWindow>().First();
            Score.Text = win.Score.ToString();
            if (config.GetLevel() == "3") 
            {
                NextLevelBtn.Visibility = Visibility.Collapsed;
            }
            DataBase.SetData(Score.Text);
        }

        private void NextLevel(object sender, RoutedEventArgs e)
        {
            switch (config.GetLevel())
            {
                case "1":
                    View.RedirectUrl("SecondLevel.xaml");
                    break;
                case "2":
                    View.RedirectUrl("ThirdLevel.xaml");
                    break;
                case "3": break;
                default: break;
            }
        }

        private void MainMenu(object sender, RoutedEventArgs e)
        {
            win.Score = 0;
            win.ScoreGame.Text = "Очки: ";
            win.Timer.Stop();
            win.Seconds = 300;
            win.TimerText.Text = win.Seconds.ToString();
            win.MainMenu.Visibility = Visibility.Collapsed;
            View.RedirectUrl("Login.xaml");
        }
    }
}
