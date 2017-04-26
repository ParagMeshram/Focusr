namespace ChromaticBox.CountDownr.UI
{
    using System;
    using System.Timers;
    using System.Windows;

    public static class WindowExtensions
    {
        public static void Shake(this Window window, int shakeAmplitude = 10)
        {
            var original = new Point(window.Top, window.Left);
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var timer = new Timer { Interval = 10 };
            var tickCount = 0;
            timer.Elapsed += (s, e) =>
            {
                if (++tickCount > 50)
                {
                    timer.Dispose();
                    //form.Location = original;
                    window.Dispatcher.Invoke(() =>
                    {
                        window.Top = original.X;
                        window.Left = original.Y;
                    });
                    return;
                }
                //;
                //for (var i = 0; i < 20; i++)
                //{
                //form.SuspendLayout();
                var newLocation = new Point(original.X + rnd.Next(-shakeAmplitude, shakeAmplitude),
                    original.Y + rnd.Next(-shakeAmplitude, shakeAmplitude));

                window.Dispatcher.Invoke(() =>
                {
                    window.Top = newLocation.X;
                    window.Left = newLocation.Y;
                });

                //form.ResumeLayout(false);
                //form.PerformLayout();

                // Thread.Sleep(20);
                //}
            };

            timer.Start();


        }
    }
}
