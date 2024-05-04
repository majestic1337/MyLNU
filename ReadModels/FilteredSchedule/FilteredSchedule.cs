using Microsoft.AspNetCore.Components.Web;

namespace MyLNU.ReadModels.FilteredSchedule
{
    internal class FilteredSchedule
    {
        public FilteredSchedule()
        {

            this.Monday = new List<Schedule>();
            this.Tuesday = new List<Schedule>();
            this.Wednesday = new List<Schedule>();
            this.Thursday = new List<Schedule>();
            this.Friday = new List<Schedule>();

        }
        public List<Schedule> Monday;
        public List<Schedule> Tuesday;
        public List<Schedule> Wednesday;
        public List<Schedule> Thursday;
        public List<Schedule> Friday;
        public FilteredSchedule Filter(List<Schedule> schedules)
        {
            List<string> uniqueValues = schedules.Select(obj => obj.Date).Distinct().ToList();
            var filtered = new FilteredSchedule();

            foreach (var schedule in schedules)
            {

                if (schedule.Date == uniqueValues[0] && schedule.LessonDescription != "")
                {
                    filtered.Monday.Add(schedule);
                    continue;
                }
                if (schedule.Date == uniqueValues[1] && schedule.LessonDescription != "")
                {
                    filtered.Tuesday.Add(schedule);
                    continue;
                }
                if (schedule.Date == uniqueValues[2] && schedule.LessonDescription != "")
                {
                    filtered.Wednesday.Add(schedule);
                    continue;
                }
                if (schedule.Date == uniqueValues[3] && schedule.LessonDescription != "")
                {
                    filtered.Thursday.Add(schedule);
                    continue;
                }
                if (schedule.Date == uniqueValues[4] && schedule.LessonDescription != "")
                {
                    filtered.Friday.Add(schedule);
                    continue;
                }
            }
            return filtered;
        }
    }
}