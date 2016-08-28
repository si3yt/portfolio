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
using System.Windows.Threading;

namespace wwwRG
{
    /// <summary>
    /// names.xaml の相互作用ロジック
    /// </summary>
    public partial class names : Page
    {
        static public string personal_name;

        int count = 0;

        string[] entry_name = new string[10];

        MediaPlayer playerA = new MediaPlayer();
        private DispatcherTimer intervalTimerA = new DispatcherTimer();

        int timer_number = 0;
        int time_limit = 6750;

        public names()
        {
            InitializeComponent();

            playerA.Open(new Uri("../../../start2.mid", UriKind.Relative));
            playerA.Play();

            intervalTimerA.Interval = TimeSpan.FromMilliseconds(1);　//0.001秒ごとにタイマー起動
            intervalTimerA.Tick += new EventHandler(UpdateEventK);       //呼び出す関数
            intervalTimerA.Start();                                     //タイマーの開始

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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/level.xaml", UriKind.Relative));

            playerA.Close();
            intervalTimerA.Stop();

            personal_name = textBox1.Text;
           
        }

        public void entry_personalName(string target) 
        {
            if(count < 10){
                entry_name[count] = target;
                print_entryName();
                count = count + 1;
            }
        }

        public void print_entryName() 
        {
            textBox1.Text += entry_name[count]; 
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("あ");
         
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("い");
         
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("う");
         
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("え");
         
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("お");
         
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("か");
         
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("き");
         
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("く");
         
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("け");
         
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("こ");
         
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("さ");
         
        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("し");
         
        }

        private void button16_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("す");
         
        }

        private void button18_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("せ");
         
        }

        private void button20_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("そ");
         
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("た");
         
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ち");
         
        }

        private void button17_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("つ");
         
        }

        private void button19_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("て");
         
        }

        private void button21_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("と");
         
        }

        private void button22_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("な");
         
        }

        private void button24_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("に");
         
        }

        private void button26_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぬ");
         
        }

        private void button28_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ね");
         
        }

        private void button30_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("の");
         
        }

        private void button23_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("は");
         
        }

        private void button25_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ひ");
         
        }

        private void button27_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ふ");
         
        }

        private void button29_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("へ");
         
        }

        private void button31_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ほ");
         
        }

        private void button32_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ま");
         
        }

        private void button34_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("み");
         
        }

        private void button36_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("む");
         
        }

        private void button38_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("め");
         
        }

        private void button40_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("も");
         
        }

        private void button33_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("や");
         
        }

        private void button37_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ゆ");
         
        }

        private void button41_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("よ");
         
        }

        private void button42_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ら");
         
        }

        private void button44_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("り");
         
        }

        private void button46_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("る");
         
        }

        private void button48_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("れ");
         
        }

        private void button50_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ろ");
         
        }

        private void button43_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("わ");
         
        }

        private void button45_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("を");
         
        }

        private void button47_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ん");
         
        }

        private void button35_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("が");
         
        }

        private void button49_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぎ");
         
        }

        private void button52_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぐ");
         
        }

        private void button54_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("げ");
         
        }

        private void button56_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ご");
         
        }

        private void button39_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ざ");
         
        }

        private void button51_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("じ");
         
        }

        private void button53_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ず");
         
        }

        private void button55_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぜ");
         
        }

        private void button57_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぞ");
         
        }

        private void button58_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("だ");
         
        }

        private void button60_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぢ");
         
        }

        private void button62_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("づ");
         
        }

        private void button64_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("で");
         
        }

        private void button66_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ど");
         
        }

        private void button59_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ば");
         
        }

        private void button61_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("び");
         
        }

        private void button63_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぶ");
         
        }

        private void button65_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("べ");
         
        }

        private void button67_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぼ");
         
        }

        private void button68_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぱ");
         
        }

        private void button70_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぴ");
         
        }

        private void button72_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぷ");
         
        }

        private void button74_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぺ");
         
        }

        private void button76_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぽ");
         
        }

        private void button69_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぁ");
         
        }

        private void button71_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぃ");
         
        }

        private void button73_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぅ");
         
        }

        private void button75_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぇ");
         
        }

        private void button77_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ぉ");
         
        }

        private void button78_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ゃ");
         
        }

        private void button79_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ゅ");
         
        }

        private void button80_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ょ");
         
        }

        private void button81_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("っ");
         
        }

        private void button82_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = String.Format("");
            count = 0;
        }

        private void button83_Click(object sender, RoutedEventArgs e)
        {
            entry_personalName("ー");
         
        }


    }
}
