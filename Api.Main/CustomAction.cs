using Api.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Main
{
    public class CustomAction<T>
    {
        public CustomAction(HttpStatusCode statusCode, T result)
        {
            StatusCode = statusCode;
            Result = result;
        }

        public HttpStatusCode StatusCode { get; set;}
        public T Result { get; }
    }

    public static class ContE
    {
        public static async Task<ActionResult<TOld>>GetOldTypeResultAsync<T, TOld>(this ControllerBase controller, Task<T?> task) where T : class, IOldType<TOld> where TOld : class
        {
            var taskResult = await task;
            if(taskResult is null)
                return controller.NotFound();
            return GetOldTypeResult<T, TOld>(controller, taskResult);
        }


        public static ActionResult<TOld> GetOldTypeResult<T, TOld>(this ControllerBase controller, T? operationResult) where T : class, IOldType<TOld> where TOld : class
        {
            if(operationResult is null)
                return controller.NotFound();
            if (operationResult is IContains containsPrivate)
                containsPrivate.ClearPrivateData();
            return controller.Ok(operationResult.ToOldType());
        }

        public static async Task<ActionResult<T>> GetOldTypeResultAsync<T>(this ControllerBase controller, Task<T?> task) where T : class
        {
            var taskResult = await task;
            if (taskResult is null)
                return controller.NotFound();
            return GetOldTypeResult<T>(controller, taskResult);
        }


        public static ActionResult<T> GetOldTypeResult<T>(this ControllerBase controller, T? operationResult) where T : class
        {
            if (operationResult is null)
                return controller.NotFound();
            if (operationResult is IContains containsPrivate)
                containsPrivate.ClearPrivateData();
            return controller.Ok(operationResult);
        }
    }
}
