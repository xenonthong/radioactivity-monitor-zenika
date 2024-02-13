using RadioactivityMonitor.Domains;
using RadioactivityMonitor.Services;

Console.WriteLine("Initialising...");

var service = new RadioactivityMonitorService(new Alarm(), new Sensor());

Console.WriteLine("1st call...");
service.Monitor();

Console.WriteLine("2nd call...");
service.Monitor();

Console.WriteLine("3rd call...");
service.Monitor();