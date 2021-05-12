using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BridgerPay.DumDumPay.ApiClient.Contracts;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace BridgerPay.DumDumPay.RedirectionClient
{
	public class Client : IRedirectionClient
	{
		private readonly ILogger<Client> _logger;
		
		public Client(ILogger<Client> logger)
		{
			_logger = logger;
		}


		public async Task<string> GetToken(
			CreatePaymentResult creationResult, 
			string url) 
		{
			var request = new RedirectionRequest
			{
				PaReq = creationResult.PaReq,
				MD = "testorder-1",
				TermUrl = creationResult.Url
			};

			var result = await SendAsync(
				JsonConvert.SerializeObject(request),
				creationResult.Method,
				"http://dumdumpay.site/secure/");

			return result;
		}
		
		
		public async Task<string> Redirect(
			CreatePaymentResult creationResult, 
			string url,
			string token) 
		{
			var request = new RedirectionRequest
			{
				PaReq = creationResult.PaReq,
				MD = "testorder-1",
				TermUrl = creationResult.Url,
				Token = token
			};

			var result = await SendAsync(
				JsonConvert.SerializeObject(request),
				creationResult.Method,
				"http://dumdumpay.site/secure/");

			return result;
		}


//		private async Task<string> SendAsync(
//			string requestJson,
//			string methodString,
//			string url) 
//		{
//			WebBrowser b = new WebBrowser();
			
			
//			HttpWebRequest request=(HttpWebRequest)WebRequest.Create(url);	
//			request.AllowAutoRedirect=true;
			
//			request.KeepAlive = false;
//			request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.2; CIBA)";
			
			
//			request.ContentType = "application/x-www-form-urlencoded"; ///"application/json"; 
//			request.Method = methodString;
//			byte[] byteArray = Encoding.UTF8.GetBytes(requestJson);
			
//			//get the request stream to write the post to
//			Stream requestStream = request.GetRequestStream();
////write the post to the request stream
//			requestStream.Write(byteArray, 0, byteArray.Length);
			

//			var myHttpWebResponse=(HttpWebResponse)request.GetResponse();

//			StreamReader loResponseStream =
//				new StreamReader(myHttpWebResponse.GetResponseStream(),Encoding.UTF8);

//			string lcHtml = loResponseStream.ReadToEnd();
//			return lcHtml;
//		}
		
		

		private async Task<string> SendAsync(
			string requestJson,
			string methodString,
			string url) 
		{ 
	HttpWebRequest request=(HttpWebRequest)WebRequest.Create(url);	
			request.AllowAutoRedirect=true;
			
			request.KeepAlive = true;
			request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.2; CIBA)";
			
			
			request.ContentType = "application/x-www-form-urlencoded"; ///"application/json"; 
			request.Method = "POST";
			byte[] byteArray = Encoding.UTF8.GetBytes(requestJson);
			
			//get the request stream to write the post to
			Stream requestStream = request.GetRequestStream();
//write the post to the request stream
			requestStream.Write(byteArray, 0, byteArray.Length);
			

			var myHttpWebResponse=(HttpWebResponse)request.GetResponse();

			StreamReader loResponseStream =
				new StreamReader(myHttpWebResponse.GetResponseStream(),Encoding.UTF8);

			string lcHtml = loResponseStream.ReadToEnd();
			return lcHtml;
		}



		private async Task<string> SendAsync1(
			string requestJson, 
			string methodString,
			string url)
		{
			var client = new HttpClient();

			var content = new StringContent(
				JsonConvert.SerializeObject(requestJson), 
				Encoding.UTF8, 
				"application/json");

			// serialize request object later
			_logger.LogInformation($"sending redirection request to {url}");

			var method = new HttpMethod(methodString);

			var message = new HttpRequestMessage
			{
				Method = method,
				Content = content,
				RequestUri = new Uri(url)
			};
			
			var response = await client.SendAsync(message);

			var responseBody = await response.Content.ReadAsStringAsync();

			if (response.IsSuccessStatusCode)
			{
				return responseBody;
			}

			throw new Exception($"Error calling 3DS: {responseBody}");
		}
		
	}
}
