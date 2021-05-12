using System.Threading.Tasks;

namespace BridgerPay.DumDumPay.ApiClient.Interfaces
{
	public interface IConnection
	{
		Task<string> PostAsync(
			string requestBody, 
			string url);
	}
}