using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BridgerPay.DumDumPay.ApiClient.Interfaces.Contracts
{
	[DataContract]
	public class CreatePaymentApiResponse
	{
		[DataMember]
		public CreatePaymentApiResult Result { get; set; }
		
		[DataMember]
		public ApiError[] Errors { get; set; }
	}
    

}
