using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Rest.Endpoints
{
    [Route("/dnb/publicrecord/{filter}/{searchTerms}", "GET")]
    public class DnbPublicRecordRequest : IGenericRequest
    {
        public string Filter { get; set; }
    }
}