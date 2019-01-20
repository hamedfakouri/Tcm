using System;
using Framework.Core;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SocialApp.API.Helpers;

namespace Tcm.Interface.Api.Helpers
{
    // Extension Methods
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            // The "Application-Error" header is not exposed to client by default
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            // Need to set the "Access-Control-Allow-Origin" to allow CORS requests:
            // See: https://docs.microsoft.com/en-us/aspnet/core/security/cors#how-cors-works
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static void AddPagination(
            this HttpResponse response,UserParams userParams)
        {
            var paginatinoHeader = new PaginationHeader(userParams.PageNumber,
                userParams.PageSize, userParams.Count, userParams.TotalPages);

            // Serialize the pagination header in JSON format in Camel Case.
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(
                paginatinoHeader, camelCaseFormatter));

            // The "Pagination" header is not exposed to client by default
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }

        public static int CalculateAge(this DateTime birthDate)
        {
            var age = DateTime.Today.Year - birthDate.Year;

            if(birthDate.AddYears(age) > DateTime.Today)
                age--;

            return age;
        }
    }
}
