using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ResponceModel.Base
{
    /// <summary>
    /// Базовый класс для отображения ответа http-запроса
    /// </summary>
    public abstract class ResponseBase
    {
        public ResponseBase(HttpStatusCode httpStatusCode, string errorMessage = null)
        {
            StatusCode = httpStatusCode;
            ErrorMessage = errorMessage;
        }
        /// <summary>
        /// HTTP Код ответа
        /// </summary>
        [Required]
        public HttpStatusCode StatusCode { get; init; }

        /// <summary>
        /// Описание ошибки, если она произошла
        /// </summary>
        public string ErrorMessage { get; init; }
    }
}
