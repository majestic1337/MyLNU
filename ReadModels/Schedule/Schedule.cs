using Newtonsoft.Json;

namespace MyLNU.ReadModels
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

        [JsonProperty("lesson_description")]
        public string LessonDescription { get; set; }
    }
}