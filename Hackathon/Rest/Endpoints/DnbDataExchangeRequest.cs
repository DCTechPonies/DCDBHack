using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Rest.Endpoints
{
    [Route("/dnb/social/{filter}/{_searchTerms}", "GET")]
    public class DnbDataExchangeRequest : IGenericRequest
    {
        public string Filter { get; set; }
    }
}