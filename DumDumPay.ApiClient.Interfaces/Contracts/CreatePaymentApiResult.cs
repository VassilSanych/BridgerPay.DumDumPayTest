using System;
using System.Runtime.Serialization;

namespace BridgerPay.DumDumPay.ApiClient.Interfaces.Contracts
{
	[DataContract]
	public class CreatePaymentApiResult
	{
		[DataMember]
		public Guid TransactionId { get; set; }
		
		[DataMember]
		public string TransactionStatus { get; set; }
		
		[DataMember]
		public string PaReq { get; set; }
		
		[DataMember]
		public string Url { get; set; }
		
		[DataMember]
		public string Method { get; set; }
	}
}
