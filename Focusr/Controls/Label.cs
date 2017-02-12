namespace Focusr.Controls
{
    using System.Drawing.Text;
    using System.Windows.Forms;

    public class Label : System.Windows.Forms.Label
    {
        public TextRenderingHint TextRenderingHint { get; set; } = TextRenderingHint.SystemDefault;

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.TextRenderingHint = this.TextRenderingHint;
            base.OnPaint(pe);
        }
    }
}