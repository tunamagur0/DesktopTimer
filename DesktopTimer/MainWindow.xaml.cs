using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace DesktopTimer
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 時刻表示用タイマー
        /// </summary>
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            timer = CreateTimer();
            timer.Start();

            MoveWindowToRightTop();
        }

        private void MoveWindowToRightTop()
        {
            Console.WriteLine(this.Left);
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width*3;
            this.Top = 0;
        }


        /// <summary>
        /// タイマー生成
        /// </summary>
        /// <returns>生成したタイマー</returns>
        private DispatcherTimer CreateTimer()
        {
            var t = new DispatcherTimer(DispatcherPriority.Normal);

            t.Interval = TimeSpan.FromMilliseconds(200);

            t.Tick += (sender, e) =>
            {
                textBlock.Text = DateTime.Now.ToString("HH:mm");
            };

            return t;
        }

        private void Viewbox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
