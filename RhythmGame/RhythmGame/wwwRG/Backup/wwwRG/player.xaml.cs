
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
using System.Windows.Media.Animation; //アニメーションの追加
using System.Windows.Threading; //タイマーの追加


namespace wwwRG
{
    /// <summary>
    /// player.xaml の相互作用ロジック
    /// </summary>
    public partial class player : Page
    {
        static public double points = 0;        //(疑似)外部変数の定義
        static public int great = 0;        //(疑似)外部変数の定義
        static public int good = 0;        //(疑似)外部変数の定義
        static public int bad = 0;        //(疑似)外部変数の定義
        static public int conbo_max = 0;    //(疑似)外部変数の定義

        int le = level.LE;   //変数の呼び出し(levelページから)
        int so = songs.SO;   //変数の呼び出し(songsページから)
        string song_name = songs.songs_name;

        double Points = 0;     //得点の変数
        int Great = 0;
        int Good = 0;       //Goodの変数
        int Bad = 0;        //Badの変数

        int timers = 0;     //タイマーの変数

        double bypoint = 0;

        int conbo = 0;
        int comando = 0;
        int comandar = 0;

        int comtimers = 0;

        int[] right = new int[20];
        int rb = 0;
        int timerr = 0;

        int[] left = new int[20];
        int lb = 0;
        int timerl = 0;

        int[] up = new int[20];
        int ub = 0;
        int timeru = 0;

        int[] down = new int[20];
        int db = 0;
        int timerd = 0;

        int keyl = 0;
        int keyr = 0;
        int keyu = 0;
        int keyd = 0;

        int timerlink = 0;

        static public int begin = new int();


        //矢印の位置の関数
        double[] topsL = new double[20];
        double[] topsT = new double[20];
        double[] topsB = new double[20];
        double[] topsR = new double[20];

        int upgreat = 0;
        int upgood = 0;
        int upbad = 0;

        int leftgreat = 0;
        int leftgood = 0;
        int leftbad = 0;

        int downgreat = 0;
        int downgood = 0;
        int downbad = 0;

        int rightgreat = 0;
        int rightgood = 0;
        int rightbad = 0;

        int taskCounter = 0;

        int downl = 0;
        int downt = 0;
        int downb = 0;
        int downr = 0;

        int btimerl = 0;
        int btimert = 0;
        int btimerb = 0;
        int btimerr = 0;

        int ltimerl = 0;
        int ltimert = 0;
        int ltimerb = 0;
        int ltimerr = 0;

        //イメージ配列の作成
        Image[] array_ImageLeft = new Image[20];
        Image[] array_ImageTop = new Image[20];
        Image[] array_ImageBottom = new Image[20];
        Image[] array_ImageRight = new Image[20];

        //繰り返しの変数
        int l;

        /* 配列の数の設定
         * 
         * メモ：イメージの数は4つ全て同じで
         */
        int Image_index = 20;

        //配列の添え字
        int entry_ImageLeft = 0;
        int entry_ImageTop = 0;
        int entry_ImageBottom = 0;
        int entry_ImageRight = 0;


        //イメージ配列の作成
        Image[] ImageFrontA = new Image[1];
        Image[] ImageFrontB = new Image[1];
        Image[] ImageFrontC = new Image[1];
        Image[] ImageFrontD = new Image[1];

        Image[] ImageFrontA2 = new Image[1];
        Image[] ImageFrontB2 = new Image[1];
        Image[] ImageFrontC2 = new Image[1];
        Image[] ImageFrontD2 = new Image[1];

        Image[] ImageBack = new Image[1];

        Image[] ImageLightL = new Image[1];
        Image[] ImageLightT = new Image[1];
        Image[] ImageLightB = new Image[1];
        Image[] ImageLightR = new Image[1];

        
        //タイマーの定義//
        private DispatcherTimer intervalTimer = new DispatcherTimer();

        DoubleAnimation anime = new DoubleAnimation();  //アニメーションの関数
        DoubleAnimation anime_stop = new DoubleAnimation();

