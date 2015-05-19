using System;
using System.Threading.Tasks;

namespace OneDrive
{
    public class BackoffHelper
    {
        public int MaximumTimeMilliseconds { get; set; }

        public int BaseTimeMilliseconds { get; set; }

        private readonly Random _random;

        public BackoffHelper()
        {
            MaximumTimeMilliseconds = 5000;
            BaseTimeMilliseconds = 100;
            _random = new Random();
        }

        /// <summary>
        /// Implements the full jitter backoff algorithm as defined here: http://www.awsarchitectureblog.com/2015/03/backoff.html
        /// </summary>
        /// <returns>A task that completes after the duration of the delay.</returns>
        /// <param name="errorCount">The number of times an error has occured for this particular command / session.</param>
        public async Task FullJitterBackoffDelay(int errorCount)
        {
            double expectedBackoffTime = Math.Min(MaximumTimeMilliseconds,
                BaseTimeMilliseconds * Math.Pow(2, errorCount));

            var sleepDuration = Between(_random, 0, (int)expectedBackoffTime);

            //System.Diagnostics.Debug.WriteLine("Waiting for: {0} milliseconds", sleepDuration);
            await Task.Delay(sleepDuration);
        }

        private static int Between(Random rnd, int lowNumber, int highNumber)
        {
            var dbl = rnd.NextDouble();
            int range = highNumber - lowNumber;
            double selectedValue = (dbl * range);
            return (int)(lowNumber + selectedValue);
        }


        private static BackoffHelper _defaultInstance = null;
        public static BackoffHelper Default
        {
            get
            {
                if (_defaultInstance == null)
                {
                    _defaultInstance = new BackoffHelper();
                }
                return _defaultInstance;
            }
        }
    }
}

