using DatabaseModelsBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Services.Data.Models
{
    [Table("users", Schema = "user")]
    internal class UserDb : BaseDbM
    {
        [Column("user_name"), Required]
        public string UserName { get; set; }

        [Column("login"), Required]
        public string Login { get; set; }

        [Column("password"), Required]
        public string Password { get; set; }

        [Column("user_type_id"), Required]
        public Guid UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

        [Column("create_date"), Required]
        public DateTime CreateDate { get; set; }

        [Column("is_blocked"), Required]
        public bool IsBlocked { get; set; } = false;
    }
}
