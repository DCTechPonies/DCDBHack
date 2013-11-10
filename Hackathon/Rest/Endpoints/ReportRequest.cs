using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Rest.Endpoints
{
    [Route("/dnb/report", "GET")]
    public class ReportRequest : IGenericRequest
    {
        public string Filter { get; set; }
        public string DUNS { get; set; }
    }
}