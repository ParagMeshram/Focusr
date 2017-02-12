namespace Focusr.Controls
{
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    public class FlatButton : Button
    {
        public TextRenderingHint TextRenderingHint { get; set; } = TextRenderingHint.SystemDefault;

        public FlatButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.FromArgb(25, 0, 0, 0);
            this.UseVisualStyleBackColor = false;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 0, 0, 0);
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0, 0);

            this.TabStop = false;
            this.SetStyle(ControlStyles.Selectable, false);
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.TextRenderingHint = this.TextRenderingHint;
            base.OnPaint(pe);
        }

        protected override bool ShowFocusCues => false;
    }
}