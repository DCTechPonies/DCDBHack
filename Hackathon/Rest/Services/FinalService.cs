using Hackathon.Rest.Endpoints;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Newtonsoft.Json;

namespace Hackathon.Rest.Services
{
    public class FinalService : Service
    {
        public object Get(FinalRequest request)
        {
            
            System.Threading.Thread.Sleep(1000);

            return @"{
	""nodes"": [{
		""name"": ""Apple (060704780)"",
		""group"": 3,
                     ""size"": 5,
		""FraudScore"": ""2999"",
		""BLBolean"": ""T"",
		""BIRAnalInd"": 0,
		""viability"": ""11AA"",
""jsl"": 4,
""principals"":""Timothy D. Cook, Arthur D. Levinson, Jeffrey E. Williams"",
""value"":1
	},
{
		""name"": ""Microsoft (081466849)"",
		""group"": 2,
                     ""size"": ""1"" ,
		""FraudScore"": ""2975"",
		""BLBolean"": ""F"",
		""BIRAnalInd"": 0,
		""viability"": ""12AA"",
""jsl"": 6,
""principals"":""Steven A. Ballmer, William H. Gates, B. Kevin Turner"",
""value"": 2
							},
{
		""name"": ""Northrop Gruman (047897855)"",
		""group"": 1,
                     	""size"": 1,
		""FraudScore"": ""12AA"",
		""BLBolean"": ""F"",
		""BIRAnalInd"": 0,
		""Viability"":""12AA"",
""JSL"": 7,
""principals"":""Ed Halibozek, James F Pitts, Tammy Scheffers"",
""value"":2
	},
	{
		""name"": ""The Walt Disney Company (932660376)"",
		""group"": 1,
                     	""size"": 1,
		""FraudScore"": ""2999"",
		""BLBolean"": ""T"",
		""BIRAnalInd"": 0,
		""viability"": ""13AA"",
""jsl"": 7,
""principals"":""Robert A. Iger, Jayne Parker, James A. Rasulo""
	},
{
		""name"": ""Avon Products, Inc. (001468693)"",
		""group"": 1,
                     	""size"": 1,
		""FraudScore"": ""2999"",
		""BLBolean"": ""T"",
		""BIRAnalInd"": 0,
		""viability"": ""15AA"",
""jsl"": 5,
""principals"":""Douglas R. Conant, Sherilyn S. McCoy, Kimberly A. Ross""
	},
{
		""name"": ""Hoover Central Vacuum Systems (156138427)"",
		""group"": 1,
                     	""size"": 1,
		""FraudScore"": ""2975"",
		""BLBolean"": ""T"",
		""BIRAnalInd"": 0,
		""viability"": ""64GW"",
""jsl"": 0,
""principals"":""Danny Villines""
	},
{
		""name"": ""Google Inc (060902413)"",
		""group"": 2,
                     	""size"": 1,
		""FraudScore"": ""2817"",
		""BLBolean"": ""F"",
		""BIRAnalInd"": 0,
		""viablity"": ""13AA"",
""jsl"": 29,
""principals"":""Larry Page, Patrick Pichette, Eric E. Schmidt""
	},
{
		""name"": ""Automatic Data Processing, Inc. (001915172)"",
		""group"": 2,
                     	""size"": 1,
		""FraudScore"": ""2878"",
		""BLBolean"": ""F"",
		""BIRAnalInd"": 0,
		""viability"": ""12AA"",
""jsl"": 56,
""principals"": ""Leslie A. Brun, Carlos A. Rodriguez, Jan Siegmuend""
	},
{
		""name"": ""Intel Corporation (047897855)"",
		""group"": 2,
                     	""size"": 2,
		""FraudScore"": ""2669"",
		""BLBolean"": ""F"",
		""BIRAnalInd"": 0,
		""viability"": ""12AA"",
""jsl"": 7,
""principals"": ""Andy D. Bryant, Renee J. James, Brian M. Krazanich""
	},
{
		""name"": ""General Electric (001367960)"",
		""group"": 2,
                     	""size"": 1,
		""FraudScore"": ""2999"",
		""BLBolean"": ""F"",
		""BIRAnalInd"": 0,
		""viability"": ""13AA"",
""jsl"": 50,
""principals"": ""Charlene T. Begley, Jeffrey R. Immelt, Kieth S. Sherin""
	},
{
		""name"": ""Cisco Systems, Inc (153804570)"",
		""group"": 2,
                     	""size"": 1,
		""FraudScore"": ""2975"",
		""BLBolean"": ""F"",
		""BIRAnalInd"": 0,
		""viability"": ""12AA"",
""jsl"": 8,
""principals"": ""John T. Chambers, Gary B. Moore, Frank Calderoni""
	},
{
		""name"": ""Wal-Mart Stores, Inc. (051957769)"",
		""group"": 2,
                     ""size"": 1,
		""FraudScore"": ""2669"",
		""BLBolean"": ""F"",
		""BIRAnalInd"": 0,
		""viability"": ""15AA"",
""jsl"": 8,
""principals"":""S. Robson Walton""
	}
],
	""links"": [{
		""source"": 0,
		""target"": 9,
		""value"": 1
	},
{
		""source"": 0,
		""target"": 4,
		""value"": 1
	},
{
		""source"": 4,
		""target"": 9,
		""value"": 1
	},
{
		""source"": 0,
		""target"": 3,
		""value"": 1
	},
{
		""source"": 0,
		""target"": 1,
		""value"": 1
	},
{
		""source"": 0,
		""target"": 6,
		""value"": 1
	},
{
		""source"": 1,
		""target"": 11,
		""value"": 1
	},
{
		""source"": 9,
		""target"": 11,
		""value"": 1
	},
{
		""source"": 1,
		""target"": 7,
		""value"": 1
	},
{
		""source"": 1,
		""target"": 2,
		""value"": 1
	},
{
		""source"": 2,
		""target"": 7,
		""value"": 1
	},
{
		""source"": 1,
		""target"": 6,
		""value"": 1
	},
{
		""source"": 6,
		""target"": 8,
		""value"": 1
	},
{
		""source"": 6,
		""target"": 5,
		""value"": 1
	},
{
		""source"": 6,
		""target"": 10,
		""value"": 1
	},
{
		""source"": 5,
		""target"": 10,
		""value"": 1
	}
]
}";
        }

    }
}