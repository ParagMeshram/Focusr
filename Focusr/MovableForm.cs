namespace Focusr
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class MovableForm : Form
    {
        private readonly IContainer components = null;
        private bool drag;
        private Point startPoint = new Point(0, 0);

        protected MovableForm()
        {
            this.InitializeComponent();
            MouseDown += this.Form_MouseDown;
            MouseUp += this.Form_MouseUp;
            MouseMove += this.Form_MouseMove;
        }

        public string ExcludeList { set; get; } = "";

        public bool Draggable { set; get; } = true;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                this.components?.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // 
            // FormBase
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(369, 182);
            this.Name = "FormBase";
            this.Text = "AlerterForm";
        }

        #endregion

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (this.Draggable && (this.ExcludeList.IndexOf(e.Control.Name, StringComparison.OrdinalIgnoreCase) < 0))
            {
                e.Control.MouseDown += this.Form_MouseDown;
                e.Control.MouseUp += this.Form_MouseUp;
                e.Control.MouseMove += this.Form_MouseMove;
            }
            base.OnControlAdded(e);
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            this.drag = true;
            this.startPoint = new Point(e.X, e.Y);
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.drag) return;

            var p1 = new Point(e.X, e.Y);
            var p2 = this.PointToScreen(p1);
            var p3 = new Point(p2.X - this.startPoint.X, p2.Y - this.startPoint.Y);

            this.Location = p3;
        }
    }
}