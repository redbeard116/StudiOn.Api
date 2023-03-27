using Microsoft.AspNetCore.Mvc;
using ResponceModel.Base;

namespace Market.Api.Extensions
{
    internal static class ControllerBaseExtensions
    {
        public static IActionResult Result(this ControllerBase controllerBase, ResponseBase response)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return controllerBase.Ok(response);
                case System.Net.HttpStatusCode.BadRequest:
                    return controllerBase.BadRequest(response);
                case System.Net.HttpStatusCode.Forbidden:
                    return controllerBase.Forbid();
                case System.Net.HttpStatusCode.NotFound:
                    return controllerBase.NotFound(response);
            }

            return controllerBase.StatusCode((int)response.StatusCode);
        }
    }
}
