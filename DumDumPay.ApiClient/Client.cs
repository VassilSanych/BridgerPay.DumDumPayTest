using System.Threading.Tasks;
using BridgerPay.DumDumPay.ApiClient.Interfaces;
using BridgerPay.DumDumPay.ApiClient.Interfaces.Contracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BridgerPay.DumDumPay.ApiClient
{
	public class Client : IApiClient
	{
        private readonly ILogger<Client> _logger;
		private readonly ApiSettings _settings;
        private readonly IConnection _connection;

        public Client(
			ILogger<Client> logger, 
			IOptions<ApiSettings> settings, 
			IConnection connection)
        {
            _logger = logger;
			_connection = connection;
			_settings = settings.Value;
        }

        public async Task<CreatePaymentApiResponse> CreatePaymentAsync(
			CreatePaymentApiRequest apiRequest)
        {
			var requestBody = JsonConvert.SerializeObject(apiRequest);
			
            var response =
                await _connection.PostAsync(
					requestBody,
                    $"{_settings.ApiHost}/api/payment/create");

			var result = JsonConvert.DeserializeObject<CreatePaymentApiResponse>(response);

            return result;
        }

        public async Task<ConfirmPaymentApiResponse> ConfirmPaymentAsync(
            ConfirmPaymentApiRequest apiRequest)
        {
			var requestBody = JsonConvert.SerializeObject(apiRequest);
			
            var response =
                await _connection.PostAsync(
					requestBody,
                    $"{_settings.ApiHost}/api/payment/confirm");
			
			var result = JsonConvert.DeserializeObject<ConfirmPaymentApiResponse>(response);

            return result;
        }

 
    }
}
