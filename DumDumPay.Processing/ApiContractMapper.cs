using System.Collections.Generic;
using System.Linq;
using BridgerPay.DumDumPay.ApiClient.Interfaces.Contracts;
using BridgerPay.DumDumPay.Interfaces;

namespace BridgerPay.DumDumPay
{
	/// <summary>
	///  Api contracts to processing objects mapper
	/// </summary>
	public static class ApiContractMapper
	{
		public static CreatePaymentApiRequest ToApiRequest(
			this CreatePaymentRequest processingRequest)
		{
			return new CreatePaymentApiRequest
			{
				Amount = processingRequest.Amount,
				Country = processingRequest.Country,
				Currency = processingRequest.Currency,
				CardHolder = processingRequest.CardHolder,
				Cvv = processingRequest.Cvv,
				CardNumber = processingRequest.CardNumber,
				CardExpiryDate = processingRequest.CardExpiryDate,
				OrderId = processingRequest.OrderId
			};
		}

		public static ConfirmPaymentApiRequest ToApiRequest(
			this ConfirmPaymentRequest processingRequest)
		{
			return new ConfirmPaymentApiRequest
			{
				PaRes = processingRequest.PaRes,
				TransactionId = processingRequest.TransactionId
			};
		}

		public static PaymentError ToProcessing(this ApiError apiError)
		{
			return new PaymentError
			{
				Message = apiError.Message,
				ErrorType = apiError.ErrorType
			};
		}
		
		public static List<PaymentError>  ToProcessing(this ApiError[] apiErrors)
		{
			return apiErrors
				.Select(error => error?.ToProcessing())
				.ToList();
		}


		public static CreatePaymentResponse ToProcessing(
			this CreatePaymentApiResponse apiResponse) 
		{
			return new CreatePaymentResponse
			{
				Result = apiResponse.Result?.ToProcessing(),
				Errors = apiResponse.Errors?.ToProcessing()
				
			};
		}

		public static CreatePaymentResult ToProcessing(this CreatePaymentApiResult apiResult)
		{
			return new CreatePaymentResult
			{
				Method = apiResult.Method,
				TransactionId = apiResult.TransactionId,
				Url = apiResult.Url,
				PaReq = apiResult.PaReq,
				TransactionStatus = apiResult.TransactionStatus
			};
		}
		
		
		public static ConfirmPaymentResponse ToProcessing(
			this ConfirmPaymentApiResponse apiResponse) 
		{
			return new ConfirmPaymentResponse
			{
				Result = apiResponse.Result?.ToProcessing(),
				Errors = apiResponse.Errors?.ToProcessing()
				
			};
		}
		

		public static ConfirmPaymentResult ToProcessing(
			this ConfirmPaymentApiResult apiResult)
		{
			return new ConfirmPaymentResult
			{
				Amount = apiResult.Amount,
				Currency = apiResult.Currency,
				Status = apiResult.Status,
				OrderId = apiResult.OrderId,
				TransactionId = apiResult.TransactionId,
				LastFourDigits = apiResult.LastFourDigits
			};
		}
	}
}
