using Newtonsoft.Json;

namespace MyLNY.ReadModels
{
    internal class Schedule
    {
        public Schedule() { }
        [JsonProperty("object")]
        public string? Name { get; set; }
        [JsonProperty("date")]
        public string? Date { get; set; }
        [JsonProperty("comment")]
        public string? Comment { get; set; }
        [JsonProperty("lesson_number")]
        public string? LessonNumber { get; set; }
        [JsonProperty("lesson_name")]
        public string? LessonName { get; set; }
        [JsonProperty("lesson_time")]
        public string? LessonTime { get; set; }
        [JsonProperty("half")]
        public string? Half { get; set; }
        [JsonProperty("teacher")]
        public string? TeacherName { get; set; }
        [JsonProperty("teachers_add")]
        public string? TeachersAdd { get; set; }
        [JsonProperty("room")]
        public string? Room { get; set; }
        [JsonProperty("group")]
        public string? Group { get; set; }
        [JsonProperty("title")]
        public string? SubjectName { get; set; }
        [JsonProperty("type")]
        public string? Type { get; set; }
        [JsonProperty("replacement")]
        public string? Replacement { get; set; }
        [JsonProperty("reservation")]
        public string? Reservation { get; set; }
        [JsonProperty("online")]
        public string? Online { get; set; }
        [JsonProperty("comment4link")]
        public string? Comment4link { get; set; }
        [JsonProperty("link")]
        public string? Link { get; set; }
    }
}
