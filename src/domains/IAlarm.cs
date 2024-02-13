namespace RadioactivityMonitor.Domains {
    public interface IAlarm
    {
        public bool IsAlarmOn 
        {
            get;
        }

        public long AlarmCount 
        {
            get;
        }

        public void Silent();

        public void Reset();

        public void Check(double value);
    } 
}