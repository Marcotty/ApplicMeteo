namespace ApplicMeteo
{
    public class OpenMeteoService
    {
        private readonly HttpClient _httpClient;
       
        public OpenMeteoService(HttpClient httpClient)
        { 
            _httpClient = httpClient;
            
            var stationURL = "https://api.open-meteo.com/v1/forecast";

            _httpClient.BaseAddress = new Uri("https://api.open-meteo.com/v1/forecast");
        }

       /* public async Task<IEnumerable<GitHubBranch>?> GetAspNetCoreDocsBranchesAsync() =>
        await _httpClient.GetFromJsonAsync<IEnumerable<GitHubBranch>>(
            "repos/dotnet/AspNetCore.Docs/branches");
       */
       /* public async Task<IEnumerable<WeatherForecast>?> GetWeatherForecastsAsync =>
        await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>(
          "?latitude=52.52&longitude=13.41&hourly=temperature_2m,precipitation_probability,precipitation,rain&timezone=Europe%2FLondon&forecast_days=1");
        */
    }
}
