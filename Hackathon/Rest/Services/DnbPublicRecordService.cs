using Hackathon.Rest.Endpoints;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Newtonsoft.Json;

namespace Hackathon.Rest.Services
{
    public class DnbPublicRecordService : GenericService<DnbPublicRecordRequest>
    {
        public object Get(DnbPublicRecordRequest request)
        {
            //Sandbox
            //request.AuthToken = "OLtSGKF9hEIePfGG45cjgpSSLIAk2cQcTJkc7i8Saw0tTiODz2NAUdyGUsKOsNmIHm5Jw/SsbjoycpFfMyhPoJS2NsIhOFZWYwZsO+3dfXlzlBvoLkAxP020zScurR6wnSKozn6np6rLhpE0ejUVTvG8iKCHywP9dyPgg1vXRX1o1YbX8XMlSpa+VAWhJVAiRRNuMmIlATJLamrhxSTJ1jgydRbdZ80Jm4llCRzOQCb/9CHkyKrt0AgQckb/X6nsR80ydiOqFRavtRLjK3X+qgRX9DRcaHLcWPGRWhWt8MMBt11zijUswuk8Z4UaocY9ZA8nSUWdiebbcpBy0hHxuvDIG4dZByNRBkWc6EYNXHI=";
            //Prod
            request._AuthToken = (string)Session["AuthToken"];

            var restClient = new RestClient("https://maxcvservices.dnb.com/V3.0/organizations");
            var restRequest = new RestRequest();

            switch (request.Filter)
            {
                case "suits":
                    restRequest.Method = Method.GET;
                    restRequest.Resource = String.Format("/{0}/products/PUBREC_SUITS", request._SearchTerms);
                    break;
                case "liens":
                    restRequest.Method = Method.GET;
                    restRequest.Resource = String.Format("/{0}/products/PUBREC_LIENS", request._SearchTerms);
                    break;
                case "judgments":
                    restRequest.Method = Method.GET;
                    restRequest.Resource = String.Format("/{0}/products/PUBREC_JDG", request._SearchTerms);
                    break;
                case "uccfilings":
                    restRequest.Method = Method.GET;
                    restRequest.Resource = String.Format("/{0}/products/PUBREC_UCC", request._SearchTerms);
                    break;
                case "businessregistration":
                    restRequest.Method = Method.GET;
                    restRequest.Resource = String.Format("/{0}/products/PUBREC_BR", request._SearchTerms);
                    break;
                case "corporateentityownerhip":
                    restRequest.Method = Method.GET;
                    restRequest.Resource = String.Format("/{0}/products/PUBREC_OS", request._SearchTerms);
                    break;
                case "suitlienjudgementbanckruptcy":
                    restRequest.Method = Method.GET;
                    restRequest.Resource = String.Format("/{0}/products/PUBREC_DTLS", request._SearchTerms);
                    break;
                default:
                    throw new Exception(request.Filter + " is not a vaild type.");
            }

            restRequest.AddHeader("Authorization", request._AuthToken);
            var response = restClient.Execute(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpException(500, "D&B Request Failed.");
            }
            //var responseObject = JsonConvert.DeserializeObject<Rootobject>(response.Content);
            return response.Content;
        }





    }
}