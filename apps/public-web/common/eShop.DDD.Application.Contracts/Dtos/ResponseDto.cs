namespace eShop.DDD.Application.Contracts;


public class ResponseDto<T>
{

    public ResponseDto(T? result)
    {
        Result = result;
    }
    public ResponseDto()
    {

    }
    public T? Result { get; set; }
    public ErrorResult? Error { get; set; }
    public bool IsSuccess { get; set; } = true;
}

public class ErrorResult
{
    public string Message { get; set; }
    public string Details { get; set; }
}

public class ApiResponseBuilder
{
    public static ResponseDto<T> CreateApiResponse<T>(T data)
    {
        return new ResponseDto<T>(data);
    }

    public static ResponseDto<T> CreateErrorApiResponse<T>(string message, string details = null)
    {
        return new ResponseDto<T>
        {
            Result = default(T),
            Error = new ErrorResult { Message = message, Details = details },
            IsSuccess = false
        };
    }
}