using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Rest.Endpoints
{
    [Route("/dnb/assessment/{filter}/{duns}", "GET")]
    public class DnbAssessmentRequest : IGenericRequest
    {
        public string Filter { get; set; }
        public string DUNS { get; set; }
    }
}