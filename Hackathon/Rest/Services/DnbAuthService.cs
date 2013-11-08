using Hackathon.Rest.Endpoints;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace Hackathon.Rest.Services
{
    public class DnbAuthService : Service
    {
        public object Post(DnbAuthRequest request)
        {
            var user = System.Configuration.ConfigurationManager.AppSettings["dnb-user"];
            var password = System.Configuration.ConfigurationManager.AppSettings["dnb-pwd"];
            var restClient = new RestClient("https://maxcvservices.dnb.com/rest");
            var restRequest = new RestRequest("/Authentication", Method.POST);
            restRequest.AddHeader("x-dnb-user", user);
            restRequest.AddHeader("x-dnb-pwd", password);
            var response = restClient.Execute(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpException(500, "D&B Authentication Failed.");
            }
            return new DnbAuthDto()
            {
                User = (string)response.Headers.Single(h => h.Name == "x-dnb-user").Value,
                Password = (string)response.Headers.Single(h => h.Name == "x-dnb-pwd").Value,
                AuthToken = (string)response.Headers.Single(h => h.Name == "Authorization").Value
            };
        }
    }

    public class DnbAuthDto
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string AuthToken { get; set; }
    }
}