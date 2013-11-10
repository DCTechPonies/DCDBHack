using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Hackathon.Rest.Endpoints;

namespace Hackathon.Rest.Services
{
    /// <summary>
    /// This sample code shows a render of the "samples/WelcomeTemplate.doc" template using JSON format
    /// instruction and data.
    ///
    /// There are several constants at the top of this file which you can modify to suit your test. You
    /// need to set:
    ///
    /// ACCESS_KEY - this key is your unique access to the Docmosis services (keep it safe). You can see
    /// your access key in your Account Settings in the Cloud area Docmosis web site.
    ///
    /// If you have troubles connecting, it is likely because you have a proxy server you need to
    /// configure. See the PROXY_* settings below to enable it.
    /// </summary>
    /// 
    /// Copyright Docmosis 2012
    /// 
    public class ReportService : GenericService<ReportRequest>
    {
        private static string DWS_RENDER_URL = "https://dws.docmosis.com/services/rs/render";

        // Set your access key here. This is visible in your cloud account in the Docmosis Web Site.
        // It is your key to accessing your service - keep it private and safe.
        private const string ACCESS_KEY = "MzM0NzdjNWUtYjUwZC00YWY3LWE5ZDEtODc1ZTQ4MzVlOTVjOjQ0MjI5NTA";

        // The output format we want to produce (pdf, doc, odt and more exist)
        private const string OUTPUT_FORMAT = "pdf";

        // the name of the template (stored in our cloud account) to use
        private const string TEMPLATE = "templates/WelcomeTemplate.doc";

        // the name of the file we are going to write the document to
        private const string OUTPUT_FILE = "myWelcome." + OUTPUT_FORMAT;

        // Proxy settings if needed to reach the internet
        private const string PROXY_HOST = "";
        private const string PROXY_PORT = "";
        private const string PROXY_USER = "";
        private const string PROXY_PASSWD = "";


        public object Get(ReportRequest request)
        {
            object result = null;
            if (ACCESS_KEY.Equals("XXXXX", StringComparison.Ordinal))
            {
                Console.Error.WriteLine("Please set your private ACCESS_KEY at the top of this file from your Docmosis cloud account.");
                Console.Out.WriteLine("Press any key");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
            HttpWebResponse response;
            try
            {
                response = sendRequest();
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        result = response.GetResponseStream();
                    }
                    else
                    {
                        result = response;
                    }
                }
                finally
                {
                    //response.Close();
                }
            }
            catch (WebException e)
            {
                //Console.WriteLine("ERROR:" + e.Message);
                using (WebResponse webResponse = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)webResponse;
                    processError(httpResponse);
                }
            }
            catch (Exception e)
            {
            }


            return result;
        }

        /// <summary>
        /// Sends the request to the server and returns the response.
        /// </summary>
        /// <returns> 
        /// the response returned by the server
        /// </returns>
        static HttpWebResponse sendRequest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(DWS_RENDER_URL);
            if (PROXY_HOST.Length != 0)
            {
                WebProxy proxy = new WebProxy(PROXY_HOST + ":" + PROXY_PORT, true);
                if (PROXY_USER.Length != 0)
                {
                    proxy.Credentials = new NetworkCredential(PROXY_USER, PROXY_PASSWD);
                }
                Console.WriteLine(proxy.Address);
                request.Proxy = proxy;
            }

            string renderRequest = buildRequest();
            Console.WriteLine("Sending request:" + renderRequest);
            byte[] data = new UTF8Encoding().GetBytes(renderRequest);

            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = data.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);

            return (HttpWebResponse)request.GetResponse();
        }

        /// <summary>
        /// Build the request in JSON format. You can do it in XML if you prefer (code not shown here).
        /// </summary>
        private static string buildRequest()
        {

            StringBuilder sb = new StringBuilder();

            // Start building the instruction
            sb.Append("{\n");
            sb.Append("\"accessKey\":\"").Append(ACCESS_KEY).Append("\",\n");
            sb.Append("\"templateName\":\"").Append(TEMPLATE).Append("\",\n");
            sb.Append("\"outputName\":\"").Append(OUTPUT_FILE).Append("\",\n");
            sb.Append("\"outputFormat\":\"").Append(OUTPUT_FORMAT).Append("\",\n");

            // now add the data specifically for this template
            string[] messages = { "This cloud thing is better than I thought.",
				                  "The sun is shining", 
                                  "Right, now back to work." };

            sb.Append("\"data\":{\n");
            sb.Append("\"date\":\"").Append(DateTime.Now).Append("\",\n");
            sb.Append("\"title\":\"Welcome to Docmosis in the Cloud\",\n");
            sb.Append("\"messages\":[\n");
            for (int i = 0; i < messages.Length; i++)
            {
                sb.Append("{\"msg\":\"").Append(messages[i]).Append("\"}");
                if (i < messages.Length - 1)
                {
                    sb.Append(',');
                }
                sb.Append("\n");
            }
            sb.Append("]}\n");

            // end the entire instruction
            sb.Append("}\n");

            return sb.ToString();
        }

        /// <summary>
        /// Save the given Input stream to a file
        /// </summary>
        /// <param name="content">the Stream containing the content to save</param>
        private static void saveToFile(Stream content)
        {
            byte[] buff = new byte[1000];
            int bytesRead = 0;

            FileStream file = File.Create(OUTPUT_FILE);
            try
            {
                while ((bytesRead = content.Read(buff, 0, buff.Length)) > 0)
                {
                    file.Write(buff, 0, bytesRead);
                }
            }
            finally
            {
                file.Close();
            }

            Console.Out.WriteLine("Created file:" + file.Name);
        }

        /// <summary>
        ///  Something went wrong in the call to the service, tell the user about it
        /// </summary>
        /// <param name="response">The response causing errors</param>
        private static void processError(HttpWebResponse response)
        {
            Console.Error.WriteLine("Our call failed: status = {0}", response.StatusCode);
            Console.Error.WriteLine("message:" + response.StatusDescription);
            StreamReader errorReader = new StreamReader(response.GetResponseStream());
            String msg;
            while ((msg = errorReader.ReadLine()) != null)
            {
                Console.Error.WriteLine(msg);
            }
        }
    }
}