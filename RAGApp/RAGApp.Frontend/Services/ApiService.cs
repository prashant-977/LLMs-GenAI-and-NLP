namespace RAGApp.Frontend.Services
{
	public class ApiService
	{
	}
}


using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

public class ApiService
{
	private readonly HttpClient _httpClient;

	public ApiService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<string> GetInsightsAsync(string profession, string query, float topP)
	{
		var response = await _httpClient.PostAsJsonAsync("api/query", new { profession, query, topP });
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync();
	}
}
