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
    /// Page1.xaml の相互作用ロジック
    /// </summary>
    public partial class Page1 : Page
    {
        private MediaPlayer playerA = new MediaPlayer();
        private DispatcherTimer intervalTimer = new DispatcherTimer();
        
        int timer_number = 0;
        int time_limit = 3770;

        public Page1()
        {
            InitializeComponent();

            
            playerA.Open(new Uri("../../../asobikata.mid", UriKind.Relative));
            playerA.Play();

            intervalTimer.Interval = TimeSpan.FromMilliseconds(1);　//0.001秒ごとにタイマー起動
            intervalTimer.Tick += new EventHandler(UpdateEvent);       //呼び出す関数
            intervalTimer.Start();                                     //タイマーの開始
           
        }

        private void UpdateEvent(object sender, EventArgs e)
        {
            timer_number += 1;

                if (timer_number == time_limit)
                {
                    playerA.Close();
                    playerA.Open(new Uri("../../../asobikata.mid", UriKind.Relative));
                    playerA.Play();
                    time_limit += 3770;
                }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/asobikata2.xaml", UriKind.Relative));
            playerA.Close();
            intervalTimer.Stop();
        }
    }
}
