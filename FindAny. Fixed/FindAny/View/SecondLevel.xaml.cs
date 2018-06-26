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
using System.Windows.Threading;

namespace FindAny.View
{
    public partial class SecondLevel : Page
    {
        int Finded = 0;
        ViewManagment View;
        MainWindow win;
        ConfigMethods config;
        DispatcherTimer Timer;

        int ToolTipIndex = 0;
        List<Label> labl = new List<Label>();
        public SecondLevel()
        {
            InitializeComponent();
            View = new ViewManagment();
            config = new ConfigMethods();
            Timer = new FindAny.Helpers.Timer().GameTimer(1500);
            config.SetLevel("2");
            Timer.Tick += new EventHandler(Timer_Tick);
            win = Application.Current.Windows.OfType<MainWindow>().First();
            win.MainMenu.Visibility = Visibility.Visible;
            if (win.EnableTimer)
            {
                win.Timer.Start();
                win.TimerText.Visibility = Visibility.Visible;
            }
            else
            {
                win.Timer.Stop();
                win.TimerText.Visibility = Visibility.Hidden;
            }
            DataBase.Restart();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            labl[ToolTipIndex].Opacity = 0;
            Timer.Stop();
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var el = (sender as Label);
            if (el.Opacity == 1)
                return;
            if (win.ToolTipSound)
            {
                win.spLabel.Play();
            }
            el.Opacity = 1;
            Finded++;
            FindedText.Text = Finded.ToString();
            Progress.Value = Finded;
            win.Score += 100;
            win.ScoreGame.Text = "Очки " + win.Score.ToString();
            if (Finded == 9)
            {
                win.Timer.Stop();
                View.RedirectUrl("Midlle.xaml");
            }
        }
        private void GetToolTip(object sender, RoutedEventArgs e)
        {
            if (Timer.IsEnabled)
                return;
            if (win.Score < 100)
                return;
            Answer dialog = new Answer();
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                labl = SecondLevelGrid.Children.OfType<Label>().Where(l => l.Opacity == 0).ToList();
                if (labl.Count() == 0)
                    return;
                Random r = new Random();
                ToolTipIndex = r.Next(0, labl.Count());
                labl[ToolTipIndex].Opacity = 1;
                Timer.Start();
                win.Score -= 100;
                win.ScoreGame.Text = "Очки " + win.Score.ToString();
            }
            else
            {
                return;
            }
        }
    }
}
