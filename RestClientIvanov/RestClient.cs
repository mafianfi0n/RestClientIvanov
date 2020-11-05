using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestClientIvanov
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb HttpMethod { get; set; }

        public RestClient()
        {
            endPoint = string.Empty;
            HttpMethod = httpVerb.GET;


        }
        public string MakeRequest()
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = HttpMethod.ToString();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code:" + response.StatusCode.ToString());
                }
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }

            return strResponseValue;
        }

    }
}
