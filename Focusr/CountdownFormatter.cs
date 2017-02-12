namespace Focusr
{
    using System;

    public class CountdownFormatter
    {
        public string Format(TimeSpan timeSpan)
        {
            return $"{timeSpan.TotalHours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
        }
    }
}