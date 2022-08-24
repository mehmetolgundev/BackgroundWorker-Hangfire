using System;
using System.Data.SqlClient;
using Hangfire;

namespace BackgroundWorker_Hangfire
{
    class Program
    {
        static void Main(string[] args)
        {
    
            try
            {
                GlobalConfiguration.Configuration.UseSqlServerStorage(
                    "Data Source=localhost,1433;Initial Catalog=BackgroundWorker;User Id=sa;Password=Password123;");
                RecurringJob.AddOrUpdate("clock",()=>WriteTime(),Cron.Minutely);
               
                using (new BackgroundJobServer())
                {
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        

        }

        public static void WriteTime()
        {
            string d = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine(d);

        }
    }
}