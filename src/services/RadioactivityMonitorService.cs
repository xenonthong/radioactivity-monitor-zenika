using RadioactivityMonitor.Domains;

namespace RadioactivityMonitor.Services
{
    /// <summary>
    /// A mock monitoring service class used by the main program.
    /// </summary>
    public class RadioactivityMonitorService
    {
        /// <summary>
        /// The alarm to be used to sound off any irregular radioactivities.
        /// </summary>
        private IAlarm _alarm;

        /// <summary>
        /// The sensor used to read the radioactivity value.
        /// </summary>
        private ISensor _sensor;

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="alarm">The alarm to be used to sound off any irregular radioactivities.</param>
        /// <param name="sensor">The sensor used to read the radioactivity value.</param>
        public RadioactivityMonitorService(IAlarm alarm, ISensor sensor)
        {
            _alarm = alarm;
            _sensor = sensor;
        }

        /// <summary>
        /// Helps to monitor the radioactivies from a sensor.
        /// </summary>
        public void Monitor()
        {
            var radioactivity = _sensor.NextMeasure();
            
            _alarm.Check(radioactivity);

            // This line is only included to help the code reviewer.
            Console.WriteLine($"New radioactivity value is: {radioactivity}. IsAlarmOn: {_alarm.IsAlarmOn}. AlarmCount: {_alarm.AlarmCount}");
        }
    }
}
