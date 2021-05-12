using System;
using System.Collections.Generic;
using System.Text;

namespace BridgerPay.DumDumPay.RedirectionClient
{
	public class RedirectionResponse
	{
		public Guid TransactionId { get; set; }
		public string PaRes { get; set; }
	}
}