        BitmapImage imageL = new BitmapImage(new Uri(@"/wwwRG;component/左矢印X.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageT = new BitmapImage(new Uri(@"/wwwRG;component/上矢印X.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageB = new BitmapImage(new Uri(@"/wwwRG;component/下矢印X.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageR = new BitmapImage(new Uri(@"/wwwRG;component/右矢印X.png", UriKind.Relative));  //イメージのソース

        BitmapImage imageLY = new BitmapImage(new Uri(@"/wwwRG;component/左矢印Y.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageTY = new BitmapImage(new Uri(@"/wwwRG;component/上矢印Y.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageBY = new BitmapImage(new Uri(@"/wwwRG;component/下矢印Y.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageRY = new BitmapImage(new Uri(@"/wwwRG;component/右矢印Y.png", UriKind.Relative));  //イメージのソース

        BitmapImage imageLY2 = new BitmapImage(new Uri(@"/wwwRG;component/左矢印Y2.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageTY2 = new BitmapImage(new Uri(@"/wwwRG;component/上矢印Y2.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageBY2 = new BitmapImage(new Uri(@"/wwwRG;component/下矢印Y2.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageRY2 = new BitmapImage(new Uri(@"/wwwRG;component/右矢印Y2.png", UriKind.Relative));  //イメージのソース

        BitmapImage imageBA = new BitmapImage(new Uri(@"/wwwRG;component/black.png", UriKind.Relative));  //イメージのソース
        BitmapImage imageBB = new BitmapImage(new Uri(@"/wwwRG;component/妖精さん-文字3.png", UriKind.Relative));  //イメージのソース

        BitmapImage imageGB = new BitmapImage(new Uri(@"/wwwRG;component/宇宙5.jpg", UriKind.Relative));  //イメージのソース
        BitmapImage imageGA = new BitmapImage(new Uri(@"/wwwRG;component/宇宙4.jpg", UriKind.Relative));  //イメージのソース

        MediaPlayer playerA = new MediaPlayer();

        Random rand = new Random();

        int timing_index = 0;
        int endplayer_time = 0;
        int timing_entry = 0;

        int[] alps_timing = { 314, 378, 444, 505, 571, 632, 696, 760, 791, 842, 895, 927, 988, 1052, 1116, 1148, 1181, 1212, 1243, 1309, 1373, 1404, 1501, 1567, 1631, 1660, 1727, 1759, 1791, 1855, 1886, 1916, 1979, 2014, 2046, 2111, 2141, 2173, 2208, 2240, 2270, 2302, 2403, 2467, 2528, 2560, 2627, 2688, 2752, 2787, 2816, 2883, 2944, 3013, 3040, 3074, 3136, 3171, 3203, 3235, 3267, 3297, 3327, 4064 };

        int[] kirakira_timing = { 13,299,467,641,729,815,874,921,964,1049,1137,1220,1265,1307,1392,1478,1567,1653,1697,1783,1869,1955,2041,2126,2174,2259,2304,2343,2431,2522,2603,2647,2687,3175,3259,3301,3346,3431,3517,3559,3645,3689,3733,3866,3946,3993,4035,4123,4212,4295,4342,4384,4423,4516,4556,4597,4642,4728,4770,4900,4985,5032,5074,5116};

        int[] syabon_timing = {466,566,669,721,775,948,1053,1163,1215,1325,1376,1430,1538,1587,1642,1749,1803,1858,1911,2019,2070,2124,2232,2284,2336,2444,2502,2559,2609,2879 };

        int[] haru_timing = {288,352,415,538,578,610,671,801,847,889,986,1015,1079,1147,1273,1338,1399,1431,1464,1530,1594,1663,1693,1725,1788,1851,1915,2011,2041,2073,2105,2172,2304,2362,2428,2524,2554,2586,2616,2684,2813,2908,2938,3036,3068,3134,3197,3226,3261 };

        int[] mori_timing = {32,198,269,301,333,404,476,539,577,611,713,779,888,922,991,1094,1128,1195,1266,1335,1369,1404,1439,1508,1574,1608,1680,1782,1817,1920,1988,2020,2091,2123,2194,2263,2331,2366,2400,2435,2469,2503,2536,2606,2675,2710,2742,2808,2877,2912,3017,3084,3189,3223,3292,3361,3430,3467,3533,3585,3639,3702,3740,3772,3843,3878,3913,3979,4013,4046,4116,4186,4220,4288,4357,4394,4459,4527,4562,4597,4665,4734,4766,4801,4835,4870,4939,4973,5045,5113,5145,5180,5215,5286,5322,5420,5455,5489,5558,5629,5662,5728,5762,5796,5831,5899,5971,6003,6037,6072,6108 };

        int[] rondon_timing = { 110, 183, 262, 338, 375, 412, 493, 529, 607, 641, 680, 758, 798, 861, 928, 1007, 1042, 1081, 1158, 1198, 1276, 1313, 1352, 1430, 1504, 1585, 1619, 1701, 1738, 1814, 1853, 1892, 1971, 2008, 2047, 2164 };

        int[] jinguru_timing = { 110, 184, 265, 385, 463, 499, 580, 659, 737, 816, 901, 941, 1019, 1100, 1137, 1172, 1255,1331, 1410, 1447, 1488, 1572, 1687, 1726, 1763, 1842, 1881, 1962, 2074, 2155, 2195, 2273, 2354, 2429, 2471, 2547, 2589, 2626, 2666, 2705, 2784 };

        int[] okina_timing = { 331, 402, 471, 508, 546, 627, 697, 772, 860, 889, 966, 1001, 1073, 1110, 1188, 1293, 1330, 1367, 1407, 1517, 1591, 1628, 1665, 1699, 1812, 1849, 1886, 1960, 1997, 2104, 2181, 2223, 2257, 2294, 2402, 2442, 2476, 2552, 2589 };

        int[] musi_timing = { 439,539,586,638,692,741,837,871,920,1019,1119,1173,1222,1325,1371,1473,1523,1577,1629,1727,1779,1830,1931,2033,2085,2183,2284,2335,2387,2495,2542,2593,2693,2745,2799,2846,2897,3000,3051,3149,3201,3301,3351,3461,3557,3605,3655,3758,3807,3859,3962,4062,4165,4211,4265,4319,4367,4475,4570,4619,4666,4764};

        int[] usagi_timing = {248,317,389,419,484,554,587,689,724,756,851,876,979,1013,1048,1117,1149,1219,1288,1320,1354,1387,1490,1595,1664,1799,1868,1936,2070,2107,2142,2177,2209,2312,2381,2413,2450,2482,2558,2588,2688,2723,2862,2928,2993,3032,3138,3202,3266,3300,3371,3438,3543,3578,3678,3749,3916,3986,4123,4155,4259,4327,4396,4431,4534,4600,4633,4665,4808,4874,4906,4941,4976 };



        int[] kakusi_timing = { 96, 126, 190, 225, 257, 326, 356, 371, 388, 418, 450, 479, 495, 512, 543, 575, 593, 608, 638, 675, 690, 707, 719, 757, 772, 802, 832, 844, 859, 889, 922, 951, 966, 984, 1016, 1046, 1080, 1098, 1113, 1128, 1163, 1179, 1195, 1227, 1245, 1274, 1307, 1342, 1354, 1372, 1404, 1434, 1466, 1481, 1496, 1530, 1563, 1595, 1610, 1628, 1660, 1692, 1725, 1740, 1757, 1789, 1819, 1837, 1868, 1883, 1897, 1932, 1949, 1964, 1994, 2012, 2040, 2073, 2090, 2123, 2140, 2157, 2172, 2189, 2218, 2233, 2265, 2295, 2315, 2330, 2362, 2397, 2431, 2446, 2461, 2491, 2525, 2556, 2572, 2589, 2621, 2653, 2685, 2700, 2715, 2731, 2748, 2780, 2845, 2862, 2907, 2924, 2971, 2988, 3005, 3023, 3039, 3065, 3098, 3130, 3148, 3165, 3181, 3196, 3213, 3228, 3246, 3263, 3293 };

        string player_name = names.personal_name;

        public player()
        {
            InitializeComponent();
            switch (le)
            {
                case 1:
                    label14.Content = String.Format("かんたん");     //level=1(かんたん)の時のレベル表示
                    break;
                case 2:
                    label14.Content = String.Format("ふつう");      //level=2(ふつう)の時のレベル表示
                    break;
                case 3:
                    label14.Content = String.Format("むずかしい");   //level=3(むずかしい)の時のレベル表示
                    break;
            }
            
            switch (so)
            {
                case 1:
                    playerA.Open(new Uri("../../../アルプス一万弱.mid", UriKind.Relative));
                    endplayer_time = 3760;
                    break;
                case 2:
                    playerA.Open(new Uri("../../../キラキラ干し.mid", UriKind.Relative));
                    endplayer_time = 5800;
                    break;
                case 3:
                    playerA.Open(new Uri("../../../シャボン魂.mid", UriKind.Relative));
                    endplayer_time = 3300;
                    break;
                case 4:
                    playerA.Open(new Uri("../../../春が北.mid", UriKind.Relative));
                    endplayer_time = 3600;
                    break;
                case 5:
                    playerA.Open(new Uri("../../../森の熊惨.mid", UriKind.Relative));
                    endplayer_time = 6500;
                    break;
                case 6:
                    playerA.Open(new Uri("../../../ロンドン箸.mid", UriKind.Relative));
                    endplayer_time = 2580;
                    break;
                case 7:
                    playerA.Open(new Uri("../../../ジングル鈴.mid", UriKind.Relative));
                    endplayer_time = 3450;
                    break;
                case 8:
                    playerA.Open(new Uri("../../../大きな栗野木下で.mid", UriKind.Relative));
                    endplayer_time = 3230;
                    break;
                case 9:
                    playerA.Open(new Uri("../../../無視の声.mid", UriKind.Relative));
                    endplayer_time = 5150;
                    break;
                case 10:
                    playerA.Open(new Uri("../../../兎と瓶.mid", UriKind.Relative));
                    endplayer_time = 5380;
                    break;
                case 11:
                    playerA.Open(new Uri("../../../アルプス一万弱.mid", UriKind.Relative));
                    endplayer_time = 3760;
                    break;
            }

            label6.Content = song_name;   //曲の名前の表示

            intervalTimer.Interval = TimeSpan.FromMilliseconds(1);　//0.001秒ごとにタイマー起動
            intervalTimer.Tick += new EventHandler(UpdateEvent);       //呼び出す関数
            intervalTimer.Start();                                     //タイマーの開始



            anime.From = 0;                                 //アニメーションのはじまり
            anime.To = 680;                                 //アニメーションのおわり
            anime.Duration = new Duration(TimeSpan.FromSeconds(3)); //間隔
            anime_stop.To = -800; //アニメーションのストップ
            anime_stop.From = -800; //アニメーションのストップ

            /*
             * lmageの初期化
             */
            for (int m = 0; m < Image_index; m++)
            {
                left[m] = 1;
                up[m] = 1;
                down[m] = 1;
                right[m] = 1;
            }

            creat_ImageLeft();
            creat_ImageTop();
            creat_ImageBottom();
            creat_ImageRight();

            creat_character();

            player_name_label.Content = player_name;
        }

        public void creat_character() 
        {
            int topSize = 590;

            ImageFrontA[0] = new Image();
            ImageFrontA[0].Source = imageBB;
            ImageFrontA[0].Width = 100;
            ImageFrontA[0].Height = 100;
            Canvas.SetTop(ImageFrontA[0], topSize);
            Canvas.SetLeft(ImageFrontA[0], 410);
            canvas2.Children.Add(ImageFrontA[0]);

            ImageFrontB[0] = new Image();
            ImageFrontB[0].Source = imageBB;
            ImageFrontB[0].Width = 100;
            ImageFrontB[0].Height = 100;
            Canvas.SetTop(ImageFrontB[0], topSize);
            Canvas.SetLeft(ImageFrontB[0], 550);
            canvas2.Children.Add(ImageFrontB[0]);

            ImageFrontC[0] = new Image();
            ImageFrontC[0].Source = imageBB;
            ImageFrontC[0].Width = 100;
            ImageFrontC[0].Height = 100;
            Canvas.SetTop(ImageFrontC[0], topSize);
            Canvas.SetLeft(ImageFrontC[0], 690);
            canvas2.Children.Add(ImageFrontC[0]);

            ImageFrontD[0] = new Image();
            ImageFrontD[0].Source = imageBB;
            ImageFrontD[0].Width = 100;
            ImageFrontD[0].Height = 100;
            Canvas.SetTop(ImageFrontD[0], topSize);
            Canvas.SetLeft(ImageFrontD[0], 830);
            canvas2.Children.Add(ImageFrontD[0]);
            
            ImageFrontA2[0] = new Image();
            ImageFrontA2[0].Source = imageBB;
            ImageFrontA2[0].Width = 120;
            ImageFrontA2[0].Height = 120;
            Canvas.SetTop(ImageFrontA2[0], topSize - 10);
            Canvas.SetLeft(ImageFrontA2[0], 400);
            canvas2.Children.Add(ImageFrontA2[0]);

            ImageFrontB2[0] = new Image();
            ImageFrontB2[0].Source = imageBB;
            ImageFrontB2[0].Width = 120;
            ImageFrontB2[0].Height = 120;
            Canvas.SetTop(ImageFrontB2[0], topSize - 10);
            Canvas.SetLeft(ImageFrontB2[0], 540);
            canvas2.Children.Add(ImageFrontB2[0]);

            ImageFrontC2[0] = new Image();
            ImageFrontC2[0].Source = imageBB;
            ImageFrontC2[0].Width = 120;
            ImageFrontC2[0].Height = 120;
            Canvas.SetTop(ImageFrontC2[0], topSize - 10);
            Canvas.SetLeft(ImageFrontC2[0], 680);
            canvas2.Children.Add(ImageFrontC2[0]);

            ImageFrontD2[0] = new Image();
            ImageFrontD2[0].Source = imageBB;
            ImageFrontD2[0].Width = 120;
            ImageFrontD2[0].Height = 120;
            Canvas.SetTop(ImageFrontD2[0], topSize -10);
            Canvas.SetLeft(ImageFrontD2[0], 820);
            canvas2.Children.Add(ImageFrontD2[0]);

            ImageBack[0] = new Image();
            ImageBack[0].Source = imageGA;
            ImageBack[0].Width = 1000;
            ImageBack[0].Height = 770;
            Canvas.SetTop(ImageBack[0], 0);
            Canvas.SetLeft(ImageBack[0], 0);
            canvas3.Children.Add(ImageBack[0]);

            ImageLightL[0] = new Image();
            ImageLightL[0].Source = imageLY2;
            ImageLightL[0].Width = 80;
            ImageLightL[0].Height = 80;
            Canvas.SetTop(ImageLightL[0], 600);
            Canvas.SetLeft(ImageLightL[0], 420);
            canvas1.Children.Add(ImageLightL[0]);

            ImageLightT[0] = new Image();
            ImageLightT[0].Source = imageTY2;
            ImageLightT[0].Width = 80;
            ImageLightT[0].Height = 80;
            Canvas.SetTop(ImageLightT[0], 600);
            Canvas.SetLeft(ImageLightT[0], 560);
            canvas1.Children.Add(ImageLightT[0]);

            ImageLightB[0] = new Image();
            ImageLightB[0].Source = imageBY2;
            ImageLightB[0].Width = 80;
            ImageLightB[0].Height = 80;
            Canvas.SetTop(ImageLightB[0], 600);
            Canvas.SetLeft(ImageLightB[0], 700);
            canvas1.Children.Add(ImageLightB[0]);

            ImageLightR[0] = new Image();
            ImageLightR[0].Source = imageRY2;
            ImageLightR[0].Width = 80;
            ImageLightR[0].Height = 80;
            Canvas.SetTop(ImageLightR[0], 600);
            Canvas.SetLeft(ImageLightR[0], 840);
            canvas1.Children.Add(ImageLightR[0]);


        }

        /* 機能：左矢印を4つ作る
         */
        public void creat_ImageLeft()
        {
            for (int i = 0; i < Image_index; i++)
            {

                array_ImageLeft[i] = new Image();
                array_ImageLeft[i].Source = imageL;
                array_ImageLeft[i].Width = 80;
                array_ImageLeft[i].Height = 80;
                Canvas.SetTop(array_ImageLeft[i], -150);
                Canvas.SetLeft(array_ImageLeft[i], 420.0);
                canvas1.Children.Add(array_ImageLeft[i]);
            }
        }


        /* 機能：上矢印を4つ作る
         */
        public void creat_ImageTop()
        {
            for (int i = 0; i < Image_index; i++)
            {

                array_ImageTop[i] = new Image();
                array_ImageTop[i].Source = imageT;
                array_ImageTop[i].Width = 80;
                array_ImageTop[i].Height = 80;
                Canvas.SetTop(array_ImageTop[i], -150);
                Canvas.SetLeft(array_ImageTop[i], 560.0);
                canvas1.Children.Add(array_ImageTop[i]);
            }
        }


        /* 機能：下矢印を4つ作る
         */
        public void creat_ImageBottom()
        {
            for (int i = 0; i < Image_index; i++)
            {

                array_ImageBottom[i] = new Image();
                array_ImageBottom[i].Source = imageB;
                array_ImageBottom[i].Width = 80;
                array_ImageBottom[i].Height = 80;
                Canvas.SetTop(array_ImageBottom[i], -150);
                Canvas.SetLeft(array_ImageBottom[i], 700.0);
                canvas1.Children.Add(array_ImageBottom[i]);
            }
        }

        /* 機能：右矢印を4つ作る
         */
        public void creat_ImageRight()
        {
            for (int i = 0; i < Image_index; i++)
            {

                array_ImageRight[i] = new Image();
                array_ImageRight[i].Source = imageR;
                array_ImageRight[i].Width = 80;
                array_ImageRight[i].Height = 80;
                Canvas.SetTop(array_ImageRight[i], -150);
                Canvas.SetLeft(array_ImageRight[i], 840.0);
                canvas1.Children.Add(array_ImageRight[i]);
            }
        }


        //ハイパーリンク//
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {

        }

        //MAXコンボの記憶//
        public void conbo_Max()
        {
            if (conbo > conbo_max)
            {
                conbo_max = conbo;
            }
        }




        /*
         * 機能：判定
         * 引数：double y
         *       ゲーム画面(canvas1)　における矢印(Image)　の縦の位置(px量)
         * 戻り値：int
         *         矢印キーを押したときの矢印のタイミングの評価
         *         1  のとき　一番良い 
         *         2  のとき　良い
         *         0  のとき　判定なし
         *         -1 のとき　ダメ
         *         
         * メモ：y は580～620のときに一番良い
         *       y は530～580、620～670のときに良い
         *       y は530より小さいときは早すぎて判定しない
         *       y は670より大きい値は遅すぎてダメ      
         */
        public int judge_timing(double y)
        {
            int target = 0;

            if (y <= 670.0 && y >= 530.0)
            {
                target = 2;
                if (y >= 580.0 && y <= 620.0)
                {
                    target = 1;
                }
            }
            else
            {
                if (y > 670.0)
                {
                    target = -1;
                }
                else
                {
                    target = 0;
                }
            }
            return target;
        }



        /* 機能：Great のコンボ計算と表示
         * 影響：一番良いときの点数の加算と表示
         *       「Great」の回数の加算と表示
         */
        public void conbo_great()
        {
            conbo = conbo + 1;
            if (comando == 1)
            {
                comandar = 1;
            }
            comando = 1;
            bypoint = (conbo - 1) * 2.0;
            if (conbo == 1)
            {
                points = points + 10;
                Points = Points + 10;
            }
            else
            {
                points = points + (10 * bypoint);                //疑似外部変数のpointを増やす
                Points = Points + (10 * bypoint);                //得点を増やす

            }
            label1.Content = String.Format("{0}点", Points);  //得点を表示
            great = great + 1;                                //疑似外部変数のgreatを増やす
            Great = Great + 1;                                //greatの回数を増やす
            label8.Content = String.Format("{0}回", Great);   //greatの回数を表示
            label15.Content = String.Format("{0}!", conbo);
            if (conbo >= 30)
            {
                ImageBack[0].Source = imageGB;
                label18.Content = String.Format("フィーバー!!");
            }
            else 
            {
                ImageBack[0].Source = imageGA;
                label18.Content = String.Format("");
            }
        }



        /* 機能：Good のコンボ計算と点数表示
         * 影響：良いときの点数の加点と表示
         *       「Good」の回数の加算と表示
         */
        public void conbo_good()
        {
            conbo = conbo + 1;
            if (comando == 1)
            {
                comandar = 1;
            }
            comando = 1;
            bypoint = (conbo - 1) * 1.5;
            if (conbo == 1)
            {
                points = points + 10;
                Points = Points + 10;
            }
            else
            {
                points = points + (10 * bypoint);                //疑似外部変数のpointを増やす
                Points = Points + (10 * bypoint);                //得点を増やす

            }
            label1.Content = String.Format("{0}点", Points);  //得点を表示
            good = good + 1;                                //疑似外部変数のgoodを増やす
            Good = Good + 1;                                //goodの回数を増やす
            label10.Content = String.Format("{0}回", Good);   //goodの回数を表示
            label15.Content = String.Format("{0}!", conbo);
            if (conbo >= 30)
            {
                ImageBack[0].Source = imageGB;
                label18.Content = String.Format("フィーバー!!");
            }
            else
            {
                ImageBack[0].Source = imageGA;
                label18.Content = String.Format("");
            }
        }



        /* 機能：Bad のコンボ計算と点数表示
         * 影響：良いときの点数の加点と表示
         *       「Bad」の回数の加算と表示
         */
        public void conbo_bad()
        {
            bypoint = 0;
            bad = bad + 1;                                  //疑似外部変数のbadを増やす
            Bad = Bad + 1;                                  //badの回数を増やす
            label12.Content = String.Format("{0}回", Bad);    //Badの回数を表示
            label1.Content = String.Format("{0}点", Points);  //得点を表示
            conbo = 0;
            comando = 0;
            label15.Content = String.Format("");
            label15.FontSize = 100;
            comtimers = 0;
            ImageBack[0].Source = imageGA;
            label18.Content = String.Format("");
        }


        /* 矢印キーを押したときがおそかったときの処理
         * 使う関数：conbo_bad
         * 機能：badのコンボ計算と点数表示
         * 影響：「bad」を表示させる
         *       矢印の場所を元に戻す
         */
        public void case_JobBad()
        {
            for (l = 0; l < Image_index; l++)
            {
                if (left[l] == -1)
                {
                    conbo_bad();

                    lb = 1;
                    leftbad = 1;
                    timerl = 0;
                    array_ImageLeft[l].BeginAnimation(Canvas.TopProperty, anime_stop);
                }

                if (up[l] == -1)
                {
                    conbo_bad();

                    ub = 1;
                    upbad = 1;
                    timeru = 0;
                    array_ImageTop[l].BeginAnimation(Canvas.TopProperty, anime_stop);
                }

                if (down[l] == -1)
                {
                    conbo_bad();

                    db = 1;
                    downbad = 1;
                    timerd = 0;
                    array_ImageBottom[l].BeginAnimation(Canvas.TopProperty, anime_stop);
                }

                if (right[l] == -1)
                {
                    conbo_bad();

                    rb = 1;
                    rightbad = 1;
                    timerr = 0;
                    array_ImageRight[l].BeginAnimation(Canvas.TopProperty, anime_stop);
                }
            }
        }

        /* 機能：ボタンが押されたときのイベント
         * 使う関数：conbo_great     greatのコンボ計算と点数表示  
         *           conbo_good      goodのコンボ計算と点数表示
         * 影響：判定できるときに矢印キーを押すと矢印を元の位置に戻す
         *       押したタイミングが一番良いときに「great」と表示する
         *       押したタイミングが良いときに「good」と表示する
         */
        public void button_DownEvent()
        {
            if (Keyboard.IsKeyDown(Key.Left) && keyl == 0)
            {
                for (l = 0; l < Image_index; l++)
                {
                    if (left[l] != 0)
                    {
                        array_ImageLeft[l].BeginAnimation(Canvas.TopProperty, anime_stop);
                    }
                    if (left[l] == 1)   //左が１(great)
                    {
                        conbo_great();

                        leftgreat = 1;
                        lb = 1;
                        timerl = 0;
                    }
                    if (left[l] == 2)    //左が２(good)
                    {
                        conbo_good();


                        leftgood = 1;
                        lb = 1;
                        timerl = 0;
                    }
                    downl = 1;
                    btimerl = 0;
                    keyl = 1;
                }
            }

            if (Keyboard.IsKeyUp(Key.Left))     //ボタンが離されたとき
            {
                ImageFrontA[0].Source = imageBB;
                keyl = 0;
            }
            if (leftgreat == 1)     //左greatの段階的表示
            {
                if (timerl == 0)
                {
                    label2.Content = String.Format("G");
                }
                if (timerl == 10)
                {
                    label2.Content = String.Format("Gr");
                }
                if (timerl == 20)
                {
                    label2.Content = String.Format("Gre");
                }
                if (timerl == 30)
                {
                    label2.Content = String.Format("Grea");
                }
                if (timerl == 40)
                {
                    label2.Content = String.Format("Great!");
                    leftgreat = 0;
                }
            }
            if (leftgood == 1)      //左goodの段階的表示
            {
                if (timerl == 0)
                {
                    label2.Content = String.Format("G");
                }
                if (timerl == 10)
                {
                    label2.Content = String.Format("Go");
                }
                if (timerl == 20)
                {
                    label2.Content = String.Format("Goo");
                }
                if (timerl == 30)
                {
                    label2.Content = String.Format("Good");
                }
                if (timerl == 40)
                {
                    label2.Content = String.Format("Good!");
                    leftgood = 0;
                }
            }
            if (leftbad == 1)       //左badの段階的表示
            {
                if (timerl == 0)
                {
                    label2.Content = String.Format("B");
                }
                if (timerl == 10)
                {
                    label2.Content = String.Format("Ba");
                }
                if (timerl == 20)
                {
                    label2.Content = String.Format("Bad");
                }
                if (timerl == 30)
                {
                    label2.Content = String.Format("Bad!");
                    leftbad = 0;
                }
            }


            //上
            if (Keyboard.IsKeyDown(Key.Up) && keyu == 0)
            {
                for (l = 0; l < Image_index; l++)
                {
                    if (up[l] != 0)
                    {
                        array_ImageTop[l].BeginAnimation(Canvas.TopProperty, anime_stop);
                    }
                    if (up[l] == 1)   //上が１(great)
                    {
                        conbo_great();

                        upgreat = 1;
                        ub = 1;
                        timeru = 0;
                    }
                    if (up[l] == 2)    //上が２(good)
                    {
                        conbo_good();

                        upgood = 1;
                        ub = 1;
                        timeru = 0;
                    }
                    downt = 1;
                    btimert = 0;
                    keyu = 1;
                }
            }
            if (Keyboard.IsKeyUp(Key.Up))       //ボタンが離れた時
            {
                ImageFrontB[0].Source = imageBB;
                keyu = 0;
            }
            if (upgreat == 1)       //上greatの段階的表示
            {
                if (timeru == 0)
                {
                    label4.Content = String.Format("G");
                }
                if (timeru == 10)
                {
                    label4.Content = String.Format("Gr");
                }
                if (timeru == 20)
                {
                    label4.Content = String.Format("Gre");
                }
                if (timeru == 30)
                {
                    label4.Content = String.Format("Grea");
                }
                if (timeru == 40)
                {
                    label4.Content = String.Format("Great!");
                    upgreat = 0;
                }
            }
            if (upgood == 1)        //上goodの段階的表示
            {
                if (timeru == 0)
                {
                    label4.Content = String.Format("G");
                }
                if (timeru == 10)
                {
                    label4.Content = String.Format("Go");
                }
                if (timeru == 20)
                {
                    label4.Content = String.Format("Goo");
                }
                if (timeru == 30)
                {
                    label4.Content = String.Format("Good");
                }
                if (timeru == 40)
                {
                    label4.Content = String.Format("Good!");
                    upgood = 0;
                }
            }
            if (upbad == 1)     //上badの段階的表示
            {
                if (timeru == 0)
                {
                    label4.Content = String.Format("B");
                }
                if (timeru == 10)
                {
                    label4.Content = String.Format("Ba");
                }
                if (timeru == 20)
                {
                    label4.Content = String.Format("Bad");
                }
                if (timeru == 30)
                {
                    label4.Content = String.Format("Bad!");
                    upbad = 0;
                }
            }

            //下
            if (Keyboard.IsKeyDown(Key.Down) && keyd == 0)
            {
                for (l = 0; l < Image_index; l++)
                {
                    if (down[l] != 0)
                    {
                        array_ImageBottom[l].BeginAnimation(Canvas.TopProperty, anime_stop);
                    }

                    if (down[l] == 1)   //下が１(great)
                    {
                        conbo_great();

                        downgreat = 1;
                        db = 1;
                        timerd = 0;
                    }
                    if (down[l] == 2)    //下が２(good)
                    {
                        conbo_good();

                        downgood = 1;
                        db = 1;
                        timerd = 0;
                    }
                    downb = 1;
                    btimerb = 0;
                    keyd = 1;
                }
            }
            if (Keyboard.IsKeyUp(Key.Down))     //ボタンが離れた時
            {
                ImageFrontC[0].Source = imageBB;
                keyd = 0;
            }
            if (downgreat == 1)     //下greatの段階的表示
            {
                if (timerd == 0)
                {
                    label3.Content = String.Format("G");
                }
                if (timerd == 10)
                {
                    label3.Content = String.Format("Gr");
                }
                if (timerd == 20)
                {
                    label3.Content = String.Format("Gre");
                }
                if (timerd == 30)
                {
                    label3.Content = String.Format("Grea");
                }
                if (timerd == 40)
                {
                    label3.Content = String.Format("Great!");
                    downgreat = 0;
                }
            }
            if (downgood == 1)      //下goodの段階的表示
            {
                if (timerd == 0)
                {
                    label3.Content = String.Format("G");
                }
                if (timerd == 10)
                {
                    label3.Content = String.Format("Go");
                }
                if (timerd == 20)
                {
                    label3.Content = String.Format("Goo");
                }
                if (timerd == 30)
                {
                    label3.Content = String.Format("Good");
                }
                if (timerd == 40)
                {
                    label3.Content = String.Format("Good!");
                    downgood = 0;
                }
            }
            if (downbad == 1)       //下badの段階的表示
            {
                if (timerd == 0)
                {
                    label3.Content = String.Format("B");
                }
                if (timerd == 10)
                {
                    label3.Content = String.Format("Ba");
                }
                if (timerd == 20)
                {
                    label3.Content = String.Format("Bad");
                }
                if (timerd == 30)
                {
                    label3.Content = String.Format("Bad!");
                    downbad = 0;
                }
            }

            //右
            if (Keyboard.IsKeyDown(Key.Right) && keyr == 0)
            {
                for (l = 0; l < Image_index; l++)
                {
                    if (right[l] != 0)
                    {
                        array_ImageRight[l].BeginAnimation(Canvas.TopProperty, anime_stop);
                    }
                    if (right[l] == 1)   //右が１(great)
                    {
                        conbo_great();

                        rightgreat = 1;
                        rb = 1;
                        timerr = 0;
                    }
                    if (right[l] == 2)    //右が２(good)
                    {
                        conbo_good();

                        rightgood = 1;
                        rb = 1;
                        timerr = 0;
                    }
                    downr = 1;
                    btimerr = 0;
                    keyr = 1;
                }
            }
            if (Keyboard.IsKeyUp(Key.Right))        //ボタンが離されたとき
            {
                ImageFrontD[0].Source = imageBB;
                keyr = 0;
            }
            if (rightgreat == 1)        //右greatの段階的表示
            {
                if (timerr == 0)
                {
                    label16.Content = String.Format("G");
                }
                if (timerr == 10)
                {
                    label16.Content = String.Format("Gr");
                }
                if (timerr == 20)
                {
                    label16.Content = String.Format("Gre");
                }
                if (timerr == 30)
                {
                    label16.Content = String.Format("Grea");
                }
                if (timerr == 40)
                {
                    label16.Content = String.Format("Great!");
                    rightgreat = 0;
                }
            }
            if (rightgood == 1)     //右goodの段階的表示
            {
                if (timerr == 0)
                {
                    label16.Content = String.Format("G");
                }
                if (timerr == 10)
                {
                    label16.Content = String.Format("Go");
                }
                if (timerr == 20)
                {
                    label16.Content = String.Format("Goo");
                }
                if (timerr == 30)
                {
                    label16.Content = String.Format("Good");
                }
                if (timerr == 40)
                {
                    label16.Content = String.Format("Good!");
                    rightgood = 0;
                }
            }
            if (rightbad == 1)      //右badの段階的表示
            {
                if (timerr == 0)
                {
                    label16.Content = String.Format("B");
                }
                if (timerr == 10)
                {
                    label16.Content = String.Format("Ba");
                }
                if (timerr == 20)
                {
                    label16.Content = String.Format("Bad");
                }
                if (timerr == 30)
                {
                    label16.Content = String.Format("Bad!");
                    rightbad = 0;
                }
            }
        }

        //コンボ表示方法（サイズの継続変更とリセット）//
        public void conbo_Display()
        {
            if (comandar == 1)
            {
                label15.FontSize = 100;
                comandar = 0;
                comtimers = 0;
            }
            if (comando == 1)
            {
                label15.FontSize += 1;
                comtimers = comtimers + 1;
                if (comtimers == 50)
                {
                    label15.FontSize = 100;
                    label15.Content = String.Format("");
                    comtimers = 0;
                    comando = 0;
                }

            }
        }

        /*
         * 矢印キーが押された時のタイミング表示のリセット
         */
        public void reset_Label()
        {
            if (timerr == 100 && rb == 1)     //右関連のリセット
            {
                label2.Content = String.Format("");
                rb = 0;
                timerr = 0;

            }
            if (timerl == 100 && lb == 1)     //左関連のリセット
            {
                label3.Content = String.Format("");
                lb = 0;
                timerl = 0;

            }
            if (timeru == 100 && ub == 1)    //上関連のリセット
            {
                label4.Content = String.Format("");
                ub = 0;
                timeru = 0;

            }
            if (timerd == 100 && db == 1)    //下関連のリセット
            {
                label16.Content = String.Format("");
                db = 0;
                timerd = 0;

            }
        }



        /*
         * 降ってくる矢印の縦の位置の変換
         */
        public void fallallow_convert()
        {
            for (int i = 0; i < Image_index; i++)
            {
                topsL[i] = Convert.ToDouble(array_ImageLeft[i].GetValue(Canvas.TopProperty));     //全ての左矢印の縦の位置に変換
                topsT[i] = Convert.ToDouble(array_ImageTop[i].GetValue(Canvas.TopProperty));     //全ての左矢印の縦の位置に変換
                topsB[i] = Convert.ToDouble(array_ImageBottom[i].GetValue(Canvas.TopProperty));     //全ての左矢印の縦の位置に変換
                topsR[i] = Convert.ToDouble(array_ImageRight[i].GetValue(Canvas.TopProperty));     //全ての左矢印の縦の位置に変換
            }
        }

        /*
         * 機能：選択された曲ごとに矢印を落とすタイミングを設定する
         *       添え字を超えないようにする
         */
        public void judge_timingEntry(int song_number)
        {
            switch (song_number) 
            {
                case 1:
                    if (timing_index < alps_timing.Length)
                    {
                        timing_entry = alps_timing[timing_index];
                    }
                    break;
                case 2:
                    if(timing_index < kirakira_timing.Length)
                    {
                        timing_entry = kirakira_timing[timing_index];
                    }
                    break;
                case 3:
                    if (timing_index < syabon_timing.Length)
                    {
                        timing_entry = syabon_timing[timing_index];
                    }
                    break;
                case 4:
                    if (timing_index < haru_timing.Length)
                    {
                        timing_entry = haru_timing[timing_index];
                    }
                    break;
                case 5:
                    if (timing_index < mori_timing.Length)
                    {
                        timing_entry = mori_timing[timing_index];
                    }
                    break;
                case 6:
                    if (timing_index < rondon_timing.Length)
                    {
                        timing_entry = rondon_timing[timing_index];
                    }
                    break;
                case 7:
                    if (timing_index < jinguru_timing.Length)
                    {
                        timing_entry = jinguru_timing[timing_index];
                    }
                    break;
                case 8:
                    if (timing_index < okina_timing.Length)
                    {
                        timing_entry = okina_timing[timing_index];
                    }
                    break;
                case 9:
                    if (timing_index < musi_timing.Length)
                    {
                        timing_entry = musi_timing[timing_index];
                    }
                    break;
                case 10:
                    if (timing_index < usagi_timing.Length)
                    {
                        timing_entry = usagi_timing[timing_index];
                    }
                    break;

                case 11:
                    if (timing_index < kakusi_timing.Length)
                    {
                        timing_entry = kakusi_timing[timing_index];
                    }
                    break;

            }
        }


        /*
         * 引数：time, target
         * 機能：曲にあわせたタイミングのときかどうか判定する
         *       もしそのときなら矢印を落とす関数を呼び出す
         *       そのあと配列の添え字を一つ増やす
         */
        public void judge_fallAllowtiming (int time, int target) 
        {
            if (time == target) {
                switch (le)
                {
                    case 1:
                        fallAllow_easy();
                        break;

                    case 2:
                        fallAllow_normal();
                        break;

                    case 3:
                        fallAllow_hard();
                        break;
                }

                timing_index += 1;
            }   
        }

        /*
         * 引数：int time
         * 機能：矢印を落とす
         *       使うのは左矢印のみ
         * 
         */
        public void fallAllow_easy()
        {
            array_ImageLeft[entry_ImageLeft].BeginAnimation(Canvas.TopProperty, anime);
        }

        /*
         * 引数：int time
         * 機能：矢印を落とす
         *       使うのは左矢印と右矢印
         * 
         */
        public void fallAllow_normal()
        {
            int rand_number = rand.Next(2);
            switch (rand_number)
            {
                case 0:
                    array_ImageLeft[entry_ImageLeft].BeginAnimation(Canvas.TopProperty, anime);
                    break;
                case 1:
                    array_ImageTop[entry_ImageTop].BeginAnimation(Canvas.TopProperty, anime);
                    break;
            }
        }

        
        /*
         * 引数：int time
         * 機能：矢印を落とす
         *       使うのはすべての矢印
         * 
         */
        public void fallAllow_hard()
        {
            int rand_number = rand.Next(4);
            switch (rand_number) { 
                case 0:
                    array_ImageLeft[entry_ImageLeft].BeginAnimation(Canvas.TopProperty, anime);
                break;
                    
                case 1:
                    array_ImageTop[entry_ImageTop].BeginAnimation(Canvas.TopProperty, anime);
                break;
            
                case 2:
                    array_ImageBottom[entry_ImageBottom].BeginAnimation(Canvas.TopProperty, anime);
                break;
                
                case 3:
                    array_ImageRight[entry_ImageRight].BeginAnimation(Canvas.TopProperty, anime);
                break;
            }
        }

        /*
         * 機能：画面に表示されていない左矢印を見つけてそれを次に呼ばれた時に使うようにする
         *       （見つけ方は矢印の場所の値から）      
         * 
         *       1のとき　画面に表示されている＝左矢印の場所が0以上
         *       0のとき　画面に表示されていない＝左矢印が0未満
         *       
         * 戻り値：int
         *         0になったときに左矢印の配列の添え字の値を返す     
         * 
         */
        public int findLeastEmpty_LImage()
        {
            int n = 0;
            int flag = 1;
            while (flag == 1 && n < Image_index)
            {
                if (topsL[n] < 0.0)
                {
                    flag = 0;
                }
                else
                {
                    n++;
                }
            }

            return n;

        }



        /*
         * 機能：画面に表示されていない上矢印を見つけてそれを次に呼ばれた時に使うようにする
         *       （見つけ方は矢印の場所の値から）      
         * 
         *       1のとき　画面に表示されている＝上矢印の場所が0以上
         *       0のとき　画面に表示されていない＝上矢印が0未満
         *       
         * 戻り値：int
         *         0になったときに上矢印の配列の添え字の値を返す     
         * 
         */
        public int findLeastEmpty_TImage()
        {
            int n = 0;
            int flag = 1;
            while (flag == 1 && n < Image_index)
            {
                if (topsT[n] < 0.0)
                {
                    flag = 0;
                }
                else
                {
                    n++;
                }
            }

            return n;

        }

        /*
         * 機能：画面に表示されていない下矢印を見つけてそれを次に呼ばれた時に使うようにする
         *       （見つけ方は矢印の場所の値から）      
         * 
         *       1のとき　画面に表示されている＝下矢印の場所が0以上
         *       0のとき　画面に表示されていない＝下矢印が0未満
         *       
         * 戻り値：int
         *         0になったときに下矢印の配列の添え字の値を返す     
         * 
         */
        public int findLeastEmpty_BImage()
        {
            int n = 0;
            int flag = 1;
            while (flag == 1 && n < Image_index)
            {
                if (topsB[n] < 0.0)
                {
                    flag = 0;
                }
                else
                {
                    n++;
                }
            }

            return n;

        }

        /*
         * 機能：画面に表示されていない右矢印を見つけてそれを次に呼ばれた時に使うようにする
         *       （見つけ方は矢印の場所の値から）      
         * 
         *       1のとき　画面に表示されている＝右矢印の場所が0以上
         *       0のとき　画面に表示されていない＝右矢印が0未満
         *       
         * 戻り値：int
         *         0になったときに右矢印の配列の添え字の値を返す     
         * 
         */
        public int findLeastEmpty_RImage()
        {
            int n = 0;
            int flag = 1;
            while (flag == 1 && n < Image_index)
            {
                if (topsR[n] < 0.0)
                {
                    flag = 0;
                }
                else
                {
                    n++;
                }
            }

            return n;

        }


        /*
         * 機能：画面に表示されていない矢印を見つけて配列の添え字の値を設定する
         */
        public void entry_Image()
        {
            entry_ImageLeft = findLeastEmpty_LImage();    //画面に表示されていない左矢印の配列の添字を設定する
            entry_ImageTop = findLeastEmpty_TImage();    //画面に表示されていない上矢印の配列の添字を設定する
            entry_ImageBottom = findLeastEmpty_BImage();    //画面に表示されていない下矢印の配列の添字を設定する
            entry_ImageRight = findLeastEmpty_RImage();    //画面に表示されていない右矢印の配列の添字を設定する
        }

        /*
         * 機能：矢印のタイミングした値を扱いやすいものに変換
         */
        public void convert_judge_timing(int l)
        {
            left[l] = judge_timing(topsL[l]);
            up[l] = judge_timing(topsT[l]);
            down[l] = judge_timing(topsB[l]);
            right[l] = judge_timing(topsR[l]);
        }

        /*
         * 機能：音を止める
         *       次のページに移動
         */
        public void end_player() 
        {
            NavigationService.Navigate(new Uri("/result.xaml", UriKind.Relative));
            playerA.Close();
        }

        //ボタンアクション
        public void botton_action(int L,int T,int B,int R)
        {
            if (downl==1)
            {
                ImageFrontA[0].Source = imageLY;
                if (L==10)
                {
                    ImageFrontA2[0].Source = imageLY;
                }
                if (L==20)
                {
                    ImageFrontA[0].Source = imageBB;
                    ImageFrontA2[0].Source = imageBB;
                    downl = 0;
                }
            }
            if (downt == 1)
            {
                ImageFrontB[0].Source = imageTY;
                if (T == 10)
                {
                    ImageFrontB2[0].Source = imageTY;
                }
                if (T == 20)
                {
                    ImageFrontB[0].Source = imageBB;
                    ImageFrontB2[0].Source = imageBB;
                    downt = 0;
                }
            }
            if (downb == 1)
            {
                ImageFrontC[0].Source = imageBY;
                if (B == 10)
                {
                    ImageFrontC2[0].Source = imageBY;
                }
                if (B == 20)
                {
                    ImageFrontC[0].Source = imageBB;
                    ImageFrontC2[0].Source = imageBB;
                    downb = 0;
                }
            }
            if (downr == 1)
            {
                ImageFrontD[0].Source = imageRY;
                if (R == 10)
                {
                    ImageFrontD2[0].Source = imageRY;
                }
                if (R == 20)
                {
                    ImageFrontD[0].Source = imageBB;
                    ImageFrontD2[0].Source = imageBB;
                    downr = 0;
                }
            }
        }

        public void light_action(int L, int T, int B, int R)
        {
            switch (L)
            {
                case 10:
                    ImageLightL[0].Source = imageLY2;
                    break;
                case 20:
                    ImageLightL[0].Source = imageLY;
                    ltimerl = 0;
                    break;
            }
            switch (T)
            {
                case 14:
                    ImageLightT[0].Source = imageTY2;
                    break;
                case 28:
                    ImageLightT[0].Source = imageTY;
                    ltimert = 0;
                    break;
            }
            switch (B)
            {
                case 12:
                    ImageLightB[0].Source = imageBY2;
                    break;
                case 24:
                    ImageLightB[0].Source = imageBY;
                    ltimerb = 0;
                    break;
            }
            switch (R)
            {
                case 16:
                    ImageLightR[0].Source = imageRY2;
                    break;
                case 32:
                    ImageLightR[0].Source = imageRY;
                    ltimerr = 0;
                    break;
            }

        }

        /*
         * メインプログラム
         * タイマー(0.01秒ごと)に行われる動作
         */
        void UpdateEvent(object sender, EventArgs e)
        {

            timers = timers + 1;                                //吹き出しアニメ効果用タイマー変数を増やす
            timerr = timerr + 1;
            timerl = timerl + 1;
            timeru = timeru + 1;
            timerd = timerd + 1;
            timerlink = timerlink + 1;
            btimerl++;
            btimert++;
            btimerb++;
            btimerr++;
            ltimerl++;
            ltimert++;
            ltimerb++;
            ltimerr++;

            /* 
             * ●●switch文ですると動かないので改良が必要●●
             */
            if (taskCounter == 100)
            {
                playerA.Play();
            }

            taskCounter++;      //矢印を落とすタイミングのためのタイマー変数を増やす

            fallallow_convert();    //降ってくる矢印の縦の値の変換

            judge_timingEntry(so); //落とすタイミングを設定

            entry_Image();         //画面に表示されていない矢印を見つけて配列の添え字を設定する

            judge_fallAllowtiming(taskCounter, timing_entry);   //タイミングがきたら落とす

            /* 矢印の降ってきたときのタイミングの判定をする
             * 使う関数：judge_timing
             * 機能：判定
             */
            for (l = 0; l < Image_index; l++)
            {
                convert_judge_timing(l);
            }

            button_DownEvent();     //矢印キーが押された時の処理

            case_JobBad();      //矢印キーを押したときに遅かった場合の処理

            conbo_Display();        //コンボの表示

            reset_Label();          //表示のリセット

            botton_action(btimerl,btimert,btimerb,btimerr);     //ボタンアクション
            
            light_action(ltimerl, ltimert, ltimerb, ltimerr);     //矢印アクション

            conbo_Max();

            if (taskCounter == endplayer_time) 
            {
                end_player();
            }


        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }





    }
}
