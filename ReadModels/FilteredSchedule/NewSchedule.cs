using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyLNU.ReadModels.FilteredSchedule
{
    internal class NewSchedule
    {
        public NewSchedule(FilteredSchedule schedule) {
            this.filteredSchedule = schedule;
        }

        [JsonProperty("Schedule")]
        public FilteredSchedule? filteredSchedule;
    }
}
