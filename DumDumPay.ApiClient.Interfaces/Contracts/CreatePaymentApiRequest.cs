using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BridgerPay.DumDumPay.ApiClient.Interfaces.Contracts
{
	[DataContract]
	public class CreatePaymentApiRequest
	{
		[JsonProperty(Required = Required.Always)]
		public Guid? OrderId { get; set; }
		
		[JsonProperty(Required = Required.Always)]
		public int? Amount { get; set; }
		
		[JsonProperty(Required = Required.Always)]
		public string Currency { get; set; }
		
		[JsonProperty(Required = Required.Always)]
		public string Country { get; set; }
		
		[JsonProperty(Required = Required.Always)]
		public string CardNumber { get; set; }
		
		[JsonProperty(Required = Required.Always)]
		public string CardHolder { get; set; }
		
		[JsonProperty(Required = Required.Always)]
		public int? CardExpiryDate { get; set; }
		
		[JsonProperty(Required = Required.Always)]
		public int? Cvv { get; set; }
	}
}
