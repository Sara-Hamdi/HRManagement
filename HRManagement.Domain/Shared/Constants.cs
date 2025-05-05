namespace HRManagement.Domain.Shared
{
    public static class Constants
    {
        public static class ErrorCodes
        {
            public const string InternalServerError = "HR:001";
            public const string EmployeeAlreadyExists = "HR:002";
            public const string EntityNotFound = "HR:404";

        }
        public static class StringLengths
        {
            public const int SmallLength = 100;
        }
    }
}
