using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BridgerPay.DumDumPay.ApiClient.Interfaces.Contracts
{
	[DataContract]
	public class ConfirmPaymentApiResult
	{
		[DataMember(Name = "TransactionId", EmitDefaultValue = false)]
		public Guid TransactionId { get; set; }
		
		[DataMember(Name = "Status", EmitDefaultValue = false)]
		public string Status { get; set; }
		
		[DataMember(Name = "Amount", EmitDefaultValue = false)]
		public int Amount { get; set; }
		
		[DataMember(Name = "Currency", EmitDefaultValue = false)]
		public string Currency { get; set; }
		
		[DataMember(Name = "OrderId", EmitDefaultValue = false)]
		public Guid OrderId { get; set; }
		
		[DataMember(Name = "LastFourDigits", EmitDefaultValue = false)]
		public int LastFourDigits { get; set; }
	}
}
