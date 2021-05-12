using System.Threading.Tasks;
using BridgerPay.DumDumPay.ApiClient.Contracts;

namespace BridgerPay.DumDumPay.RedirectionClient
{
	public interface IRedirectionClient
	{
		Task<string> Redirect(
			CreatePaymentResult creationResult, 
			string url,
			string token);

		Task<string> GetToken(
			CreatePaymentResult creationResult,
			string url);
	}
}