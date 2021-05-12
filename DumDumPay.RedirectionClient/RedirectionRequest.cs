using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BridgerPay.DumDumPay.RedirectionClient
{
	[DataContract]
	public class RedirectionRequest {
	
		[DataMember(Name = "TermUrl", EmitDefaultValue = false)]
		public string TermUrl { get; set; }
		
		[DataMember(Name = "PaReq", EmitDefaultValue = false)]
		public string PaReq { get; set; }
		
		[DataMember(Name = "MD", EmitDefaultValue = false)]
		public string MD { get; set; }
		//public string Url { get; set; }
		//public string Method { get; set; }
		
		[DataMember(Name = "__RequestVerificationToken", EmitDefaultValue = false)]
		public string Token { get; set; }
	}
}
