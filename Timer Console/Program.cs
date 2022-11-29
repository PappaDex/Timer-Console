using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
namespace Timer_Console
{
    class Program
    {
        public static void Main()
        {
            ScheduleService();
            Console.ReadKey();
        }
        public static void ScheduleService()
        {
            // Objekt klase Timer
            Timer Schedular = new Timer(new TimerCallback(SchedularCallback));

            // Postavljanje vremena 'po defaultu'
            DateTime scheduledTime = DateTime.MinValue;

            int intervalMinutes = 1;
            // Postavljanje vremena zapisa u trenutno vrijeme + 1 minuta
            scheduledTime = DateTime.Now.AddMinutes(intervalMinutes);
            if (DateTime.Now > scheduledTime)
            {
                scheduledTime = scheduledTime.AddMinutes(intervalMinutes);
            }
            // Vremenski interval
            TimeSpan timeSpan = scheduledTime.Subtract(DateTime.Now);
            string schedule = string.Format("{0} day(s) {1} hour(s) {2} minute(s) {3}seconds(s)", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
    
            WriteToFile("Simple Service scheduled to run after: " + schedule + " {0}");
            //Razlika između trenutnog vremena i planiranog vremena
            int dueTime = Convert.ToInt32(timeSpan.TotalMilliseconds);
            // Promjena vremena izvršavanja metode povratnog poziva.
            Schedular.Change(dueTime, Timeout.Infinite);
        }
        private static void SchedularCallback(object e)
        {
            WriteToFile("Simple Service Log: {0}");
            ScheduleService();
        }
        private static void WriteToFile(string text)
        {
            string path = "C:\\Users\\astudent\\Desktop\\ServiceLog.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(string.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh: mm:ss tt")));
    
                writer.Close();
            }
        }
    }
}
