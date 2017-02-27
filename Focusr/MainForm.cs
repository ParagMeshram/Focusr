namespace Focusr
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Focusr.Extensions;

    public partial class MainForm : MovableForm
    {
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private readonly CountdownFormatter formatter;
        private readonly CountdownTimer timer;

        private volatile bool isHighlighting;
        private bool editing;

        public MainForm(CountdownFormatter formatter, CountdownTimer timer)
        {
            this.formatter = formatter;
            this.timer = timer;
            this.timer.CountdownTick += this.CountdownCountdownTick;
            this.timer.CountdownComplete += this.TimerOnCountdownComplete;
            this.ExcludeList = "tbxCountdownTime,lblCountdownTime";
            this.InitializeComponent();

            // Removes flickering while changeing form color
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            //this.btnClose.BackColor = Color.FromArgb(25, 0, 0, 0);
            //this.btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 0, 0, 0);
            //this.btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0, 0);

            this.btnControl.Tag = "Play";

            //this.btnControl.BackColor = Color.FromArgb(25, 0, 0, 0);
            //this.btnControl.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 0, 0, 0);
            //this.btnControl.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0, 0);

            //this.btnStop.BackColor = Color.FromArgb(25, 0, 0, 0);
            //this.btnStop.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 0, 0, 0);
            //this.btnStop.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0, 0);

            var desktopWorkingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;

            //this.Opacity = .80;
        }

        // Removes flickering while changeing form color
        protected override CreateParams CreateParams
        {
            get
            {
                var handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000; // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy,
            uint uFlags);

        private void TimerOnCountdownComplete(object sender, CountdownEventArgs countdownEventArgs)
        {
            this.Invoke(new Action(() => { this.Shake(); }));
        }

        // Removes flickering while changeing form color
        protected override void OnPaint(PaintEventArgs e)
        {
            
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST || m.Msg == HT_CLIENT)
                m.Result = (IntPtr) (HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;


        private void CountdownCountdownTick(object sender, CountdownEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                //if (!this.isHighlighting && e.TimeSpanLeft.TotalSeconds < 5)
                //{
                //    this.isHighlighting = true;
                //    this.StartHighlighting();
                //}

                this.lblCountdownTime.Text = this.formatter.Format(e.TimeSpanLeft);
            }));

            if (!this.isHighlighting && e.TimeSpanLeft != TimeSpan.Zero && e.TimeSpanLeft.TotalSeconds <= 5)
            {
                this.isHighlighting = true;
                Task.Factory.StartNew(this.StartHighlighting);
            }
        }

        private async void StartHighlighting()
        {
            for (; this.timer.TimeSpanLeft != TimeSpan.Zero; await Task.Delay(500))
            {
                var backColor = this.BackColor == Color.DarkGreen ? Color.DarkRed : Color.DarkGreen;
                this.ChangeFormColor(backColor);
            }

            await Task.Delay(500);

            this.ChangeFormColor(Color.DarkGreen);

            await Task.Delay(500);

            this.ChangeFormColor(Color.DarkRed);

            //this.Invoke(new Action(() =>
            //{
            //    this.Shake();
            //}));

            this.isHighlighting = false;
        }

        private void ChangeFormColor(Color color)
        {
            this.SuspendLayout();

            this.BackColor = color;
            this.tbxCountdownTime.BackColor = color;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowCaret(IntPtr hWnd);

        private void tbxCountdownTime_MouseLeave(object sender, EventArgs e)
        {
            this.lblCountdownTime.Visible = true;

            //HideCaret(((Control)sender).Handle);
            //this.tbxCountdownTime.SendToBack();
            //this.lblCountdownTime.BringToFront();
            //this.Invalidate();
            this.editing = false;
        }

        private void tbxCountdownTime_MouseEnter(object sender, EventArgs e)
        {
            ShowCaret(((Control) sender).Handle);
            this.editing = true;
        }

        private void lblCountdownTime_MouseEnter(object sender, EventArgs e)
        {
            this.lblCountdownTime.Visible = false;
            this.tbxCountdownTime.Text = this.lblCountdownTime.Text;
            this.editing = true;
        }

        private void lblCountdownTime_MouseLeave(object sender, EventArgs e)
        {
            this.tbxCountdownTime.Text = this.lblCountdownTime.Text;
            this.editing = false;
        }

        private void tbxCountdownTime_TextChanged(object sender, EventArgs e)
        {
            this.lblCountdownTime.TextChanged -= this.lblCountdownTime_TextChanged;
            this.lblCountdownTime.Text = this.tbxCountdownTime.Text;
            this.lblCountdownTime.TextChanged += this.lblCountdownTime_TextChanged;
        }

        private void lblCountdownTime_TextChanged(object sender, EventArgs e)
        {
            if (!this.editing && !this.tbxCountdownTime.Focused)
            {
                this.tbxCountdownTime.TextChanged -= this.tbxCountdownTime_TextChanged;
                this.tbxCountdownTime.Text = this.lblCountdownTime.Text;
                this.tbxCountdownTime.TextChanged += this.tbxCountdownTime_TextChanged;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            if ((string)this.btnControl.Tag == "Play")
            {
                this.btnControl.Tag = "Pause";
            }
            else
            {
                this.btnControl.Tag = "Play";
                this.btnControl.Text = "\u003B";
            }

            this.timer.Start(TimeSpan.Parse(this.tbxCountdownTime.Text));
        }

        private void tbxCountdownTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                this.lblCountdownTime.Text = this.tbxCountdownTime.Text;
            }

        }
    }
}