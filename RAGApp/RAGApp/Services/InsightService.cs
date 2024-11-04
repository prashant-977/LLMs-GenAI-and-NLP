using OpenAI_API;

namespace RAGApp.Services
{
	public class InsightService
	{
		//private readonly OpenAIAPI _openAiApi;
		private readonly string _apiKey;

		public InsightService(IConfiguration config)
		{
			_apiKey = config["OpenAI:ApiKey"];
		}

		public async Task<string> GetInsightsAsync(string profession, string query, float topP)
		{
			var completionRequest = new CompletionRequest
			{
				Prompt = $"{profession} insights: {query}",
				MaxTokens = 150,
				TopP = topP
			};

			var result = await _apiKey.Completions.CreateCompletionAsync(completionRequest);
			return result.ToString();
		}
	}
}




