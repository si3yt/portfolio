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
    /// songs.xaml の相互作用ロジック
    /// </summary>
    public partial class songs : Page
    {
        int le = level.LE;   //変数の呼び出し(levelページから)
        static public int SO = 1;        //(疑似)外部変数の定義

        int timerA = 0;
        int image_point = 0;

        static public string songs_name;

        //イメージ配列の作成
        Image[] ImageFrontA = new Image[1];
        Image[] ImageFrontB = new Image[1];
        

        //タイマーの定義//
        private DispatcherTimer intervalTimer = new DispatcherTimer();

        BitmapImage imageA = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん3.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageB = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん-文字3.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageC = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん-文字.png", UriKind.Relative));  //イメージのソース

        MediaPlayer playerA = new MediaPlayer();
        private DispatcherTimer intervalTimerA = new DispatcherTimer();

        int timer_number = 0;
        int time_limit = 6750;

        public songs()
        {
            InitializeComponent();
            if (le == 1)
                label4.Content = String.Format("レベル：かんたん");     //level=1(かんたん)の時のレベル表示
            else
                if (le == 2)
                    label4.Content = String.Format("レベル：ふつう");       //level=2(ふつう)の時のレベル表示
                else
                    label4.Content = String.Format("レベル：むずかしい");   //level=3(むずかしい)の時のレベル表示
            
            //妖精さん関連画像の作成
            ImageFrontA[0] = new Image();
            ImageFrontA[0].Source = imageB;
            ImageFrontA[0].Width = 227;
            ImageFrontA[0].Height = 160;
            Canvas.SetTop(ImageFrontA[0], 0);
            Canvas.SetLeft(ImageFrontA[0], 0);
            canvas1.Children.Add(ImageFrontA[0]);

            //文字
            ImageFrontB[0] = new Image();
            ImageFrontB[0].Source = imageB;
            ImageFrontB[0].Width = 227;
            ImageFrontB[0].Height = 160;
            Canvas.SetTop(ImageFrontB[0], 5);
            Canvas.SetLeft(ImageFrontB[0], 105);
            canvas1.Children.Add(ImageFrontB[0]);
            

            intervalTimer.Interval = TimeSpan.FromMilliseconds(1);　//0.011秒ごとにタイマー起動
            intervalTimer.Tick += new EventHandler(UpdateEvent);       //呼び出す関数
            intervalTimer.Start();                                     //タイマーの開始

            playerA.Open(new Uri("../../../start2.mid", UriKind.Relative));
            playerA.Play();

            intervalTimerA.Interval = TimeSpan.FromMilliseconds(1);　//0.001秒ごとにタイマー起動
            intervalTimerA.Tick += new EventHandler(UpdateEventK);       //呼び出す関数
            intervalTimerA.Start();
        }


        public void level_print(int level_selected)
        {
            if (le == 1)
            {
                label6.Content = String.Format("★☆☆☆☆");
            }
            else
            {
                if (le == 2)
                    label6.Content = String.Format("★★☆☆☆");
                else
                    label6.Content = String.Format("★★★☆☆");
            }
        }

        public void disply_SongName()
        {
            label3.Content = songs_name;      //曲名を表示
        }

        //リストボックスアイテムの0番が選択された時//
        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            songs_name = "アルプス一万尺";

            SO = 1;

            level_print(le);

            button1.IsEnabled = true;

            disply_SongName();
            label6.Content = String.Format("★★★★☆");
        }

        //リストボックスアイテムの1番が選択された時//
        private void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            songs_name = "キラキラ星";

            SO = 2;

            level_print(le);

            button1.IsEnabled = true;

            disply_SongName();
            label6.Content = String.Format("★★★☆☆");
        }

        //リストボックスアイテムの2番が選択された時//
        private void ListBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            songs_name = "シャボン玉";

            SO = 3;

            level_print(le);

            button1.IsEnabled = true;

            disply_SongName();
            label6.Content = String.Format("★☆☆☆☆");
        }
        //リストボックスアイテムの3番が選択された時//
        private void ListBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            songs_name = "はるがきた";

            SO = 4;

            level_print(le);

            button1.IsEnabled = true;

            disply_SongName();
            label6.Content = String.Format("★★☆☆☆");
        }
        //リストボックスアイテムの4番が選択された時//
        private void ListBoxItem_Selected_4(object sender, RoutedEventArgs e)
        {
            songs_name = "森のくまさん";

            SO = 5;

            level_print(le);

            button1.IsEnabled = true;

            disply_SongName();
            label6.Content = String.Format("★★★★★");
        }
        //リストボックスアイテムの5番が選択された時//
        private void ListBoxItem_Selected_5(object sender, RoutedEventArgs e)
        {
            songs_name = "ロンドンばし";

            SO = 6;

            level_print(le);

            button1.IsEnabled = true;

            disply_SongName();
            label6.Content = String.Format("★☆☆☆☆");
        }
        //リストボックスアイテムの6番が選択された時//
        private void ListBoxItem_Selected_6(object sender, RoutedEventArgs e)
        {
            songs_name = "ジングルベル";

            SO = 7;

            level_print(le);

            button1.IsEnabled = true;

            disply_SongName();
            label6.Content = String.Format("★★☆☆☆");
        }
        //リストボックスアイテムの7番が選択された時//
        private void ListBoxItem_Selected_7(object sender, RoutedEventArgs e)
        {
            songs_name = "大きなくりの木の下で";

            SO = 8;

            level_print(le);

            button1.IsEnabled = true;

            disply_SongName();
            label6.Content = String.Format("★★☆☆☆");
        }
        //リストボックスアイテムの8番が選択された時//
        private void ListBoxItem_Selected_8(object sender, RoutedEventArgs e)
        {
            songs_name = "虫のこえ";

            SO = 9;

            level_print(le);

            button1.IsEnabled = true;

            disply_SongName();
            label6.Content = String.Format("★★★☆☆");
        }

        //リストボックスアイテムの9番が選択された時//
        private void ListBoxItem_Selected_9(object sender, RoutedEventArgs e)
        {
            songs_name = "うさぎとかめ";

            SO = 10;

            level_print(le);

            button1.IsEnabled = true;

            disply_SongName();
            label6.Content = String.Format("★★★★☆");
        }

        //リストボックスアイテムの10番が選択された時//
        private void ListBoxItem_Selected_10(object sender, RoutedEventArgs e)
        {
            songs_name = "アルプス？";

            SO = 11;

            level_print(le);

            button1.IsEnabled = true;

            disply_SongName();
            label6.Content = String.Format("★★★★★★★★★★");
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

        //ハイパーリンク//
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {

        }
        
      

        //リストボックスが選択された時//
        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //ボタン1(スタート)が押されたとき//
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/player.xaml", UriKind.Relative));
           

            playerA.Close();
            intervalTimerA.Stop();

        }


        public void creat_Image()
        {
            switch (image_point)
            {
                case 0:
                    ImageFrontA[0].Source = imageB;
                    ImageFrontB[0].Source = imageB;
                    break;
                case 1:
                    ImageFrontA[0].Source = imageA;
                    ImageFrontB[0].Source = imageC;
                    break;
            }
        }

        //タイマー(0.011秒ごと)に行われる動作//
        void UpdateEvent(object sender, EventArgs e)
        {
            timerA += 1;
            creat_Image();
        }

        private void button1_MouseEnter(object sender, MouseEventArgs e)
        {
            image_point = 1;
        }

        private void button1_MouseLeave(object sender, MouseEventArgs e)
        {
            image_point = 0;
        }
        
    }
}
