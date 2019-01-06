using Framework.Persistence.Ef;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Framework.Log.MongoDb.Interfaces;

namespace CarDamageAssessment.Web.Api.MiddleWares
{
  public class UnitOfWorkMiddleWare
  {

    private readonly RequestDelegate _requestDelegate;
    private IUnitOfWork _unitOfWork;

    public UnitOfWorkMiddleWare(RequestDelegate requestDelegate)
    {
      _requestDelegate = requestDelegate;
    }   

    public async Task Invoke(HttpContext httpContext, IUnitOfWork unitOfWork,IApiLogService apiLogService)
    {
      try
      {
         
        if(httpContext.Request.Method == "POST" || httpContext.Request.Method == "PUT")
        {

          _unitOfWork = unitOfWork;

          _unitOfWork.Begin();
                  
          await _requestDelegate(httpContext);

          _unitOfWork.Commit();

          //TODO:get sql generated code
         apiLogService.Log.SqlCode = "sql generated";

        }
        else
        {
          await _requestDelegate(httpContext);
        }
        
      }
      catch (Exception e)
      {
          apiLogService.Log.UnitOfWorkError = e.Message;

          _unitOfWork.RollBack();

      }

    }
  }
}
