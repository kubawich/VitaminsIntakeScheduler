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
            public DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 00, 00);
            NotifyIcon ico = new NotifyIcon()
            {
                BalloonTipIcon = ToolTipIcon.Info,
                BalloonTipTitle = "Weź dzisiejszą porcję kreatyny",
                BalloonTipText = "Czy wziąłeś już dzisiaj swoją porcję kreatyny?",
                Text = "Przypomnienie nt. witaminek :)))",
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
