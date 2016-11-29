namespace DailyVitaminsIntake
{
    class Program 
    {
        static void Main(string[] args)
        {            
            using(AppProcessing ap = new AppProcessing())
            {
                ap.ProccessApp();
            }
        }
    }
}
