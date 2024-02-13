using Xunit;
using RadioactivityMonitor.Domains;

namespace RadioactivityMonitor.Tests
{
    public class AlarmTests
    {
        [Fact]
        public void Check_ValueIsTheSameAsMinThreshold_ShouldNotTriggerAlarm()
        {
            // Arrange
            var alarm = new Alarm();
            
            // Act
            alarm.Check(Alarm.LowThreshold);

            // Assert
            Assert.False(alarm.IsAlarmOn);
            Assert.Equal(0, alarm.AlarmCount);
        }

        [Fact]
        public void Check_ValueIsTheSameAsMaxThreshold_ShouldNotTriggerAlarm()
        {
            // Arrange
            var alarm = new Alarm();
            
            // Act
            alarm.Check(Alarm.HighThreshold);

            // Assert
            Assert.False(alarm.IsAlarmOn);
            Assert.Equal(0, alarm.AlarmCount);
        }

        [Fact]
        public void Check_ValueIsLowerThanMinThreshold_ShouldTriggerAlarm()
        {
            // Arrange
            var alarm = new Alarm();
            
            // Act
            alarm.Check(Alarm.LowThreshold - 1);

            // Assert
            Assert.True(alarm.IsAlarmOn);
            Assert.Equal(1, alarm.AlarmCount);
        }

        [Fact]
        public void Check_ValueIsHigherThanMaxThreshold_ShouldTriggerAlarm()
        {
            // Arrange
            var alarm = new Alarm();
            
            // Act
            alarm.Check(Alarm.HighThreshold + 1);

            // Assert
            Assert.True(alarm.IsAlarmOn);
            Assert.Equal(1, alarm.AlarmCount);
        }

        [Fact]
        public void Reset_AfterAlarmHasBeenTriggered_ShouldBeUpdatedWithDefaultValues()
        {
            // Arrange
            var alarm = new Alarm();
            
            // Act
            alarm.Check(Alarm.HighThreshold + 1);
            alarm.Reset();

            // Assert
            Assert.False(alarm.IsAlarmOn);
            Assert.Equal(0, alarm.AlarmCount);
        }

        [Fact]
        public void Silent_AfterAlarmHasBeenTriggered_ShouldOnlySetAlarmStatusToOff()
        {
            // Arrange
            var alarm = new Alarm();
            
            // Act
            alarm.Check(Alarm.HighThreshold + 1);
            alarm.Silent();

            // Assert
            Assert.False(alarm.IsAlarmOn);
            Assert.Equal(1, alarm.AlarmCount);
        }
    }
}