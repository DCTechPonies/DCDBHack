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
    public class DnbDataExchangeService : Service
    {
        public object Get(DnbDataExchangeRequest request)
        {
            //Sandbox
            //request.AuthToken = "OLtSGKF9hEIePfGG45cjgpSSLIAk2cQcTJkc7i8Saw0tTiODz2NAUdyGUsKOsNmIHm5Jw/SsbjoycpFfMyhPoJS2NsIhOFZWYwZsO+3dfXlzlBvoLkAxP020zScurR6wnSKozn6np6rLhpE0ejUVTvG8iKCHywP9dyPgg1vXRX1o1YbX8XMlSpa+VAWhJVAiRRNuMmIlATJLamrhxSTJ1jgydRbdZ80Jm4llCRzOQCb/9CHkyKrt0AgQckb/X6nsR80ydiOqFRavtRLjK3X+qgRX9DRcaHLcWPGRWhWt8MMBt11zijUswuk8Z4UaocY9ZA8nSUWdiebbcpBy0hHxuvDIG4dZByNRBkWc6EYNXHI=";
            //Prod
            request.AuthToken = "AsAFLo/h3hh3qyjaLwzpYv3usddOE6XqGM7sDWV+/mbJeduCr1TnkX0QA/x/MEAE8JiiDKbQSVvNxWf/A9qfni8OaS83DGzdoDmzPFPfsYlF8SwCgTxnOgrR+PLPuYHd/dnIA7aSNk/BZ9WCAKxmdstVoGW+L3cTtX6lx92zko1lAZ/JsDYDRHMOSnX1jqXnIzf4WPjKFJipztzOM+U1Khm6qIkUJUVTiLtH+9ev590yKnPHTYSeoz5ULdJpCcOdFvRBuRidgtPtxjvsLIA/aEQqZWZlWueq/E2iHhy5LZ87lzd89zTPBN7JGS6qidGPwxlbQ/EhEk2X9cDY1LPiAQ==";

            var restClient = new RestClient("https://maxcvservices.dnb.com/dataexchange/fliptop");
            var restRequest = new RestRequest();

            switch (request.Filter)
            {
                case "company":
                    restRequest.Method = Method.GET;
                    restRequest.Resource = String.Format("/beta/company?duns={0}", request.SearchTerms);
                    break;
                case "person":
                    restRequest.Method = Method.GET;
                    restRequest.Resource = String.Format("/beta/person?email={0}", request.SearchTerms);
                    break;
                default:
                    throw new Exception(request.Filter + " is not a vaild type.");
            }

            restRequest.AddHeader("Authorization", request.AuthToken);
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