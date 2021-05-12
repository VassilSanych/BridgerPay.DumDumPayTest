using System;
using BridgerPay.DumDumPay;
using BridgerPay.DumDumPay.ApiClient;
using BridgerPay.DumDumPay.ApiClient.Interfaces;
using BridgerPay.DumDumPay.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DumDumPay.IntegrationTests
{
	[TestClass]
	public class ProcessingTests
	{
		private static ServiceProvider ServiceProvider { get; set; }

		// ReSharper disable once UnusedAutoPropertyAccessor.Global
		public TestContext TestContext { get; set; }

		[ClassInitialize]
		public static void SetUp(TestContext testContext)
		{
			BuildSampleContainer();
		}
		
		[ClassCleanup]
		public static void CleanUp()
		{
			ServiceProvider.Dispose();
			ServiceProvider = null;
		}

		private static void BuildSampleContainer()
		{
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddTransient<IProcessing, Processing>();
			serviceCollection.AddTransient<IApiClient, Client>();
			serviceCollection.AddTransient<IConnection, Connection>();
			serviceCollection.AddSingleton<ILogger<Client>, NullLogger<Client>>();
			
			
			serviceCollection.AddTransient<IOptions<ApiSettings>>(
				provider => Options.Create<ApiSettings>(new ApiSettings
				{
					ApiHost = "https://dumdumpay.site",
					MerchantId = "6fc3aa31-7afd-4df1-825f-192e60950ca1",
					SecretKey = "53cr3t"
				}));
			
			ServiceProvider = serviceCollection.BuildServiceProvider();
		}
		
		
		[TestMethod]
		public void CreatePaymentTest()
		{
			var appService = ServiceProvider.GetService<IProcessing>();
			Assert.IsNotNull(appService);

			var crRequest = new CreatePaymentRequest()
			{
				OrderId = new Guid(),
				Amount = 12312,
				Country = "CY",
				Currency = "USD",
				Cvv = 111,
				CardExpiryDate = 1123,
				CardNumber = "4111111111111111",
				CardHolder = "TEST TESTER"
			};
			var crResponse = appService.CreatePaymentAsync(crRequest).Result;
			Assert.IsNotNull(crResponse, "Response is null");
			//Console.WriteLine(JsonConvert.SerializeObject(crResponse));
			Assert.IsNull(crResponse.Errors, "Response.Errors is not null");
			Assert.IsNotNull(crResponse.Result, "Response.Result != null");
			Assert.IsTrue(crResponse.Result.TransactionStatus.Equals("init", StringComparison.OrdinalIgnoreCase), "TransactionStatus is not 'Init'");
		}
	}
}
