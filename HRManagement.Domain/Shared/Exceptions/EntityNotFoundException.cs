namespace HRManagement.Domain.Shared.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public const string Code = "";
        public Guid Id { get; set; }
        public EntityNotFoundException(string entityName, Guid id) : base($"Cannot find an entity {entityName} with Id = {id}")
        {

        }
    }
}
