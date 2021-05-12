namespace DumDumPayClient.Example.Models
{
    public class CreatePaymentModel
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public int CardExpiryDate { get; set; }
        public int Cvv { get; set; }
    }
}