using System.Collections.Generic;

namespace BridgerPay.DumDumPay.Interfaces
{
	public class CreatePaymentResponse
	{
		public CreatePaymentResult Result { get; set; }
		public List<PaymentError> Errors { get; set; }
	}
    

}
