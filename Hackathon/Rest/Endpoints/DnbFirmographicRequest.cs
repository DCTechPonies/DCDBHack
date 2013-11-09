using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Rest.Endpoints
{
    [Route("/dnb/firmographic/{searchTerms}", "GET")]
    public class DnbFirmographicRequest
    {
        public string AuthToken { get; set; }
        public string SearchTerms { get; set; }

    }
}