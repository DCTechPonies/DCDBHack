using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Rest.Endpoints
{
    [Route("/dnb/social/{filter}/{searchTerms}", "GET")]
    public class DnbDataExchangeRequest
    {
        public string AuthToken { get; set; }
        public string Filter { get; set; }
        public string SearchTerms { get; set; }

    }
}