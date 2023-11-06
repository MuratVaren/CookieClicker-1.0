using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CookieClicker_1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer upgradesKlok = new DispatcherTimer();
        private MediaPlayer tapSoundPlayer = new MediaPlayer();


        decimal counter = 0;
        int pointer = 0;
        int granny = 0;
        public MainWindow()
        {
            InitializeComponent();
            //Event koppelen
            upgradesKlok.Tick += new EventHandler(UpgradesKlokAfgelopen);
            //Elke seconde
            upgradesKlok.Interval = new TimeSpan(0, 0, 0, 0 , 10);
            //Timer starten
            upgradesKlok.Start();

        }
        
        private void UpgradesKlokAfgelopen(object sender, EventArgs e)
        {
            counter += pointer * 0.001m;
            counter += granny * 0.01m;
            this.Title = $"You have {counter.ToString("00")} COOKIES";
            LblGetalVuller();

        }
        public void RandomTapSound()
        {
            Random random = new Random();
            int number = random.Next(1, 3);
            tapSoundPlayer.Open(new Uri($"Assets/Audio/tap-{number}.wav", UriKind.RelativeOrAbsolute));

        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            counter += 1;
            LblGetalVuller();
            ImgCookie.Margin = new Thickness(40);
            RandomTapSound();
            tapSoundPlayer.Stop();
            tapSoundPlayer.Play();
        }
        private void ImgCookie_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ImgCookie.Margin = new Thickness(50);
        }

        public void LblGetalVuller()
        {
            LblGetal.Content = counter.ToString("0");
        }

        private void BtnBuy(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button != null)
            {
                string btnContent = button.Name.ToString().Replace("Btn","");
                switch (btnContent)
                {
                    case "Pointer":
                        if (counter >= 15)
                        {
                            counter -= 15;
                            pointer++;
                            LblPointer.Content = pointer.ToString();
                        }
                        break;
                    case "Granny":
                        if (counter >= 100)
                        {
                            counter -= 100;
                            granny++;
                            LblGranny.Content = granny.ToString();
                        }
                        break;
                }
                LblGetalVuller();
            }

        }


    }
}
