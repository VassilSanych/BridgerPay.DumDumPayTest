using System;

namespace DumDumPayClient.Example.Models
{
    public class ConfirmModel
    {
        public Guid TransactionId { get; set; }
        public string Status { get; set; }
    }
}