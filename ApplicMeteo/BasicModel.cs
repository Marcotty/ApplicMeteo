using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace ApplicMeteo
{
    public class BasicModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasicModel(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

        public WeatherForecast? WeatherForecasts { get; set; }

        public async Task OnGet()
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m,precipitation_probability,precipitation,rain&timezone=Europe%2FLondon&forecast_days=1")
            {
                Headers =
            {
                /*{ HeaderNames.Accept, "application/vnd.github.v3+json" },
                { HeaderNames.UserAgent, "HttpRequestsSample" }*/
            }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                WeatherForecasts = await JsonSerializer.DeserializeAsync
                    <WeatherForecast>(contentStream);
            }
        }
    }
}
