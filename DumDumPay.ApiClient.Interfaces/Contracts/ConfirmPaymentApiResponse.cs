using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BridgerPay.DumDumPay.ApiClient.Interfaces.Contracts
{
	[DataContract]
	public class ConfirmPaymentApiResponse
	{
		[DataMember(Name = "result", EmitDefaultValue = false)]
		public ConfirmPaymentApiResult Result { get; set; }
		
		[DataMember(Name = "errors", EmitDefaultValue = false)]
		public ApiError[] Errors { get; set; }
	}
    

}
