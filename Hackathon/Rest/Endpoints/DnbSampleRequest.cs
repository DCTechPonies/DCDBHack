using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Rest.Endpoints
{
    [Route("/dnb/sample", "GET")]
    public class DnbSampleRequest
    {
        public string AuthToken { get; set; }
    }
}