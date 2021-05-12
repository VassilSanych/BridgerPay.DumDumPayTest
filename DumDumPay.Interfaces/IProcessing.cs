using System.Threading.Tasks;

namespace BridgerPay.DumDumPay.Interfaces
{
	public interface IProcessing
	{
		Task<CreatePaymentResponse> CreatePaymentAsync(CreatePaymentRequest request);

		Task<ConfirmPaymentResponse> ConfirmPaymentAsync(
			ConfirmPaymentRequest request);
	}
}