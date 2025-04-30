namespace HRManagement.Domain.Shared.Exceptions
{
    public class BusinessException : Exception
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public BusinessException() { }
        public BusinessException(string code)
        {
            Code = code;

        }

    }
}
