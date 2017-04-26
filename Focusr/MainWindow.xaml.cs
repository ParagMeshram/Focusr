namespace ChromaticBox.CountDownr.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Timers;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    public class CountdownEventArgs : EventArgs
    {
        public TimeSpan TimeSpanLeft { get; set; }
    }

    public class CountdownFormatter
    {
        public string Format(TimeSpan timeSpan)
        {
            return $"{timeSpan.TotalHours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
        }
    }

    public class CountdownTimer
    {
        private readonly Timer timer;
        private TimeSpan timeSpanInit;

        public CountdownTimer()
        {
            this.timer = new Timer { Interval = 1000 };
            this.timer.Elapsed += this.OnTick;
        }

        public TimeSpan TimeSpanLeft { get; private set; }

        public event EventHandler<CountdownEventArgs> CountdownTick;
        public event EventHandler<CountdownEventArgs> CountdownComplete;

        public void Start(TimeSpan time)
        {
            this.timeSpanInit = this.TimeSpanLeft = time;
            this.timer.Enabled = true;
        }

        public void Stop()
        {
            this.timer.Enabled = false;
            this.TimeSpanLeft = this.timeSpanInit;
        }

        public void Reset()
        {
            this.timer.Enabled = false;
            this.TimeSpanLeft = this.timeSpanInit;
            this.timer.Enabled = true;
        }

        public void Pause()
        {
            this.timer.Enabled = false;
        }

        public void Resume()
        {
            this.timer.Enabled = true;
        }

        protected virtual void OnTick(object sender, ElapsedEventArgs args)
        {
            this.CountdownTick?.Invoke(this, new CountdownEventArgs { TimeSpanLeft = this.TimeSpanLeft });

            if (this.TimeSpanLeft == TimeSpan.Zero)
            {
                this.timer.Enabled = false;
                this.CountdownComplete?.Invoke(this, new CountdownEventArgs { TimeSpanLeft = TimeSpan.Zero });
            }
            else
                this.TimeSpanLeft = this.TimeSpanLeft.Subtract(TimeSpan.FromSeconds(1));
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private volatile bool isHighlighting;
        private bool editing;
        private readonly CountdownTimer timer = new CountdownTimer();
        private readonly CountdownFormatter formatter = new CountdownFormatter();

        public MainWindow()
        {
            this.InitializeComponent();

            this.timer.CountdownTick += this.CountdownCountdownTick;
            this.timer.CountdownComplete += this.TimerOnCountdownComplete;

            this.EditButton.Tag = true;
        }

        private void CountdownCountdownTick(object sender, CountdownEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                //if (!this.isHighlighting && e.TimeSpanLeft.TotalSeconds < 5)
                //{
                //    this.isHighlighting = true;
                //    this.StartHighlighting();
                //}

                //this.LblCountdownTime.Text = this.formatter.Format(e.TimeSpanLeft);
                this.Hours.Text = $"{e.TimeSpanLeft.TotalHours:00}";
                this.Minutes.Text = $"{e.TimeSpanLeft.Minutes:00}";
                this.Seconds.Text = $"{e.TimeSpanLeft.Seconds:00}";
            });

            if (!this.isHighlighting && e.TimeSpanLeft != TimeSpan.Zero && e.TimeSpanLeft.TotalSeconds <= 5)
            {
                this.isHighlighting = true;
                Task.Factory.StartNew(this.StartHighlighting);
            }
        }

        private void TimerOnCountdownComplete(object sender, CountdownEventArgs countdownEventArgs)
        {
            this.Dispatcher.Invoke(() => { this.Shake(); });
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            this.timer.Start(TimeSpan.FromSeconds(10));
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private async void StartHighlighting()
        {
            for (; this.timer.TimeSpanLeft != TimeSpan.Zero; await Task.Delay(500))
            {
                this.Dispatcher.Invoke(() =>
                {
                    var converter = new BrushConverter();
                    var backColor = this.MainCanvas.Background.ToString() == Colors.DarkGreen.ToString()
                        ? Colors.DarkRed
                        : Colors.DarkGreen;
                    this.ChangeWindowColor(backColor);
                });
            }

            await Task.Delay(500);

            this.ChangeWindowColor(Colors.DarkGreen);

            await Task.Delay(500);

            this.ChangeWindowColor(Colors.DarkRed);

            this.isHighlighting = false;
        }

        private void ChangeWindowColor(Color color)
        {
            this.Dispatcher.Invoke(() => { this.MainCanvas.Background = new SolidColorBrush(color); });
            //this.SuspendLayout();


            //this.tbxCountdownTime.BackColor = color;

            //this.ResumeLayout(false);
            //this.PerformLayout();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var editMode = !(bool)this.EditButton.Tag;

            if (editMode)
            {
                this.EditButton.Content = (String)this.Resources["EditIcon"];
                this.EditButton.Tag = true;
                this.Hours.BorderThickness =
                    this.Minutes.BorderThickness = this.Seconds.BorderThickness = new Thickness(0);
                this.Hours.IsReadOnly = true;
                this.Minutes.IsReadOnly = true;
                this.Seconds.IsReadOnly = true;
                this.Hours.IsReadOnlyCaretVisible = false;
                this.Minutes.IsReadOnlyCaretVisible = false;
                this.Seconds.IsReadOnlyCaretVisible = false;
            }
            else
            {
                this.EditButton.Content = (String)this.Resources["SaveIcon"];
                this.EditButton.Tag = false;
                this.Hours.BorderThickness =
                    this.Minutes.BorderThickness = this.Seconds.BorderThickness = new Thickness(0, 0, 0, 1);
                this.Hours.IsReadOnly = false;
                this.Minutes.IsReadOnly = false;
                this.Seconds.IsReadOnly = false;
                this.Hours.IsReadOnlyCaretVisible = true;
                this.Minutes.IsReadOnlyCaretVisible = true;
                this.Seconds.IsReadOnlyCaretVisible = true;
            }
        }

        /*
private void TbxCountdownTime_OnLostFocus(object sender, RoutedEventArgs e)
{
   this.LblCountdownTime.Text = this.TbxCountdownTime.Text;
   this.LblCountdownTime.Visibility = Visibility.Visible;
   this.TbxCountdownTime.Visibility = Visibility.Collapsed;
}

private void LblCountdownTime_OnMouseDown(object sender, MouseButtonEventArgs e)
{
   this.TbxCountdownTime.Visibility = Visibility.Visible;
   this.TbxCountdownTime.SelectAll();
   this.LblCountdownTime.Visibility = Visibility.Collapsed;
}
*/
    }
}