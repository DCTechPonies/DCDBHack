using Hackathon.Rest.Endpoints;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Newtonsoft.Json;

namespace Hackathon.Rest.Endpoints
{
    [Route("/dashboard/{_searchTerms*}", "GET")]
    public class DashboardRequest : IGenericRequest
    {
    }
}

namespace Hackathon.Rest.Services
{

    public class DashboardService : GenericService<DashboardRequest>
    {
        public object Get(DashboardRequest request)
        {
            var tok = Session["AuthToken"];
            if (tok != null)
            {
                request._AuthToken = (string)tok;
            }
            else
            {
                Response.Redirect("/");
            }

            //var restClient = new RestClient("https://maxcvservices.dnb.com/V2.1");
            //var restRequest = new RestRequest();
            //restRequest.Method = Method.GET;
            //restRequest.Resource = String.Format("/organizations/{0}/products/DCP_ALT_PREM", request._SearchTerms);

            //restRequest.AddHeader("Authorization", request._AuthToken);
            //var response = restClient.Execute(restRequest);
            //if (response.StatusCode != System.Net.HttpStatusCode.OK)
            //{
            //    throw new HttpException(500, string.Format("D&B Request Failed: {0}",response.Content));
            //}
            //var responseObject = JsonConvert.DeserializeObject<Rootobject>(response.Content);
            //return response.Content;

            Response.RedirectToUrl("/dashboard.html");
            return null;
        }





    }
}