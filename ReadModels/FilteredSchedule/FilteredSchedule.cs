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
        public FilteredSchedule SortByDate(List<Schedule> schedules)
        {
            List<string> uniqueValues = schedules.Select(obj => obj.Date).Distinct().ToList();
            var filtered = new FilteredSchedule();

            foreach (var schedule in schedules) //Філтрує за датою 
            {

                if (schedule.Date == uniqueValues[0])
                {
                    filtered.Monday.Add(schedule);
                    continue;
                }
                if (schedule.Date == uniqueValues[1])
                {
                    filtered.Tuesday.Add(schedule);
                    continue;
                }
                if (schedule.Date == uniqueValues[2])
                {
                    filtered.Wednesday.Add(schedule);
                    continue;
                }
                if (schedule.Date == uniqueValues[3])
                {
                    filtered.Thursday.Add(schedule);
                    continue;
                }
                if (schedule.Date == uniqueValues[4])
                {
                    filtered.Friday.Add(schedule);
                    continue;
                }
            }
            bool ifMondayHasDuplicates = filtered.Monday
                .GroupBy(obj => obj.LessonNumber) // Групуємо об'єкти за значенням поля
                .Any(group => group.Count() > 1);
            bool ifTuesdayHasDuplicates = filtered.Tuesday
                .GroupBy(obj => obj.LessonNumber) // Групуємо об'єкти за значенням поля
                .Any(group => group.Count() > 1);
            bool ifWednesdayHasDuplicates = filtered.Wednesday
                .GroupBy(obj => obj.LessonNumber) // Групуємо об'єкти за значенням поля
                .Any(group => group.Count() > 1);
            bool ifThursdayHasDuplicates = filtered.Thursday
                .GroupBy(obj => obj.LessonNumber) // Групуємо об'єкти за значенням поля
                .Any(group => group.Count() > 1);
            bool ifFridayHasDuplicates = filtered.Friday
                .GroupBy(obj => obj.LessonNumber) // Групуємо об'єкти за значенням поля
                .Any(group => group.Count() > 1);

            if (ifMondayHasDuplicates)
            {
                filtered.Monday = Concatenate(filtered.Monday);
            }
            if (ifTuesdayHasDuplicates)
            {
                filtered.Tuesday = Concatenate(filtered.Tuesday);
            }
            if (ifWednesdayHasDuplicates)
            {
                filtered.Wednesday = Concatenate(filtered.Wednesday);
            }
            if (ifThursdayHasDuplicates)
            {
                filtered.Thursday = Concatenate(filtered.Thursday);
            }
            if (ifFridayHasDuplicates)
            {
                filtered.Friday = Concatenate(filtered.Friday);
            }

            return filtered;
        }
        public List<Schedule> Concatenate(List<Schedule> day) {

            List<string> repeatedMondayValues = day
                .GroupBy(obj => obj.LessonNumber) // Групуємо об'єкти за значенням поля
                .Where(group => group.Count() > 1) // Відбираємо тільки групи з більше ніж одним об'єктом
                .SelectMany(group => group.Select(obj => obj.LessonNumber)) // Об'єднуємо значення з кожної групи в один список
                .ToList();
            List<string> uniqueElements = repeatedMondayValues.Distinct().ToList();
            List<Schedule> concatenedSchedule = new List<Schedule>();
            List<Schedule> copy  = day.ToList();

            int index = 0;
            bool first = true;
            int startIndex = 0;

            foreach (var elem in day)
            {
                foreach (var lesson in uniqueElements)
                {
                    if (lesson == elem.LessonNumber)
                    {
                        concatenedSchedule.Add(elem);
                        if (first)
                        {
                            startIndex = index;
                            first = false;
                        }
                        copy.Remove(elem);
                    }
                }
                index++;
            }
        
            Schedule newLesson = new Schedule();
            newLesson = concatenedSchedule[0];
            foreach (var elem in concatenedSchedule)
            {
                newLesson.TeacherName += elem.TeacherName + " / ";
                newLesson.Room += elem.Room + " / ";
            }
        
            // Вставляємо елемент за новим індексом
            copy.Insert(startIndex, newLesson);
            return copy;
        }
    }

}
