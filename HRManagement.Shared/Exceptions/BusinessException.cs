namespace HRManagement.Shared.Exceptions
{
    public class BusinessException : Exception
    {
        public string Code { get; set; }
        public BusinessException(string code)
        {
            Code = code;

        }

    }
}
