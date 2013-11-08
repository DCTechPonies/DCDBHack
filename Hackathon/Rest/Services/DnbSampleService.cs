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
    public class DnbSampleService : Service
    {
        public object Get(DnbSampleRequest request)
        {
            var restClient = new RestClient("https://maxcvservices.dnb.com/V4.0");
            var restRequest = new RestRequest("/organizations?CountryISOAlpha2Code=US&SubjectName=GORMAN%20MANUFACTURING&match=true&MatchTypeText=Advanced&TerritoryName=CA", Method.GET);
            restRequest.AddHeader("Authorization", request.AuthToken);
            var response = restClient.Execute(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpException(500, "D&B Sample Request Failed.");
            }
            var responseObject = JsonConvert.DeserializeObject<Rootobject>(response.Content);
            return responseObject.MatchResponse.MatchResponseDetail.MatchCandidate;
        }
    }

    public class Rootobject
    {
        public Matchresponse MatchResponse { get; set; }
    }

    public class Matchresponse
    {
        public string ServiceVersionNumber { get; set; }
        public Transactiondetail TransactionDetail { get; set; }
        public Transactionresult TransactionResult { get; set; }
        public Matchresponsedetail MatchResponseDetail { get; set; }
    }

    public class Transactiondetail
    {
        public string ApplicationTransactionID { get; set; }
        public string ServiceTransactionID { get; set; }
        public DateTime TransactionTimestamp { get; set; }
    }

    public class Transactionresult
    {
        public string SeverityText { get; set; }
        public string ResultID { get; set; }
        public string ResultText { get; set; }
    }

    public class Matchresponsedetail
    {
        public Matchdatacriteriatext MatchDataCriteriaText { get; set; }
        public int CandidateMatchedQuantity { get; set; }
        public List<Matchcandidate> MatchCandidate { get; set; }
    }

    public class Matchdatacriteriatext
    {
        [JsonProperty(PropertyName = "$")]
        public string _ { get; set; }
    }

    public class Matchcandidate
    {
        public string DUNSNumber { get; set; }
        public Organizationprimaryname OrganizationPrimaryName { get; set; }
        public Tradestylename TradeStyleName { get; set; }
        public Primaryaddress PrimaryAddress { get; set; }
        public Mailingaddress MailingAddress { get; set; }
        public Operatingstatustext OperatingStatusText { get; set; }
        public List<Familytreememberrole> FamilyTreeMemberRole { get; set; }
        public bool StandaloneOrganizationIndicator { get; set; }
        public int DisplaySequence { get; set; }
        public Telephonenumber TelephoneNumber { get; set; }
    }

    public class Organizationprimaryname
    {
        public Organizationname OrganizationName { get; set; }
    }

    public class Organizationname
    {
        [JsonProperty(PropertyName = "$")]
        public string _ { get; set; }
    }

    public class Tradestylename
    {
        public Organizationname1 OrganizationName { get; set; }
    }

    public class Organizationname1
    {
        [JsonProperty(PropertyName = "$")]
        public string _ { get; set; }
    }

    public class Primaryaddress
    {
        public List<Streetaddressline> StreetAddressLine { get; set; }
        public string PrimaryTownName { get; set; }
        public string CountryISOAlpha2Code { get; set; }
        public string PostalCode { get; set; }
        public string PostalCodeExtensionCode { get; set; }
        public string TerritoryAbbreviatedName { get; set; }
        public bool UndeliverableIndicator { get; set; }
    }

    public class Streetaddressline
    {
        public string LineText { get; set; }
    }

    public class Mailingaddress
    {
        public string CountryISOAlpha2Code { get; set; }
        public bool UndeliverableIndicator { get; set; }
        public List<Streetaddressline1> StreetAddressLine { get; set; }
        public string PrimaryTownName { get; set; }
        public string PostalCode { get; set; }
        public string TerritoryAbbreviatedName { get; set; }
    }

    public class Streetaddressline1
    {
        public string LineText { get; set; }
    }

    public class Operatingstatustext
    {
        [JsonProperty(PropertyName = "$")]
        public string _ { get; set; }
    }

    public class Telephonenumber
    {
        public string TelecommunicationNumber { get; set; }
        public bool UnreachableIndicator { get; set; }
    }

    public class Familytreememberrole
    {
        public Familytreememberroletext FamilyTreeMemberRoleText { get; set; }
    }

    public class Familytreememberroletext
    {
        [JsonProperty(PropertyName = "$")]
        public string _ { get; set; }
    }
}