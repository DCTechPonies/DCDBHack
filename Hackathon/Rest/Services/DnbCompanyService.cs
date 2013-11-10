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
    public class DnbCompanyService : Service
    {
        public object Get(DnbCompanyRequest request)
        {
            //Sandbox
            //request.AuthToken = "OLtSGKF9hEIePfGG45cjgpSSLIAk2cQcTJkc7i8Saw0tTiODz2NAUdyGUsKOsNmIHm5Jw/SsbjoycpFfMyhPoJS2NsIhOFZWYwZsO+3dfXlzlBvoLkAxP020zScurR6wnSKozn6np6rLhpE0ejUVTvG8iKCHywP9dyPgg1vXRX1o1YbX8XMlSpa+VAWhJVAiRRNuMmIlATJLamrhxSTJ1jgydRbdZ80Jm4llCRzOQCb/9CHkyKrt0AgQckb/X6nsR80ydiOqFRavtRLjK3X+qgRX9DRcaHLcWPGRWhWt8MMBt11zijUswuk8Z4UaocY9ZA8nSUWdiebbcpBy0hHxuvDIG4dZByNRBkWc6EYNXHI=";
            //Prod
            request._AuthToken = "AsAFLo/h3hh3qyjaLwzpYv3usddOE6XqGM7sDWV+/mbJeduCr1TnkX0QA/x/MEAE8JiiDKbQSVvNxWf/A9qfni8OaS83DGzdoDmzPFPfsYlF8SwCgTxnOgrR+PLPuYHd/dnIA7aSNk/BZ9WCAKxmdstVoGW+L3cTtX6lx92zko1lAZ/JsDYDRHMOSnX1jqXnIzf4WPjKFJipztzOM+U1Khm6qIkUJUVTiLtH+9ev590yKnPHTYSeoz5ULdJpCcOdFvRBuRidgtPtxjvsLIA/aEQqZWZlWueq/E2iHhy5LZ87lzd89zTPBN7JGS6qidGPwxlbQ/EhEk2X9cDY1LPiAQ==";
            
            PopulateParameters(request);

            var restClient = new RestClient("https://maxcvservices.dnb.com/V4.0");
            var restRequest = new RestRequest();

            restRequest.Method = Method.GET;
            restRequest.Resource = String.Format("/organizations?fraudscore=true{0}",BuildParameterURL(request));

            restRequest.AddHeader("Authorization", request._AuthToken);
            var response = restClient.Execute(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpException(500, "D&B Request Failed.");
            }
            //var responseObject = JsonConvert.DeserializeObject<Rootobject>(response.Content);
            return response.Content;
        }

        public string BuildParameterURL(DnbCompanyRequest request)
        {
            var result = string.Empty;

            foreach (var field in request.GetType().GetProperties())
            {
                var val = field.GetValue(request, null);

                if (val != null && !field.Name.StartsWith("_"))
                {
                    switch (field.Name.ToLower())
                    {
                        case "streetaddressline":
                            result += String.Format("&StreetAddressLine-1={0}", request.StreetAddressLine);
                            break;
                        default:
                            result += String.Format("&{0}={1}", field.Name, (string)val);
                            break;
                    }
                }
            }

            return DummyURLFormat(result);
        }

        public string DummyURLFormat(string value)
        {
            return value.Replace(" ", "%20");
        }

        public void PopulateParameters(DnbCompanyRequest request)
        {
            var parameters = (from kvp in request._SearchTerms.Split('&')
                              select kvp).ToDictionary((a => a.Split('=')[0].ToLower()), a => a.Split('=')[1]);

            foreach (var field in request.GetType().GetProperties())
            {
                if (parameters.Keys.Contains(field.Name.ToLower()))
                {
                    if (field.ReflectedType == typeof(int))
                    {
                        field.SetValue(request, int.Parse(parameters[field.Name.ToLower()]),null);
                    }
                    else
                    {
                        //field.GetSetMethod().Invoke(request, object[] {
                        field.SetValue(request, parameters[field.Name.ToLower()], null);
                    }
                }
            }

            //foreach (var term in request.SearchTerms.Split('&'))
            //{
            //    switch (term.Split('=')[0].ToLower())
            //    {
            //        case "applicationtransactionid":
            //            request.ApplicationTransactionID = term.Split('=')[1];
            //            break;
            //        case "transactiontimestamp":
            //            request.TransactionTimestamp = term.Split('=')[1];
            //            break;
            //        case "submittingofficeid":
            //            request.SubmittingOfficeID = term.Split('=')[1];
            //            break;
            //        case "subjectname":
            //            request.SubjectName = term.Split('=')[1];
            //            break;
            //        case "streetaddressline":
            //            request.StreetAddressLine = term.Split('=')[1];
            //            break;
            //        case "primarytownname":
            //            request.PrimaryTownName = term.Split('=')[1];
            //            break;
            //        case "countryisoalpha2code":
            //            request.CountryISOAlpha2Code = term.Split('=')[1];
            //            break;
            //        case "territoryname":
            //            request.TerritoryName = term.Split('=')[1];
            //            break;
            //        case "postalcode":
            //            request.PostalCode = term.Split('=')[1];
            //            break;
            //        case "telecommunicationnumber":
            //            request.TelecommunicationNumber = term.Split('=')[1];
            //            break;
            //        case "internationdialingcode":
            //            request.InternationDialingCode = int.Parse(term.Split('=')[1]);
            //            break;
            //        case "customerreferencetext":
            //            request.CustomerReferenceText = term.Split('=')[1];
            //            break;
            //        case "customerbillingendorcementtext":
            //            request.CustomerBillingEndorcementText = term.Split('=')[1];
            //            break;
            //        default:
            //            break;
            //    }
            //}

        }



    }
}