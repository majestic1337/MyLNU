using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using MyLNU.ReadModels;
using Newtonsoft.Json;
using System.Net.Http;
using MyLNU.ReadModels.DateClass;
using MyLNU.ReadModels.FilteredSchedule;

namespace MyLNU.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController: ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ScheduleController()
        {
            var serviceProvider = new ServiceCollection()
                .AddHttpClient()
                .BuildServiceProvider();
            _httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
        }


        [HttpGet]
        public async Task<IActionResult> GetSchedule([FromQuery] string group)
        {
            try
            {
                DateClass date = new DateClass(DateTime.Today, DateTime.Today);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                string groupName = System.Web.HttpUtility.UrlDecode(group);
                string encodedGroup = System.Web.HttpUtility.UrlEncode(group, System.Text.Encoding.GetEncoding("windows-1251"));

                var client = _httpClientFactory.CreateClient();
                HttpResponseMessage response = await client.GetAsync($"https://dekanat.lnu.edu.ua/cgi-bin/timetable_export.cgi?req_type=rozklad&req_mode=group&OBJ_ID=&OBJ_name={encodedGroup}&dep_name=&ros_text=separated&begin_date={date.startDate}&end_date={date.endDate}&req_format=json&coding_mode=UTF8&bs=ok");

                if (response.IsSuccessStatusCode)
                {
                    string responseText = await response.Content.ReadAsStringAsync();

                    var deserializeResponse = JsonConvert.DeserializeObject<ScheduleResponse>(responseText);

                    var schedule = deserializeResponse.scheduleList.Schedules;
                    var scheduleModifier = new FilteredSchedule();
                    scheduleModifier = scheduleModifier.SortByDate(schedule);

                    var newSchedule = new NewSchedule(scheduleModifier);

                    var completeSchedule = JsonConvert.SerializeObject(newSchedule);

                    return Ok(completeSchedule);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, new { ErrorMessage = "Failed to fetch timetable" });
                }
            }
            catch (HttpRequestException e)
            {
                return StatusCode(500, new { ErrorMessage = $"Request exception: {e.Message}" });
            }
        }
    }
}

