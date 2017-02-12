namespace Focusr
{
    using System;

    public class CountdownEventArgs : EventArgs
    {
        public TimeSpan TimeSpanLeft { get; set; }
    }
}