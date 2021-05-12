using System.Threading.Tasks;
using BridgerPay.DumDumPay.ApiClient.Interfaces.Contracts;

namespace BridgerPay.DumDumPay.ApiClient.Interfaces
{
	public interface IApiClient
	{
		Task<CreatePaymentApiResponse> CreatePaymentAsync(
			CreatePaymentApiRequest apiRequest);

		Task<ConfirmPaymentApiResponse> ConfirmPaymentAsync(
			ConfirmPaymentApiRequest apiRequest);
	}
}
