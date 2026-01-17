namespace ITOApp.Application.Common;

public class BaseResponse<T>
{
    public string Status { get; set; } = "success"; // success|error
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public object? Metadata { get; set; }

    public static BaseResponse<T> Success(T data, string message = "Thành công", object? metadata = null)
        => new() { Status = "success", Message = message, Data = data, Metadata = metadata };

    public static BaseResponse<T> Error(string message, object? metadata = null)
        => new() { Status = "error", Message = message, Data = default, Metadata = metadata };
}