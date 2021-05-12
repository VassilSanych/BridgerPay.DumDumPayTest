using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BridgerPay.DumDumPay.ApiClient;
using BridgerPay.DumDumPay.ApiClient.Interfaces;
using BridgerPay.DumDumPay.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BridgerPay.DumDumPay
{
	public class Processing : IProcessing
	{
		private readonly ILogger<Client> _logger;
		private readonly IApiClient _apiClient;

		public Processing(
			ILogger<Client> logger,
			IApiClient apiClient)
		{
			_logger = logger;
			_apiClient = apiClient;
		}



		public async Task<CreatePaymentResponse> CreatePaymentAsync(CreatePaymentRequest request)
		{
			CreatePaymentResponse result = null;
			try
			{
				_logger.LogTrace($"going to process CreatePayment OrderId={request.OrderId}");

				var apiRequest = request.ToApiRequest();
				var apiResponse = await _apiClient.CreatePaymentAsync(apiRequest)
					.ConfigureAwait(false);
				result = apiResponse.ToProcessing();
				
				if (result.Errors == null)
					_logger.LogInformation($"CreatePayment OrderId={request.OrderId} successfully processed");
				else
					_logger.LogWarning(
						$"CreatePayment OrderId={request.OrderId} processed with errors {string.Join(", ", result.Errors.Select(JsonConvert.SerializeObject))}");
			}
			catch (Exception e)
			{
				var errorType = "CreatePayment processing error";
				_logger.LogError(e, errorType);

				var error = new PaymentError
				{
					ErrorType = errorType,
					Message = e.Message
				};

				((result ??= new CreatePaymentResponse())
						.Errors ??= new List<PaymentError>())
					.Add(error);
			}

			return result;
		}

		
		public async Task<ConfirmPaymentResponse> ConfirmPaymentAsync(
			ConfirmPaymentRequest request) 
		{ 
		
			ConfirmPaymentResponse result = null;
			try
			{
				_logger.LogTrace($"going to process ConfirmPayment TransactionId={request.TransactionId}");
				
				var apiRequest = request.ToApiRequest();
				var apiResponse = await _apiClient.ConfirmPaymentAsync(apiRequest)
					.ConfigureAwait(false);
				result = apiResponse.ToProcessing();
				
				if (result.Errors == null)
					_logger.LogInformation($"ConfirmPayment TransactionId={request.TransactionId} successfully processed");
				else
					_logger.LogWarning(
						$"ConfirmPayment TransactionId={request.TransactionId} processed with errors {string.Join(", ", result.Errors.Select(JsonConvert.SerializeObject))}");
			}
			catch (Exception e)
			{
				var errorType = "ConfirmPayment processing error";
				_logger.LogError(e, errorType);

				var error = new PaymentError
				{
					ErrorType = errorType,
					Message = e.Message
				};

				((result ??= new ConfirmPaymentResponse())
						.Errors ??= new List<PaymentError>())
					.Add(error);
			}

			return result;
		}
	}
}
