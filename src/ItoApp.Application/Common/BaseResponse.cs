namespace ItoApp.Application.Common
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public object? Metadata { get; set; }
        public List<string>? Errors { get; set; }

        public static BaseResponse<T> Success(T data, string message = "", object? metadata = null)
        {
            return new BaseResponse<T>
            {
                IsSuccess = true,
                Message = message,
                Data = data,
                Metadata = metadata
            };
        }

        public static BaseResponse<T> Error(string message, List<string>? errors = null)
        {
            return new BaseResponse<T>
            {
                IsSuccess = false,
                Message = message,
                Errors = errors
            };
        }
    }
}