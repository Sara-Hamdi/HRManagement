using HRManagement.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HRManagement.Domain.Aggregates.UserAggregate
{
    public class User : IdentityUser
    {
        [StringLength(Constants.StringLengths.SmallLength)]
        public string FirstName { get; private set; }
        [StringLength(Constants.StringLengths.SmallLength)]
        public string LastName { get; private set; }
        [StringLength(Constants.StringLengths.SmallLength)]
        public string? FullName { get; private set; }
        public bool IsActive { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreationDate { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastUpdateDate { get; private set; }
        public User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            IsActive = true;
            Email = email;
            UserName = email;
            CreationDate = DateTime.UtcNow;
            SetFullName();

        }
        public void SetFullName()
        {
            FullName = FirstName + " " + LastName;
        }
        public void Update(string? firstName = null, string? lastName = null, string? email = null, string? phoneNumber = null)
        {
            FirstName = firstName ?? FirstName;
            LastName = lastName ?? LastName;
            Email = email ?? Email;
            UserName = email ?? Email;
            PhoneNumber = phoneNumber ?? PhoneNumber;
            LastUpdateDate = DateTime.UtcNow;
            SetFullName();
        }

    }
}
