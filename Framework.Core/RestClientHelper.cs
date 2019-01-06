using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Framework.Core
{
    public static class RestClientHelper
    {
        public static IRestResponse<TResponse> Post<TInput, TResponse>(string address, TInput requestedData) where TInput : new() where TResponse : new()
        {
            return Send<TResponse>(address, Method.POST, requestedData);
        }

        public static IRestResponse<TResponse> Post<TResponse>(string address, object requestedData, string bearerToken = null) where TResponse : new()
        {
            return Send<TResponse>(address, Method.POST, requestedData, bearerToken);
        }

        public static void PostAsync(string fullAdresss, object requestInput = null)
        {
            Task.Run(() => Post(fullAdresss, requestInput)).ConfigureAwait(false);
        }

        public static void Post(string fullAdresss, object requestInput = null)
        {
            Send(fullAdresss, Method.POST, requestInput);
        }

        public static IRestResponse<TResponse> Get<TInput, TResponse>(string address, TInput requestedData) where TInput : new() where TResponse : new()
        {
            return Send<TResponse>(address, Method.GET, requestedData);
        }

        public static IRestResponse<TResponse> Get< TResponse>(string address)  where TResponse : new()
        {
            return Send<TResponse>(address, Method.GET);
        }

        private static void Send(string fullAdress, Method method, object input = null)
        {
            RestClient client = new RestClient();
            RestRequest request =
                new RestRequest(fullAdress, method)
                {
                    RequestFormat = DataFormat.Json
                };

            if (input != null)
                request.AddBody(input);

            client.Execute(request);
        }

        private static IRestResponse<TResponse>
            Send<TResponse>(string fullAdress, Method method, object input = null, string bearerToken = null) where TResponse : new()
        {
            RestClient client = new RestClient();
            RestRequest request =
                new RestRequest(fullAdress, method)
                {
                    RequestFormat = DataFormat.Json
                };

            if (input != null)
                request.AddBody(input);

            if (bearerToken != null)
                request.AddHeader("Authorization", $"Bearer {bearerToken}");

            return client.Execute<TResponse>(request);
        }
    }
}
