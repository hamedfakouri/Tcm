using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Framework.Log.MongoDb;
using Framework.Log.MongoDb.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace Tcm.Interface.Api.MiddleWares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
      
      

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context,IApiLogService apiLogService)
        {


            apiLogService.Log.LogStartTime = DateTime.Now.Millisecond.ToString();

           
          
            var request = await FormatRequest(context.Request);
            apiLogService.Log.Request = request;



            var originalBodyStream = context.Response.Body;

       
            using (var responseBody = new MemoryStream())
            {

                context.Response.Body = responseBody;

                await _next(context);

                var response = await FormatResponse(context.Response);
                apiLogService.Log.Response = response;


                await responseBody.CopyToAsync(originalBodyStream);
            }

            apiLogService.Log.LogEndTime = DateTime.Now.Millisecond.ToString();

            apiLogService.Create(apiLogService.Log);



        }

        private async Task<string> FormatRequest(HttpRequest request)
        {

          


            var httpRequest = request;

            var body = request.Body;

           
            request.EnableRewind();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

         
            await request.Body.ReadAsync(buffer, 0, buffer.Length);

          
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body.Position = 0;

            request.Body = httpRequest.Body;         
          

            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
           
            response.Body.Seek(0, SeekOrigin.Begin);

           
            string text = await new StreamReader(response.Body).ReadToEndAsync();

           
            response.Body.Seek(0, SeekOrigin.Begin);

            return $"{response.StatusCode}: {text}";
        }
    }


  

}
