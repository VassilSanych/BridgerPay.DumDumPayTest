using System;
using System.Linq;
using System.Threading.Tasks;
using BridgerPay.DumDumPay.Interfaces;
using DumDumPayClient.Example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DumDumPayClient.Example.Controllers
{
	/// <summary>
	///  Example workflow controller
	/// </summary>
    public class PaymentController : Controller
    {
        private readonly IProcessing _paymentClient;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(
			IProcessing paymentClient, 
			ILogger<PaymentController> logger)
        {
            _paymentClient = paymentClient;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var request = new CreatePaymentModel
            {
                Amount = 123,
                Country = "CYP",
                Currency = "USD",
                Cvv = 123,
                CardExpiryDate = 1123,
                CardNumber = "4111111111111111",
                CardHolder = "TEST TESTER"
            };
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreatePaymentModel request)
        {
            var paymentRequest = new CreatePaymentRequest
            {
                OrderId = Guid.NewGuid(),
                Amount = request.Amount,
                Country = request.Country,
                Currency = request.Currency,
                CardHolder = request.CardHolder,
                CardNumber = request.CardNumber,
                CardExpiryDate = request.CardExpiryDate,
                Cvv = request.Cvv
            };

            try
            {
                var response = await _paymentClient.CreatePaymentAsync(paymentRequest)
					.ConfigureAwait(false);

				if (response.Errors != null) { 
					ViewBag.Error = "CreatePayment errors" + string.Join(", ", response.Errors.Select(JsonConvert.SerializeObject));

					return View(request);
				}
				
				if (response.Result == null) { 
					ViewBag.Error = "CreatePayment result is empty";

					return View(request);
				}
				

				var termUrl = Url.Action(
					"Confirm", 
					"Payment", 
					new { transactionId = response.Result.TransactionId }, HttpContext.Request.Scheme);
				
                var paymentRedirectModel = new PaymentRedirectModel
                {
                    PaReq = response.Result.PaReq,
                    TermUrl = termUrl,
                    MD = "Order-1",
                    Method = response.Result.Method,
                    Url = "https://dumdumpay.site/secure"
                };

                return View("PaymentRedirect", paymentRedirectModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error happened while calling Payment Api");
				
                ViewBag.Error = e.Message;

                return View(request);
            }
        }

        [HttpGet("payment/confirm/{transactionId}")]
        public async Task<IActionResult> Confirm(Guid transactionId, string md, string paRes)
        {
            var confirmPaymentRequest = new ConfirmPaymentRequest
            {
                PaRes = paRes,
                TransactionId = transactionId
            };

            try
            {
                var response = await _paymentClient.ConfirmPaymentAsync(confirmPaymentRequest);
				
				if (response.Errors != null) { 
					ViewBag.Error = "ConfirmPayment errors" + string.Join(", ", response.Errors.Select(JsonConvert.SerializeObject));

					return View(new PaymentConfirmedModel());
				}
				
				
				if (response.Result == null) { 
					ViewBag.Error = "ConfirmPayment result is empty";

					return View(new PaymentConfirmedModel());
				}

                var model = new PaymentConfirmedModel
                {
                    Status = response.Result.Status,
                    TransactionId = response.Result.TransactionId
                };
                return View(model);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error happened while calling Payment Api");
                
                ViewBag.Error = e.Message;

                return View(new PaymentConfirmedModel());
            }
        }
    }
}