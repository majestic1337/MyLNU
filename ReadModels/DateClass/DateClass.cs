using System.Security.Cryptography.X509Certificates;
using System;

namespace MyLNY.ReadModels.DateClass
{
    public class DateClass
    {
        public DateClass(DateTime startDate, DateTime endDate)
        {
           
            switch (DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    startDate = DateTime.Today;
                    endDate = DateTime.Today.AddDays(4);
                    break;
                case DayOfWeek.Tuesday:
                    startDate = DateTime.Today.AddDays(-1);
                    endDate = DateTime.Today.AddDays(3);
                    break;
                case DayOfWeek.Wednesday:
                    startDate = DateTime.Today.AddDays(-2);
                    endDate = DateTime.Today.AddDays(2);
                    break;
                case DayOfWeek.Thursday:
                    startDate = DateTime.Today.AddDays(-3);
                    endDate = DateTime.Today.AddDays(1);
                    break;
                case DayOfWeek.Friday:
                    startDate = DateTime.Today.AddDays(-4);
                    endDate = DateTime.Today;
                    break;
                case DayOfWeek.Saturday:
                    startDate = DateTime.Today.AddDays(2);
                    endDate = DateTime.Today.AddDays(6);
                    break;
                case DayOfWeek.Sunday:
                    startDate = DateTime.Today.AddDays(1);
                    endDate = DateTime.Today.AddDays(5);
                    break;
            }
            this.startDate = startDate.ToString("dd.MM.yyyy");
            this.endDate = endDate.ToString("dd.MM.yyyy");
        }

        public string startDate {  get; set; }
        public string endDate {  get; set; }
    }
}
