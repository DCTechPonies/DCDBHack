using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Rest.Endpoints
{
    public class IGenericRequest
    {
        public string _AuthToken { get; set; }
        public string _SearchTerms { get; set; }
    }
}