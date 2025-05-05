using HRManagement.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HRManagement.Domain.Aggregates.Identity
{
    public class User : IdentityUser
    {
        [StringLength(Constants.StringLengths.SmallLength)]
        public string FirstName { get; set; }
        [StringLength(Constants.StringLengths.SmallLength)]
        public string LastName { get; set; }
        [StringLength(Constants.StringLengths.SmallLength)]
        public string FullName { get; set; }
        public bool IsActive { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreationDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastUpdateDate { get; set; }



    }
}
