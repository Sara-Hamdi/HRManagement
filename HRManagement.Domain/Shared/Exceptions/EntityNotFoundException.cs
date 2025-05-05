namespace HRManagement.Domain.Shared.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public const string Code = Constants.ErrorCodes.EntityNotFound;
        public Guid Id { get; set; }
        public string EntityName { get; set; }
        public EntityNotFoundException(Guid id, string entityName)
        {
            Id = id;
            EntityName = entityName;
        }
    }
}
