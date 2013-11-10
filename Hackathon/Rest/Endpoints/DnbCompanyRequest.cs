using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Rest.Endpoints
{
    [Route("/dnb/company/fraudscore/{_searchTerms*}", "GET")]
    public class DnbCompanyRequest
    {
        public string _AuthToken { get; set; }

        public string ApplicationTransactionID { get; set; }

        public string TransactionTimestamp { get; set; }

        public string SubmittingOfficeID { get; set; }

        public string SubjectName { get; set; }
        public string StreetAddressLine { get; set; }
        public string PrimaryTownName { get; set; }
        public string CountryISOAlpha2Code { get; set; }
        public string TerritoryName { get; set; }
        public string PostalCode { get; set; }
        public string TelecommunicationNumber { get; set; }
        public int? InternationDialingCode { get; set; }
        public string CustomerReferenceText { get; set; }
        public string CustomerBillingEndorcementText { get; set; }

        public string _SearchTerms { get; set; }

    }
}