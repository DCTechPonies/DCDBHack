using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Rest.Endpoints
{
    [Route("/dnb/entity/{filter}/{_searchTerms}", "GET")]
    public class DnbEntityListRequest : IGenericRequest
    {
        /// <summary>
        /// [company|contact|competitors|industry]
        /// </summary>
        public string Filter { get; set; }   
    }
}