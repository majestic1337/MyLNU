using System;
using Newtonsoft.Json;


namespace MyLNU.ReadModels
{
    internal class ScheduleList
    {
        public ScheduleList(List<Schedule> schedules, string code)
        {
            this.Schedules = schedules;
            this.Code = code;
        }
        [JsonProperty("roz_items")]
        public List<Schedule>? Schedules { get; set; }

        [JsonProperty("code")]
        public string? Code { get; set; }
    }
}
