using CleanArquitecture.API.Errors;

namespace CleanArquitectureAPI.Errors
{
    public class CodeErrorException : CodeErrorResponse
    {
        public string? Details { get; set; }
        public CodeErrorException(int statusCode, string? messsage = null, string? details = null) : base(statusCode, messsage)
        {
            Details = details;
        }
    }
}
