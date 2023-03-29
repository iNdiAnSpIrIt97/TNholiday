using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GovtHolidays
{
    public class GvmtHolidayWrapper
    {
        public string government_holidays_url { get; set; }
        
        public List<Holiday> government_holidays { get; set; }
    }

    public class Holiday
    {
        public string government_holidays_year { get; set; }
        public string date { get; set; }
        public string @event { get; set; }
    }

    public class GovernmentHolidayService
    {
        private readonly HttpClient _httpClient;

        public GovernmentHolidayService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IList<Holiday>> GetGovernmentHolidaysAsync()
        {
            var json = await _httpClient.GetStringAsync("http://ept.ajax.tech/tamilcalendar/revamp/upload/arasuvidumurainatkal/Holiday.json");
            var wrapper = JsonConvert.DeserializeObject<GvmtHolidayWrapper>(json);
            return wrapper.government_holidays;
        }
    }
}
