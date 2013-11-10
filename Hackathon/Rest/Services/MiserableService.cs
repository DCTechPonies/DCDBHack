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
    public class MiserableService : Service
    {
        public object Get(MiserableSampleRequest request)
        {
            System.Threading.Thread.Sleep(2000);

            return @"{
  ""nodes"":[
    {""name"":""Myriel"",""group"":1},
    {""name"":""Napoleon"",""group"":1},
    {""name"":""Mlle.Baptistine"",""group"":1},
    {""name"":""Mme.Magloire"",""group"":1},
    {""name"":""CountessdeLo"",""group"":1},
    {""name"":""Geborand"",""group"":1},
    {""name"":""Champtercier"",""group"":1},
    {""name"":""Cravatte"",""group"":1},
    {""name"":""Count"",""group"":1},
    {""name"":""OldMan"",""group"":1},
    {""name"":""Labarre"",""group"":2},
    {""name"":""Valjean"",""group"":2},
    {""name"":""Marguerite"",""group"":3},
    {""name"":""Mme.deR"",""group"":2},
    {""name"":""Isabeau"",""group"":2},
    {""name"":""Gervais"",""group"":2},
    {""name"":""Tholomyes"",""group"":3},
    {""name"":""Listolier"",""group"":3},
    {""name"":""Fameuil"",""group"":3}
  ],
  ""links"":[
    {""source"":1,""target"":0,""value"":1},
    {""source"":2,""target"":0,""value"":8},
    {""source"":3,""target"":0,""value"":10},
    {""source"":3,""target"":2,""value"":6},
    {""source"":4,""target"":0,""value"":1},
    {""source"":5,""target"":0,""value"":1},
    {""source"":6,""target"":0,""value"":20},
    {""source"":7,""target"":0,""value"":1},
    {""source"":8,""target"":0,""value"":2},
    {""source"":9,""target"":0,""value"":1},
    {""source"":11,""target"":10,""value"":1},
    {""source"":11,""target"":3,""value"":3},
    {""source"":11,""target"":2,""value"":3},
    {""source"":11,""target"":0,""value"":5},
    {""source"":12,""target"":11,""value"":1},
    {""source"":13,""target"":11,""value"":1},
    {""source"":14,""target"":11,""value"":1},
    {""source"":15,""target"":11,""value"":1},
    {""source"":17,""target"":16,""value"":4},
    {""source"":18,""target"":16,""value"":4},
    {""source"":18,""target"":17,""value"":4}
  ]
}";
        }

    }
}