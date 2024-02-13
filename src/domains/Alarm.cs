namespace RadioactivityMonitor.Domains
{
    /// <summary>
    /// Class <c>Alarm</c> is designed to monitor the radioactivity in a nuclear power plant 
    /// and set an alarm if the radioactivity falls outside of the expected range.
    /// </summary>
    public class Alarm : IAlarm
    {
        /// <summary>
        /// The minimum radioactivity threshold.
        /// </summary>
        public const double LowThreshold = 17;
        
        /// <summary>
        /// The maximum radioactivity threshold.
        /// </summary>
        public const double HighThreshold = 21;

        /// <summary>
        /// The number of times an alarm has been triggered.
        /// </summary>
        private long _alarmCount = 0;

        /// <summary>
        /// Indicates whether the alarm is 'active'.
        /// </summary>
        bool _isAlarmOn = false;

        public bool IsAlarmOn
        {
            get { return _isAlarmOn; }
        }

        public long AlarmCount 
        {
            get { return _alarmCount; }
        }

        /// <summary>
        /// Perform checks to determine if the alarm will need to be triggered.
        /// </summary>
        /// <param name="value">The radioactivity value</param>
        public void Check(double value)
        {
            if (FallsOutsideThreshold(value))
            {
                Trigger();
            }
        }

        /// <summary>
        /// Silence the alarm without resetting the counter. 
        /// </summary>
        public void Silent()
        {
            _isAlarmOn = false;
        }

        /// <summary>
        /// Resets both the alarm status and the counter to the default state.
        /// </summary>
        public void Reset()
        {
            _isAlarmOn = false;
            _alarmCount = 0;
        }

        /// <summary>
        /// Determines if the value provided falls beyond the min and max threshold.
        /// </summary>
        /// <param name="value">The radioactivity value</param>
        /// <returns>True if it falls outside of the min and max threshold. Otherwise, false.</returns>
        private bool FallsOutsideThreshold(double value)
        {
            return value < LowThreshold || value > HighThreshold;
        }

        /// <summary>
        /// Sets the alarm status to on and increment the counter value.
        /// </summary>
        private void Trigger()
        {
            _isAlarmOn = true;
            _alarmCount += 1;
        }
    }
}
