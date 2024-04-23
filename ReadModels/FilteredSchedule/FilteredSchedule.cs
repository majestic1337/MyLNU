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
        public List<Schedule> Concatenate(List<Schedule> day)
        {
            List<string> repeatedLessonNumbers = day
                .GroupBy(obj => obj.LessonNumber)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key)
                .ToList();

            if (repeatedLessonNumbers.Count > 1) // Якщо є дубльовані предмети з різними викладачами
            {
                foreach (var lessonNumber in repeatedLessonNumbers)
                {
                    var lessons = day.Where(lesson => lesson.LessonNumber == lessonNumber).ToList();

                    string combinedTeachers = string.Join(" / ", lessons.Select(lesson => lesson.TeacherName).Distinct());
                    string combinedRooms = string.Join(" / ", lessons.Select(lesson => lesson.Room).Distinct());

                    foreach (var lesson in lessons)
                    {
                        lesson.TeacherName = combinedTeachers;
                        lesson.Room = combinedRooms;
                    }
                }

                // Після об'єднання даних, видаліть дубльовані записи, залишивши лише один з них
                day = day.GroupBy(obj => new { obj.Date, obj.LessonNumber }).Select(group => group.First()).ToList();
            }
            else if (repeatedLessonNumbers.Count == 1)
            {
                var lessonNumber = repeatedLessonNumbers[0];
                var lessons = day.Where(lesson => lesson.LessonNumber == lessonNumber).ToList();

                var combinedLesson = lessons[0];

                string combinedTeachers = string.Join(" / ", lessons.Select(lesson => lesson.TeacherName).Distinct());
                string combinedRooms = string.Join(" / ", lessons.Select(lesson => lesson.Room).Distinct());

                int startIndex = day.IndexOf(lessons.First());

                // Видаляємо всі елементи списку lessons зі списку day
                foreach (var lesson in lessons)
                {
                    day.Remove(lesson);
                }

                // Створюємо новий об'єкт з об'єднаними даними
                combinedLesson.TeacherName = combinedTeachers;
                combinedLesson.Room = combinedRooms;

                // Вставляємо об'єднаний об'єкт на місце видалених елементів
                day.Insert(startIndex, combinedLesson);
            }

            return day;
        }
    }
}
