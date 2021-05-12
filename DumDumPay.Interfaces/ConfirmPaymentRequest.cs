using System;

namespace BridgerPay.DumDumPay.Interfaces
{
	public class ConfirmPaymentRequest
	{
		public Guid? TransactionId { get; set; }
		public string PaRes { get; set; }
	}
}
