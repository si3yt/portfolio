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
    /// start.xaml の相互作用ロジック
    /// </summary>
    public partial class start : Page
    {
        int timerA = 0;
        int timerB = 0;

        //イメージ配列の作成
        Image[] ImageFrontA = new Image[1];
        Image[] ImageFrontB = new Image[1];
        Image[] ImageFrontC = new Image[1];
        Image[] ImageFrontD = new Image[1];
        
        //タイマーの定義//
        private DispatcherTimer intervalTimer = new DispatcherTimer();

        BitmapImage imageFA = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん2-正面2.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageFB = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん2-正面.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageSA = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん2-側面.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageSB = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん2-側面2.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageMA = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん-文字.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageMB = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん-文字2.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageMC = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん-文字3.png", UriKind.Relative));  //イメージのソース
        
        private MediaPlayer playerA = new MediaPlayer();
        private DispatcherTimer intervalTimerA = new DispatcherTimer();

        int timer_number = 0;
        int time_limit = 3780;

        public start()
        {
            

            InitializeComponent();

            //妖精さん関連画像の作成
            //妖精さん1
            ImageFrontA[0] = new Image();
            ImageFrontA[0].Source = imageFA;
            ImageFrontA[0].Width = 227;
            ImageFrontA[0].Height = 160;
            Canvas.SetTop(ImageFrontA[0], 50);
            Canvas.SetLeft(ImageFrontA[0], 5);
            canvas1.Children.Add(ImageFrontA[0]);

            //妖精さん2
            ImageFrontB[0] = new Image();
            ImageFrontB[0].Source = imageFB;
            ImageFrontB[0].Width = 227;
            ImageFrontB[0].Height = 160;
            Canvas.SetTop(ImageFrontB[0], 50);
            Canvas.SetLeft(ImageFrontB[0], 105);
            canvas2.Children.Add(ImageFrontB[0]);

            //文字1
            ImageFrontC[0] = new Image();
            ImageFrontC[0].Source = imageMC;
            ImageFrontC[0].Width = 227;
            ImageFrontC[0].Height = 160;
            Canvas.SetTop(ImageFrontC[0], 5);
            Canvas.SetLeft(ImageFrontC[0], 105);
            canvas1.Children.Add(ImageFrontC[0]);

            //文字2
            ImageFrontD[0] = new Image();
            ImageFrontD[0].Source = imageMC;
            ImageFrontD[0].Width = 227;
            ImageFrontD[0].Height = 160;
            Canvas.SetTop(ImageFrontD[0], 5);
            Canvas.SetLeft(ImageFrontD[0], 5);
            canvas2.Children.Add(ImageFrontD[0]);

            playerA.Open(new Uri("../../../strat.mid", UriKind.Relative));
            playerA.Play();

            intervalTimer.Interval = TimeSpan.FromMilliseconds(1);　//0.011秒ごとにタイマー起動
            intervalTimer.Tick += new EventHandler(UpdateEvent);       //呼び出す関数
            intervalTimer.Start();                                     //タイマーの開始



            intervalTimerA.Interval = TimeSpan.FromMilliseconds(1);　//0.001秒ごとにタイマー起動
            intervalTimerA.Tick += new EventHandler(UpdateEventK);       //呼び出す関数
            intervalTimerA.Start(); 
        }

        //ボタン2を押した時//
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/names.xaml", UriKind.Relative));
            playerA.Close();
            intervalTimerA.Stop();
        }

        //ボタン3を押した時//
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/asobikata1.xaml", UriKind.Relative));
            playerA.Close();
            intervalTimerA.Stop();
        }

        public void creat_ImageA(int time)
        {
            switch (time)
            {
                case 50:
                    ImageFrontA[0].Source = imageSA;
                    ImageFrontC[0].Source = imageMA;
                    break;
                case 100:
                    ImageFrontA[0].Source = imageFA;
                    ImageFrontC[0].Source = imageMC;
                    timerA = 0;
                    break;
            }
        }

        public void creat_ImageB(int time)
        {
            switch (time)
            {
                case 50:
                    ImageFrontB[0].Source = imageSB;
                    ImageFrontD[0].Source = imageMB;
                    break;
                case 100:
                    ImageFrontB[0].Source = imageFB;
                    ImageFrontD[0].Source = imageMC;
                    timerB = 0;
                    break;
            }
        }

        //タイマー(0.011秒ごと)に行われる動作//
        void UpdateEvent(object sender, EventArgs e)
        {
            timerA += 1;
            timerB += 1;
            creat_ImageA(timerA);
            creat_ImageB(timerB);
        }

        private void UpdateEventK(object sender, EventArgs e)
        {
            timer_number += 1;



            if (timer_number == time_limit)
            {
                playerA.Close();
                playerA.Open(new Uri("../../../strat.mid", UriKind.Relative));
                playerA.Play();
                time_limit += 3780;
            }
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ranking.xaml", UriKind.Relative));
            playerA.Close();
        }
    }
}
