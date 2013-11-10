using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Rest.Endpoints
{
    [Route("/dnb/auth/{_searchTerms*}", "POST")]
    public class DnbAuthRequest : IGenericRequest
    {
    }
}