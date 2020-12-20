using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Parking.Models
{
    public class GetDataAPI
    {
        public string getDataOtherAPI(string url)
        {

            string webData = null;
            string urlAddress = url;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;
            HttpWebRequest request;
            HttpWebResponse response;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(urlAddress);
                request.Method = "GET";
                //request.Headers.Add Authorization", "Bearer " + accessToken
                response = (HttpWebResponse)request.GetResponse();
            }

            catch (Exception ex)
            {
                //this could be modified for specific responses if needed
                return  ex.Message;
                //return null;
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                webData = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }

            return webData;
        }

        public string getDataWithToken(string url,string Token ,string Method)
        {

            string webData = null;
            string urlAddress = url;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;
            HttpWebRequest request;
            HttpWebResponse response;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(urlAddress);
                request.Method = Method;
                request.Headers.Add("Authorization", "Bearer " + Token);
                response = (HttpWebResponse)request.GetResponse();
            }

            catch (Exception ex)
            {
                //this could be modified for specific responses if needed
                return ex.Message;
                //return null;
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                webData = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }

            return webData;
        }


    }
}