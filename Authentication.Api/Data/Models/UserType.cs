using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Api.Data.Models
{
    [Table("user_types", Schema = "user")]
    internal class UserType : BaseDbM
    {
        public UserType()
        {
            Users = new List<UserDb>();
        }

        [Column("name"), Required]
        public string Name { get; set; }

        [Column("is_deleted"), Required]
        public bool IsDeleted { get; set; } = false;

        public ICollection<UserDb> Users { get; set; }
    }
}
