using System;

namespace DumDumPayClient.Example.Models
{
    public class PaymentConfirmedModel
    {
        public Guid TransactionId { get; set; }
        public string Status { get; set; }
    }
}