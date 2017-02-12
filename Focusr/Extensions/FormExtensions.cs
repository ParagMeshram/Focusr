namespace Focusr.Extensions
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public static class FormExtensions
    {
        public static void Shake(this Form form, int shakeAmplitude = 10)
        {
            var original = form.Location;
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var timer = new System.Windows.Forms.Timer {Interval = 10};
            var tickCount = 0;
            timer.Tick += (s, e) =>
            {
                if (++tickCount > 50)
                {
                    timer.Dispose();
                    form.Location = original;
                    return;
                }
                //;
                //for (var i = 0; i < 20; i++)
                //{
                //form.SuspendLayout();
                form.Location = new Point(original.X + rnd.Next(-shakeAmplitude, shakeAmplitude),
                    original.Y + rnd.Next(-shakeAmplitude, shakeAmplitude));
                //form.ResumeLayout(false);
                //form.PerformLayout();

                // Thread.Sleep(20);
                //}
            };

            timer.Start();

            
        }
    }
}