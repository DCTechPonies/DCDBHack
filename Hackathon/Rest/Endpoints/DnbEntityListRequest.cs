using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Rest.Endpoints
{
    [Route("/dnb/entity/{filter}/{searchTerms}", "GET")]
    public class DnbEntityListRequest
    {
        public string AuthToken { get; set; }
        
        /// <summary>
        /// [company|contact|competitors|industry]
        /// </summary>
        public string Filter { get; set; }
        public string SearchTerms { get; set; }
    }
}