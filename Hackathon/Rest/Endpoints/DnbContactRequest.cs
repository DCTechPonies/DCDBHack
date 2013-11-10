using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Rest.Endpoints
{
    [Route("/dnb/contact/{duns}/{pin}", "GET")]
    public class DnbContactRequest : IGenericRequest
    {
        public string DUNS { get; set; }
        public string Pin { get; set; }
    }
}