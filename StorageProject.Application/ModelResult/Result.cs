

namespace StorageProject.Application.ModelResult
{
    public class Result<T>
    {
        public T? Value { get; private set; }
        public bool IsSuccess { get; private set; }
        public List<string> Errors { get; private set; }

        public Result(T value, bool isSuccess, List<string> errors)
        {
            Value = value;
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public static Result<T> Success(T value) => new Result<T>(value, true, new List<string>());
        public static Result<T> Failure(List<string> errors) => new Result<T>(default, false, errors);
        public static Result<T> Failure(string error) => new Result<T>(default, false, new List<string>() { error });

     
    }
}
