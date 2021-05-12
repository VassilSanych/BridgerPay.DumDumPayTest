using System.Runtime.Serialization;

namespace BridgerPay.DumDumPay.Interfaces
{
	public class PaymentError
	{
		public string ErrorType { get; set; }
		
		public string Message { get; set; }
	}
}
