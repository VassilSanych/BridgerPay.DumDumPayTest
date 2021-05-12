using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BridgerPay.DumDumPay.ApiClient.Interfaces.Contracts
{
	[DataContract]
	public class ApiError
	{
		[DataMember]
		[JsonProperty("type")]
		public string ErrorType { get; set; }
		
		[DataMember]
		public string Message { get; set; }
	}
}
