using System;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System.IO;

namespace YahooFinance
{
	public class sendText
	{
		public string sendSMS()
		{
			String result;
			string apiKey = "oxR2LNpi4p0-wjUDKTIuSY8ilnilfGyVAVJ99cxImB";
			string numbers = ""; // in a comma seperated list
			string message = "All money is gone.  You suck at investing.";
			string sender = "StockBot";

			String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + sender;
			//refer to parameters to complete correct url string

			StreamWriter myWriter = null;
			HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

			objRequest.Method = "POST";
			objRequest.ContentLength = System.Text.Encoding.UTF8.GetByteCount(url);
			objRequest.ContentType = "application/x-www-form-urlencoded";
			try
			{
				myWriter = new StreamWriter(objRequest.GetRequestStream());
				myWriter.Write(url);
			}
			catch (Exception e)
			{
				return e.Message;
			}
			finally
			{
				myWriter.Close();
			}

			HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
			using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
			{
				result = sr.ReadToEnd();
				// Close and clean up the StreamReader
				sr.Close();
			}
			return result;
		}
	}
}
