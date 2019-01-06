using CarDamageAssessment.Web.Api.MiddleWares;
using Microsoft.AspNetCore.Builder;

namespace Tcm.Interface.Api.MiddleWares
{
  public static class MiddleWareExtensions
  {
    public static IApplicationBuilder UseUnitOfworkMiddleware(this IApplicationBuilder applicationBuilder)
    {
      return applicationBuilder.UseMiddleware<UnitOfWorkMiddleWare>();
    }

        public static IApplicationBuilder UseLogRequestMidleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
