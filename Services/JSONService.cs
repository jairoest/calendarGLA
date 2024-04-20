using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalendarAE.Services
{
    public class JsonFetcher
    {
        private const string JsonUrl = "https://username.github.io/repository/jsonfile.json"; // Reemplaza con tu URL real

        public async Task<string> FetchJsonAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(JsonUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        return jsonContent; // Aquí puedes procesar los datos JSON según tus necesidades
                    }
                    else
                    {
                        return $"Error: {response.StatusCode}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
