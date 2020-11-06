using System.Diagnostics;

namespace Session10.MVC.Infrastructure
{
    public class UptimeService
    {
        private readonly Stopwatch stopwatch;

        public UptimeService()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public long Uptime => stopwatch.ElapsedTicks;
    }
}
