using ResponceModel.Base;
using System.Net;

namespace ResponceModel
{
    /// <summary>
    /// Ответ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseData<T> : ResponseBase
    {

        public ResponseData(HttpStatusCode httpStatusCode, string errorMessage = null) : base(httpStatusCode, errorMessage)
        {

        }

        public ResponseData(T data,HttpStatusCode httpStatusCode = HttpStatusCode.OK, string errorMessage = null) : base(httpStatusCode, errorMessage)
        {
            Data = data;
        }

        public T Data { get;  init; }
    }

    public class VoidResponse : ResponseBase
    {
        public VoidResponse(HttpStatusCode httpStatusCode, string errorMessage = null) : base(httpStatusCode, errorMessage)
        {
        }
    }

    public class ErrorResponse : ResponseBase
    {
        public ErrorResponse(HttpStatusCode httpStatusCode, string errorMessage = null) : base(httpStatusCode, errorMessage)
        {
        }
        public string StackTrase { get; set; }
    }
}
