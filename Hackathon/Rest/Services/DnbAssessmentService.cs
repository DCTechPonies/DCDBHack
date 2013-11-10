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
    public class DnbAssessmentService : GenericService<DnbAssessmentRequest>
    {
        public object Get(DnbAssessmentRequest request)
        {
            //Sandbox
            //request.AuthToken = "OLtSGKF9hEIePfGG45cjgpSSLIAk2cQcTJkc7i8Saw0tTiODz2NAUdyGUsKOsNmIHm5Jw/SsbjoycpFfMyhPoJS2NsIhOFZWYwZsO+3dfXlzlBvoLkAxP020zScurR6wnSKozn6np6rLhpE0ejUVTvG8iKCHywP9dyPgg1vXRX1o1YbX8XMlSpa+VAWhJVAiRRNuMmIlATJLamrhxSTJ1jgydRbdZ80Jm4llCRzOQCb/9CHkyKrt0AgQckb/X6nsR80ydiOqFRavtRLjK3X+qgRX9DRcaHLcWPGRWhWt8MMBt11zijUswuk8Z4UaocY9ZA8nSUWdiebbcpBy0hHxuvDIG4dZByNRBkWc6EYNXHI=";
            //Prod
            request._AuthToken = (string)Session["AuthToken"];

            var restClient = new RestClient("https://maxcvservices.dnb.com/V3.0");
            var restRequest = new RestRequest();
            restRequest.Method = Method.GET;
            //FIN_ST_PLUS is for the financial statement.
            var requestURL = string.Empty;

            switch (request.Filter.ToLower())
            {
                case "smallbizrisk": //small business risk
                    requestURL = String.Format("/organizations/{0}/products/SBCRP?ArchiveProductOptOutIndicator=1&TradeUpIndicator=0", request._SearchTerms);
                    break;
                case "fss": //financial stress score
                    requestURL = String.Format("/organizations/{0}/products/PBR_FSS_V7.1?ArchiveProductOptOutIndicator=1&TradeUpIndicator=0", request._SearchTerms);
                    break;
                case "ccs": //company credit score
                    requestURL = String.Format("/organizations/{0}/products/PPR_CCS_V9?ArchiveProductOptOutIndicator=1&TradeUpIndicator=0", request._SearchTerms);
                    break;
                case "ratingtrend": //ratings and trends
                    requestURL = String.Format("/organizations/{0}/products/RTNG_TRND?ArchiveProductOptOutIndicator=1&TradeUpIndicator=0", request._SearchTerms);
                    break;
                case "pbrstandard": //Predictive Bancrupty standard
                    requestURL = String.Format("/organizations/{0}/products/PBPR_STD?ArchiveProductOptOutIndicator=1&TradeUpIndicator=0", request._SearchTerms);
                    break;
                case "pbrenhanced": //Predictive Bankruptcy Enhanced
                    requestURL = String.Format("/organizations/{0}/products/PBPR_ENH?ArchiveProductOptOutIndicator=1&TradeUpIndicator=0", request._SearchTerms);
                    break;
                case "emma": //emerging markets
                    requestURL = String.Format("/organizations/{0}/products/PGPR_EMMA?ArchiveProductOptOutIndicator=1&TradeUpIndicator=0", request._SearchTerms);
                    break;
                case "ser": //supplier risk
                    requestURL = String.Format("/organizations/{0}/products/SER?ArchiveProductOptOutIndicator=1&TradeUpIndicator=0", request._SearchTerms);
                    break;
                case "tlp": //total loss predictor
                    requestURL = String.Format("/organizations/{0}/products/TLP?ArchiveProductOptOutIndicator=1&TradeUpIndicator=0", request._SearchTerms);
                    break;
                case "viability": //viability
                    requestURL = String.Format("/organizations/{0}/products/VIAB_RAT?ArchiveProductOptOutIndicator=1&TradeUpIndicator=0", request._SearchTerms);
                    break;
                default:
                break;
            }

            restRequest.Resource = requestURL;

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