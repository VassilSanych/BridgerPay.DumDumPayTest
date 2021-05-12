using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BridgerPay.DumDumPay.ApiClient.Interfaces.Contracts
{
	[DataContract]
	public class ConfirmPaymentApiRequest
	{
		[DataMember]
		[JsonProperty(Required = Required.Always)]
		public Guid? TransactionId { get; set; }
		
		[DataMember]
		[JsonProperty(Required = Required.Always)]
		public string PaRes { get; set; }
	}
}
