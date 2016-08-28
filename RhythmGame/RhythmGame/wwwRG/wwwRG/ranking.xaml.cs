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
    /// ranking.xaml の相互作用ロジック
    /// </summary>
    public partial class ranking : Page
    {
        static public string[] personal_name = {"阿部","馬場","千倉", "土井","江頭", "不動", "後藤", "堀田","飯田", "城島", ""};
        static public double[] personal_point = {50000, 30000, 10000, 8000, 6000, 4000, 3000, 2000, 1000, 100, 0};
        static public string[] personal_title = { "熟練者", "熟練者", "経験者", "期待の新人", "新人", "新人", "お手伝いさん", "お手伝いさん", "駆け出し", "初心者", "" };

        string personal_name_temp = "";
        double personal_point_temp = 0;
        string personal_title_temp = "";

        private MediaPlayer playerA = new MediaPlayer();
        private DispatcherTimer intervalTimer = new DispatcherTimer();

        int timer_number = 0;
        int time_limit = 3770;

        public ranking()
        {
            InitializeComponent();

            playerA.Open(new Uri("../../../strat.mid", UriKind.Relative));
            playerA.Play();

            intervalTimer.Interval = TimeSpan.FromMilliseconds(1);　//0.011秒ごとにタイマー起動
            intervalTimer.Tick += new EventHandler(UpdateEvent);       //呼び出す関数
            intervalTimer.Start(); 

        }


        /*    
         * 機能：ランキングの見えない11番目に得点と名前と称号をいれる
         */
        public void entry_ranking()
        {
            personal_name[10] = names.personal_name;
            personal_point[10] = result.score;
            personal_title[10] = result.personal_title;
        }

        /*
         * 機能：ランキングの得点から降順に並び替えする
         *       名前も一緒に並び替え
         */
        public void sort_ranking()
        {
            for (int n = 0; n < 10; n++)
            {
                for (int m = n; m < 11; m++)
                {
                    if (personal_point[n] < personal_point[m])
                    {
                        personal_point_temp = personal_point[n];
                        personal_name_temp = personal_name[n];
                        personal_title_temp = personal_title[n];
                        personal_point[n] = personal_point[m];
                        personal_name[n] = personal_name[m];
                        personal_title[n] = personal_title[m];
                        personal_point[m] = personal_point_temp;
                        personal_name[m] = personal_name_temp;
                        personal_title[m] = personal_title_temp;
                    }
                }
            }
        }

        /*
         * 機能：ランキングに上から10位の人までのデータを表示させる
         */
        public void print_ranking()
        {
            for (int i = 0; i < 10; i++)
            {
                label2.Content += String.Format("\n{0}", personal_name[i]);
                label4.Content += String.Format("\n{0}", personal_point[i]);
                label5.Content += String.Format("\n{0}", personal_title[i]);
                label3.Content += String.Format("\n{0}", i + 1);
            }
        }

        private void UpdateEvent(object sender, EventArgs e)
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
            NavigationService.Navigate(new Uri("/start.xaml", UriKind.Relative));

            playerA.Close();

            intervalTimer.Stop();

            player.points = 0;
            result.score = 0;
            names.personal_name = "";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            entry_ranking();

            sort_ranking();

            print_ranking();

        }



    }
}
