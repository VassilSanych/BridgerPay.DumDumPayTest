namespace BridgerPay.DumDumPay.ApiClient.Interfaces
{
	/// <summary>
	///  Api connection settings
	/// </summary>
	public class ApiSettings
	{
		public string MerchantId { get; set; }
		public string SecretKey { get; set; }
		public string ApiHost { get; set; }
	}
}
