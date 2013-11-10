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
            // name = company name
            // group = node color (1=r, 2=g, 3=b)
            // size = node size [1|2|3|4|5]
            // value = line width in pixels
            System.Threading.Thread.Sleep(2000);

            return @"{
  ""nodes"":[
    {""name"":""Apple, Inc."",""group"":1,""size"":1},
    {""name"":""Napoleon"",""group"":2,""size"":3},
    {""name"":""Mlle.Baptistine"",""group"":3,""size"":1},
    {""name"":""Mme.Magloire"",""group"":2,""size"":5},
    {""name"":""CountessdeLo"",""group"":2,""size"":1},
    {""name"":""Geborand"",""group"":2,""size"":1},
    {""name"":""Champtercier"",""group"":2,""size"":1},
    {""name"":""Cravatte"",""group"":2,""size"":1},
    {""name"":""Count"",""group"":2,""size"":4},
    {""name"":""OldMan"",""group"":1,""size"":1},
    {""name"":""Labarre"",""group"":1,""size"":1},
    {""name"":""Valjean"",""group"":1,""size"":1},
    {""name"":""Marguerite"",""group"":2,""size"":1},
    {""name"":""Mme.deR"",""group"":2,""size"":1},
    {""name"":""Isabeau"",""group"":2,""size"":1},
    {""name"":""Gervais"",""group"":2,""size"":2},
    {""name"":""Tholomyes"",""group"":2,""size"":1},
    {""name"":""Listolier"",""group"":2,""size"":1},
    {""name"":""Fameuil"",""group"":2,""size"":1},
    {""name"":""Ken"",""group"":2,""size"":3},
    {""name"":""Mark"",""group"":2,""size"":1},
    {""name"":""Max"",""group"":2,""size"":1},
    {""name"":""Josh"",""group"":2,""size"":5},
    {""name"":""Josh"",""group"":2,""size"":1},
    {""name"":""Josh"",""group"":2,""size"":1},
    {""name"":""Josh"",""group"":2,""size"":1}
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
    {""source"":18,""target"":17,""value"":4},
    {""source"":19,""target"":17,""value"":4},
    {""source"":20,""target"":17,""value"":4},
    {""source"":21,""target"":17,""value"":4},
    {""source"":22,""target"":17,""value"":4}
  ]
}";
        }

    }
}