﻿namespace HRManagement.Domain.Shared
{
    public static class Constants
    {
        public static class ErrorCodes
        {
            public const string InternalServerError = "HR:001";
            public const string EmployeeAlreadyExists = "HR:002";
            public const string EmailAlreadyExists = "HR:003";
            public const string PasswordChangingFailed = "HR:004";
            public const string InvalidEmailOrPassword = "HR:005";
            public const string EntityNotFound = "HR:404";

        }
        public static class StringLengths
        {
            public const int SmallLength = 100;
        }
        public static class Roles
        {
            public const string Admin = "Admin";
            public const string TeamLeader = "TeamLeader";
            public const string Employee = "Employee";
        }
    }
}
