using System;
using System.Collections.Generic;

namespace BridgerPay.DumDumPay.Interfaces
{
	public class ConfirmPaymentResponse
	{
		public ConfirmPaymentResult Result { get; set; }
		public List<PaymentError> Errors { get; set; }
	}

	public class ConfirmPaymentResult
	{
		public Guid TransactionId { get; set; }
		public string Status { get; set; }
		public int Amount { get; set; }
		public string Currency { get; set; }
		public Guid OrderId { get; set; }
		public int LastFourDigits { get; set; }
	}
}
