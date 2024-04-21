using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using MyLNY.ReadModels;
using Newtonsoft.Json;
using System.Net.Http;
using MyLNY.ReadModels.DateClass;

namespace MyLNY.Controllers
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
        public async Task<IActionResult> GetSchedule()
        {
            try
            {
                DateClass date = new DateClass(DateTime.Today, DateTime.Today);

                var client = _httpClientFactory.CreateClient();
                HttpResponseMessage response = await client.GetAsync($"https://dekanat.lnu.edu.ua/cgi-bin/timetable_export.cgi?req_type=rozklad&req_mode=group&OBJ_ID=&OBJ_name=%CF%CC%C0-22%F1&dep_name=&ros_text=separated&begin_date={date.startDate}&end_date={date.endDate}&req_format=json&coding_mode=UTF8&bs=ok");

                if (response.IsSuccessStatusCode)
                {
                    string responseText = await response.Content.ReadAsStringAsync();

                    var deserializeResponse = JsonConvert.DeserializeObject<ScheduleResponse>(responseText);

                    return Ok(deserializeResponse);
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

