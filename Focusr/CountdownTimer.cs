namespace Focusr
{
    using System;
    using System.Timers;

    public class CountdownTimer
    {
        private readonly Timer timer;
        private TimeSpan timeSpanInit;

        public CountdownTimer(Timer timer)
        {
            this.timer = timer;
            this.timer.Interval = 1000;
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
            this.CountdownTick?.Invoke(this, new CountdownEventArgs {TimeSpanLeft = this.TimeSpanLeft});

            if (this.TimeSpanLeft == TimeSpan.Zero)
            {
                this.timer.Enabled = false;
                this.CountdownComplete?.Invoke(this, new CountdownEventArgs {TimeSpanLeft = TimeSpan.Zero});
            }
            else
                this.TimeSpanLeft = this.TimeSpanLeft.Subtract(TimeSpan.FromSeconds(1));
        }
    }
}