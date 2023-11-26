using DatabaseModelsBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Services.Data.Models
{
    [Table("user_types", Schema = "user")]
    internal class UserType : BaseDbM
    {
        public UserType()
        {

        }

        [Column("name"), Required]
        public string Name { get; set; }

        public ICollection<UserDb> Users { get; set; }
    }
}
