using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace DailyVitaminsIntake
{     
    class AppProcessing : IDisposable
        {
        #region Public Variables
        public TaskService taskService;
        private static string title = "Weź dzisiejszą porcję kreatyny";
        private static string content = "Czy wziąłeś już dzisiaj swoją porcję kreatyny?";
        private static string text = "Przypomnienie nt. witaminek :)))";
        public DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 00, 00);
            NotifyIcon ico = new NotifyIcon()
            {
                BalloonTipIcon = ToolTipIcon.Info,
                BalloonTipTitle = title,
                BalloonTipText = content,
                Text = text,
                Icon = System.Drawing.SystemIcons.Question,
                Visible = true,
            };
        #endregion
        public void ProccessApp()
            {
                using (taskService = new TaskService())
                {
                    taskService.Execute(@"C:\Users\Kuba\Desktop\Projekty\DailyVitaminsIntake\DailyVitaminsIntake\bin\Debug\DailyVitaminsIntake.exe").Once().Starting(dt).RepeatingEvery(TimeSpan.FromDays(1)).AsTask("DailyVitaminsIntakeTask");
                }

            ico.ShowBalloonTip(10000);

            //Uncomment if you want "debug" seconds-perfect time
            /*  
                for (;;)
                {
                    Console.WriteLine(DateTime.Now.Hour + " " + DateTime.Now.Minute + " " + DateTime.Now.Second);
                    Thread.Sleep(1000);
                }
                */
            }

            void IDisposable.Dispose()
            {
                taskService.Dispose();        
            }
    }
}
