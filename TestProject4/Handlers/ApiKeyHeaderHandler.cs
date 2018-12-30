using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace TestProject4.Handlers
{
    public class ApiKeyHeaderHandler : DelegatingHandler
    {
        public const string _apiKeyHeader = "X-API-Key";

        public const string _apiQueryString = "api_key";

        protected override Task<HttpResponseMessage> SendAsync(
       HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // STEP 1: Global message-level logic that must be executed BEFORE the request
            //          is sent on to the action method
            string apikey = null;
            // if swagger abort out early (latest swagger doesn't need this it seems)
            //if (request.RequestUri.Segments[1].ToLowerInvariant().StartsWith("swagger"))
            //    return base.SendAsync(request, cancellationToken);

            if (request.Headers.Contains(_apiKeyHeader))
            {
                apikey = request.Headers.GetValues(_apiKeyHeader).FirstOrDefault();
            } else
            {
                // let's see if it is on the query string instead
                var queryString = request.GetQueryNameValuePairs();
                var kvp = queryString.FirstOrDefault(a => a.Key.ToLowerInvariant().Equals(_apiQueryString));
                if (!string.IsNullOrEmpty(kvp.Value))
                    apikey = kvp.Value;
            }
            // was any api key present? If none, abort request
            //if (string.IsNullOrEmpty(apikey))
            //{
            //    // create response
            //    var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
            //    {
            //        Content = new StringContent("Missing API key")
            //    };
            //    return Task.FromResult(response);
            //}
            // save the value to Properties
            request.Properties.Add(_apiKeyHeader, apikey);
            // compress steps 2, 3, and 4 into one line since we don't need any post-request processing
            return base.SendAsync(request, cancellationToken);
          
        }     

    }
    public static class HttpRequestMessageApiKeyExtension
    {
        /// <summary>
        /// Gets the API key.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>This is not fully working and/or returning the apikey in the result</returns>
        public static string GetApiKey(this HttpRequestMessage request)
        {
            if (request == null)
                return null;

            if (request.Properties.TryGetValue(ApiKeyHeaderHandler._apiKeyHeader, out object apiKey))
            {
                return (string)apiKey;
            }
            return null;
        }
    }
}