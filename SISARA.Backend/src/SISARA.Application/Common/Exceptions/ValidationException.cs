using SISARA.Application.Common.Base;

namespace SISARA.Application.Common.Exceptions
{
    public class ValidationException: Exception
    {
        public IEnumerable<BaseError>? Errors { get; set; }
        public ValidationException() : base() 
        {
            Errors = new List<BaseError>();
        }
        public ValidationException(IEnumerable<BaseError> errors) : this()
        {
            Errors = errors;
        }

    }
}
