using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BridgerPay.DumDumPay.ApiClient.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BridgerPay.DumDumPay.ApiClient
{
	public class Connection : IConnection
	{
		private readonly ILogger<Client> _logger;
		private readonly ApiSettings _settings;

		
		public Connection(ILogger<Client> logger, IOptions<ApiSettings> settings)
		{
			_logger = logger;
			_settings = settings.Value;
		}
		
		
		public async Task<string> PostAsync(
			string requestBody, 
			string url)
		{
			var client = new HttpClient();

			var content = CreateContent(requestBody);

			_logger.LogInformation($"POSTing request to {url}");
            
			var response = await client.PostAsync(url, content);

			var responseBody = await response.Content.ReadAsStringAsync();

			if (response.IsSuccessStatusCode)
				return responseBody;

			throw new Exception($"Error calling Payment Api: {response.StatusCode} {response.ReasonPhrase}");
		}

		private StringContent CreateContent(string requestBody)
		{
			var stringContent = new StringContent(
				requestBody, 
				Encoding.UTF8, 
				"application/json");

			stringContent.Headers.Add("Mechant-Id", _settings.MerchantId);
			stringContent.Headers.Add("Secret-Key", _settings.SecretKey);

			return stringContent;
		}
	}
}
