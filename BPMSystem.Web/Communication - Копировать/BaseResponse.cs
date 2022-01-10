namespace BPMSystem.Web.Communication
{
    public abstract class BaseResponse
    {
        /// <summary>
        /// Флаг успешного выполнения
        /// </summary>
        public bool Success { get; protected set; }
        /// <summary>
        /// Ответ выполнения
        /// </summary>
        public string Message { get; protected set; }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
