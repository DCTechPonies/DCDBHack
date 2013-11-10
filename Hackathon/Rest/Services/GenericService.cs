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
    public class GenericService<T> : Service where T: IGenericRequest
    {

        public string BuildParameterURL(T request)
        {
            var result = string.Empty;

            foreach (var field in request.GetType().GetProperties())
            {
                var val = field.GetValue(request, null);

                if (val != null && !field.Name.StartsWith("_"))
                {
                    //Any other fields that we need to manually override, we will do so in this method.
                    //All others will be sent the same as the parm name.
                    switch (field.Name.ToLower())
                    {
                        case "streetaddressline":
                            result += String.Format("&StreetAddressLine-1={0}", (string)val);
                            break;
                        default:
                            result += String.Format("&{0}={1}", field.Name, (string)val);
                            break;
                    }
                }
            }

            return DummyURLFormat(result);
        }

        //A very crude URL formatter to replace spaces with %20. More can be added later if need be.
        public string DummyURLFormat(string value)
        {
            return value.Replace(" ", "%20");
        }

        public void PopulateParameters(T request)
        {
            var parameters = (from kvp in request._SearchTerms.Split('&')
                              select kvp).ToDictionary((a => a.Split('=')[0].ToLower()), a => a.Split('=')[1]);

            foreach (var field in request.GetType().GetProperties())
            {
                if (parameters.Keys.Contains(field.Name.ToLower()))
                {
                    if (field.ReflectedType == typeof(int))
                    {
                        field.SetValue(request, int.Parse(parameters[field.Name.ToLower()]), null);
                    }
                    else
                    {
                        //field.GetSetMethod().Invoke(request, object[] {
                        field.SetValue(request, parameters[field.Name.ToLower()], null);
                    }
                }
            }
        }
    }
}