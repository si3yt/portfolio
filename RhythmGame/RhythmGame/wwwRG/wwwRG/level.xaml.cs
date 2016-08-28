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
using System.Windows.Threading; //タイマーの追加


namespace wwwRG
{
    /// <summary>
    /// level.xaml の相互作用ロジック
    /// </summary>
    public partial class level : Page
    {
        static public int LE = 0;        //(疑似)外部変数の定義

        int timerA = 0;
        int image_point = 1;

        int topA = 0;

        //イメージ配列の作成
        Image[] ImageFrontA = new Image[1];
        
        //タイマーの定義//
        private DispatcherTimer intervalTimer = new DispatcherTimer();

        BitmapImage imageA = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん1-正面.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageB = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん1-横.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageC = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん1-横2.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageD = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん1-背面.png", UriKind.Relative));  //イメージのソース

        MediaPlayer playerA = new MediaPlayer();
        private DispatcherTimer intervalTimerA = new DispatcherTimer();

        int timer_number = 0;
        int time_limit = 6750;

        public level()
        {
            InitializeComponent();

            //妖精さん関連画像の作成
            ImageFrontA[0] = new Image();
            ImageFrontA[0].Source = imageA;
            ImageFrontA[0].Width = 227;
            ImageFrontA[0].Height = 160;
            Canvas.SetTop(ImageFrontA[0], topA);
            Canvas.SetLeft(ImageFrontA[0], 0);
            canvas1.Children.Add(ImageFrontA[0]);

            intervalTimer.Interval = TimeSpan.FromMilliseconds(1);　//0.011秒ごとにタイマー起動
            intervalTimer.Tick += new EventHandler(UpdateEvent);       //呼び出す関数
            intervalTimer.Start();                                     //タイマーの開始

            playerA.Open(new Uri("../../../start2.mid", UriKind.Relative));
            playerA.Play();
            intervalTimerA.Interval = TimeSpan.FromMilliseconds(1);　//0.001秒ごとにタイマー起動
            intervalTimerA.Tick += new EventHandler(UpdateEventK);       //呼び出す関数
            intervalTimerA.Start();  
        }

        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //ボタン2(ふつう)が押されたとき//
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/songs.xaml", UriKind.Relative));

            playerA.Close();
            intervalTimerA.Stop();


            MediaPlayer player = new MediaPlayer();

            LE = 2;
        }

        //ボタン3(むずかしい)が押されたとき//
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/songs.xaml", UriKind.Relative));

            playerA.Close();
            intervalTimerA.Stop();


            MediaPlayer player = new MediaPlayer();

            LE = 3;
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/songs.xaml", UriKind.Relative));

            playerA.Close();
            intervalTimerA.Stop();


            MediaPlayer player = new MediaPlayer();

            LE = 1;
        }
        //ハイパーリンク//
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {

        }


        public void creat_Image(int time)
        {
            switch (time)
            {
                case 10:
                    ImageFrontA[0].Source = imageB;
                    break;
                case 20:
                    ImageFrontA[0].Source = imageC;
                    break;
                case 30:
                    ImageFrontA[0].Source = imageD;
                    break;
                case 40:
                    ImageFrontA[0].Source = imageA;
                    timerA = 0;
                    break;
            }
        }

        public void point_Image1()
        {
            topA = -10;
            Canvas.SetTop(ImageFrontA[0], topA);
            Canvas.SetLeft(ImageFrontA[0], 0);
        
        }

        public void point_Image2()
        {
            topA = 130;
            Canvas.SetTop(ImageFrontA[0], topA);
            Canvas.SetLeft(ImageFrontA[0], 0);
        
        }

        public void point_Image3()
        {
            topA = 280;
            Canvas.SetTop(ImageFrontA[0], topA);
            Canvas.SetLeft(ImageFrontA[0], 0);
        
        }

        //タイマー(0.011秒ごと)に行われる動作//
        void UpdateEvent(object sender, EventArgs e)
        {
            timerA += 1;
            creat_Image(timerA);
            switch (image_point)
            {
                case 1:
                    point_Image1();
                    break;
                case 2:
                    point_Image2();
                    break;
                case 3:
                    point_Image3();
                    break;
            }

        }

        private void button4_MouseEnter(object sender, MouseEventArgs e)
        {
            image_point = 1;
        }

        private void button2_MouseEnter(object sender, MouseEventArgs e)
        {
            image_point = 2;
        }

        private void button3_MouseEnter(object sender, MouseEventArgs e)
        {
            image_point = 3;
        }

        private void UpdateEventK(object sender, EventArgs e)
        {
            timer_number += 1;

            if (timer_number == time_limit)
            {
                playerA.Close();
                playerA.Open(new Uri("../../../start2.mid", UriKind.Relative));
                playerA.Play();
                time_limit += 6750;
            }


        }
    }
}
