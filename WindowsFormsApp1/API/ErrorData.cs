using Newtonsoft.Json;

namespace WindowsFormsApp1.API
{
    public class ErrorData
    {
        public string ErrorCode { get; }
        public int HttpStatus { get; }
        public string Message { get; }

        [JsonConstructor]
        internal ErrorData(string errorCode, int httpStatus, string message)
        {
            this.ErrorCode = errorCode;
            this.HttpStatus = httpStatus;
            this.Message = message;
        }
    }
}
