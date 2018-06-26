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
using System.Media;
using System.IO;

namespace FindAny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConfigMethods config;
        string ClickWav = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\View\Data\Audio\Click.wav";
        public bool MusicPlay = true;
        MediaPlayer sp = new MediaPlayer();
        public SoundPlayer spLabel = new SoundPlayer();
        ViewManagment View;
        public DispatcherTimer Timer;
        public int Seconds = 300;
        public int Score = 0;
        public bool ToolTipSound = true;
        public bool EnableTimer { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Audio();
            spLabel.SoundLocation = ClickWav;
            spLabel.Load();
            config = new ConfigMethods();
            View = new ViewManagment();
            Timer = new Timer().GameTimer(1000);
            Timer.Tick +=new EventHandler(TimerTick);
            TimerText.Text = Seconds.ToString();
            sp.MediaEnded += new EventHandler(sp_MediaEnded);
            Application.Current.Exit += new ExitEventHandler(Current_Exit);
        }

        void Current_Exit(object sender, ExitEventArgs e)
        {
            // File.Delete("MDF/" + new ConfigMethods().GetPlayerName() + ".txt");
        }

        void TimerTick(object sender, EventArgs e)
        {
            Seconds--;
            TimerText.Text = Seconds.ToString();
            if (Seconds == 0)
            {
                Score = 0;
                ScoreGame.Text = "Очки: ";
                Timer.Stop();
                Seconds = 300;
                TimerText.Text = Seconds.ToString();
                MainMenu.Visibility = Visibility.Collapsed;
                View.RedirectUrl("Login.xaml");
            }
        }

        private void ChangeLevel(object sender, RoutedEventArgs e)
        {
            Timer.Stop();
            Levels.Visibility = Visibility.Visible;
            foreach (var item in Levels.Children)
            {
                (item as Button).IsEnabled = true;
                (item as Button).Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                if((item as Button).Content.ToString() == config.GetLevel())
                {
                    (item as Button).IsEnabled = false;
                    (item as Button).Background = new SolidColorBrush(Colors.Tomato);
                }
                
            }
        }

        private void CloseChangeLevel(object sender, RoutedEventArgs e)
        {
            Levels.Visibility = Visibility.Collapsed;
            Timer.Start();
        }

        private void NextLevel(object sender, RoutedEventArgs e)
        {
            var t = (sender as Button).Content.ToString();
            switch (t)
            {
                case "1":
                    Score = 0;
                    ScoreGame.Text = "Очки: ";
                    Seconds = 300;
                    TimerText.Text = Seconds.ToString();
                    View.RedirectUrl("FirstLevel.xaml");
                    break;
                case "2":
                    Score = 0;
                    ScoreGame.Text = "Очки: ";
                    Seconds = 300;
                    TimerText.Text = Seconds.ToString();
                    View.RedirectUrl("SecondLevel.xaml");
                    break;
                case "3":
                    Score = 0;
                    ScoreGame.Text = "Очки: ";
                    Timer.Stop();
                    Seconds = 300;
                    TimerText.Text = Seconds.ToString();
                    View.RedirectUrl("ThirdLevel.xaml");
                    break;
                default:
                    break;
            }
            config.SetLevel(t);
            Levels.Visibility = Visibility.Collapsed;
        }

        private void MainMenuRedirect(object sender, RoutedEventArgs e)
        {
            Score = 0;
            ScoreGame.Text = "Очки: ";
            Timer.Stop();
            Seconds = 300;
            TimerText.Text = Seconds.ToString();
            MainMenu.Visibility = Visibility.Collapsed;
            View.RedirectUrl("Login.xaml");
        }

        void Audio()
        {

            sp.Open(new Uri(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\View\Data\Audio\levelMusic.mp3"));
            sp.Play();
        }

        void sp_MediaEnded(object sender, EventArgs e)
        {
            sp.Open(new Uri(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\View\Data\Audio\levelMusic.mp3"));
            sp.Play(); throw new NotImplementedException();
        }

        private void PauseSound(object sender, RoutedEventArgs e)
        {
            if (MusicPlay)
            {
                sp.Pause();
                (sender as Button).Background = new SolidColorBrush(Colors.Tomato);
                MusicPlay = !MusicPlay;
            }
            else 
            {
                sp.Play();
                (sender as Button).Background = new SolidColorBrush(Colors.ForestGreen);
                MusicPlay = !MusicPlay;
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ToolTipSoundOff(object sender, RoutedEventArgs e)
        {
            if (ToolTipSound)
            {
                (sender as Button).Background = new SolidColorBrush(Colors.Tomato);
                ToolTipSound = !ToolTipSound;
            }
            else
            {
                (sender as Button).Background = new SolidColorBrush(Colors.ForestGreen);
                ToolTipSound = !ToolTipSound;
            }
        }

        private void CloseRating(object sender, RoutedEventArgs e)
        {
            RatingPage.Visibility = Visibility.Collapsed;
        }
    }
}
