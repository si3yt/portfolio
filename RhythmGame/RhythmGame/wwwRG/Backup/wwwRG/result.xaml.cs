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
    /// result.xaml の相互作用ロジック
    /// </summary>
    public partial class result : Page
    {
        double PO = player.points;     //変数の呼び出し(得点・playページから)
        double GR = player.great;      //変数の呼び出し(greatの回数・playページから)
        double GO = player.good;       //変数の呼び出し(goodの回数・playページから)
        double BA = player.bad;        //変数の呼び出し(badの回数・playページから)
        int MAX = player.conbo_max; //変数の呼び出し(conbo_maxの回数・playページから)

        int persent = 0;

        int timer = 0;

        int point_increas = 0;

        int pointTimer = 0;

        static public double score = 0;
        static public string personal_title = "";

        //タイマーの定義//
        private DispatcherTimer intervalTimer = new DispatcherTimer();
        private DispatcherTimer intervalTimerA = new DispatcherTimer();

        MediaPlayer playerA = new MediaPlayer();
        MediaPlayer playerN = new MediaPlayer();

        //イメージ配列
        Image[] ImageCracR = new Image[1];
        Image[] ImageCracL = new Image[1];

        BitmapImage imageR = new BitmapImage(new Uri(@"/wwwRG;component/クラッカー右.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageL = new BitmapImage(new Uri(@"/wwwRG;component/クラッカー左.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageBB = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん-文字3.png", UriKind.Relative));  //イメージのソース

        MediaPlayer playerB = new MediaPlayer();


        public result()
        {
            InitializeComponent();

            intervalTimer.Interval = TimeSpan.FromMilliseconds(1);　//0.001秒ごとにタイマー起動
            intervalTimer.Tick += new EventHandler(UpdateEvent);       //呼び出す関数
            intervalTimer.Start();                                     //タイマーの開始

            intervalTimerA.Interval = TimeSpan.FromMilliseconds(0.01);
            intervalTimerA.Tick += new EventHandler(print_score);


            ImageCracR[0] = new Image();
            ImageCracR[0].Source = imageBB;
            ImageCracR[0].Width = 300;
            ImageCracR[0].Height = 300;
            Canvas.SetTop(ImageCracR[0], 100);
            Canvas.SetLeft(ImageCracR[0], 600);
            canvas1.Children.Add(ImageCracR[0]);

            ImageCracL[0] = new Image();
            ImageCracL[0].Source = imageBB;
            ImageCracL[0].Width = 300;
            ImageCracL[0].Height = 300;
            Canvas.SetTop(ImageCracL[0], 100);
            Canvas.SetLeft(ImageCracL[0], 100);
            canvas1.Children.Add(ImageCracL[0]);

            

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ranking.xaml", UriKind.Relative));
            player.great = 0;
            player.good = 0;
            player.bad = 0;
            songs.SO = 1;
            score = PO;
            player.conbo_max = 0;
            playerB.Close();
            intervalTimerA.Stop();
            personal_title = String.Format("{0}", label5.Content);
        }

        void UpdateEvent(object sender, EventArgs e)
        {
            timer = timer + 1;
            switch (timer)
            {
                case 100:
                    label7.Content = String.Format("Great!:");
                    break;
                case 150:
                    label8.Content = String.Format("{0}", GR);       //greatの回数を表示
                    break;
                case 200:
                    label9.Content = String.Format("Good!:");
                    break;
                case 250:
                    label10.Content = String.Format("{0}", GO);      //goodの回数を表示
                    break;
                case 300:
                    label11.Content = String.Format("Bad...:");
                    break;
                case 350:
                    label12.Content = String.Format("{0}", BA);      //badの回数を表示
                    break;
                case 400:
                    label13.Content = String.Format("MAX:");
                    break;
                case 450:
                    label14.Content = String.Format("{0}", MAX);      //maxの回数を表示
                    break;
                case 500:
                    label15.Content = String.Format("達成:");
                    break;
                case 550:
                    persent = Convert.ToInt16(((GR + GO) / (GR + GO + BA)) * 100);
                    label16.Content = String.Format("{0}%", persent);      //persentを表示
                    break;
                case 600:
                    label4.Content = String.Format(":称号");
                    break;
                case 650:
                    label5.Content = String.Format("初心者");
                    break;
                case 700:
                    label2.Content = String.Format("―得点―");
                    break;
                case 750:
                    intervalTimerA.Start();
                    break;
            }
        }

        void print_score(object sender, EventArgs e)
        {
            pointTimer += 1;
            if (pointTimer == 8000)
            {
                int int2Point = Convert.ToInt32(PO);
                point_increas = int2Point - 1;
                playerB.Open(new Uri("../../../kekka.mid", UriKind.Relative));
                playerB.Play();
            }
            if (point_increas < PO)
            {
                point_increas = point_increas + 1;
                label3.Content = String.Format("{0}", point_increas);
                if (point_increas>=400){
                    label5.Content = String.Format("駆け出し");     //400
                    }
                if (point_increas >= 1600){
                    label5.Content = String.Format("お手伝いさん");     //1600
                    }
                if (point_increas >= 3200){
                    label5.Content = String.Format("新人");     //3200
                    }
                if (point_increas >= 6400){
                    label5.Content = String.Format("期待の新人");     //6400
                    }
                if (point_increas >= 12800){
                    label5.Content = String.Format("経験者");     //12800
                    }
                if (point_increas >= 25600){
                    label5.Content = String.Format("熟練者");     //25600
                    }
                if (point_increas>= 51200){
                    label5.Content = String.Format("エース");     //51200
                    }
                if (point_increas>= 102400){
                    label5.Content = String.Format("名人");     //102400
                    }
                if (point_increas >= 204800){
                    label5.Content = String.Format("リズムマスター");     //204800
                    }
                if (point_increas >= 400000){
                    label5.Content = String.Format("邪王真眼&ダークフレイムマスター");     //400000
                    }

                
            }
                        if (point_increas == PO)
                        {
                                                   
                            ImageCracR[0].Source = imageR;
                            ImageCracL[0].Source = imageL;
                        }
        }
        
    }
}