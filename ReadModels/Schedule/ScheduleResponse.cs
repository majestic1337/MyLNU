using Newtonsoft.Json;

namespace MyLNU.ReadModels
{
    internal class ScheduleResponse
    {
        public ScheduleResponse(ScheduleList scheduleList)
        {
            this.scheduleList = scheduleList;
        }
        [JsonProperty("psrozklad_export")]
        public ScheduleList scheduleList { get; set; }

        
    }
}

