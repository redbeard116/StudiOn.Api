using DatabaseModelsBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Services.Data.Models;

[Table("user_types", Schema = "user")]
internal class UserTypeDB : BaseDbM
{
    public UserTypeDB()
    {

    }

    [Column("name"), Required]
    public string Name { get; set; }

    public ICollection<UserDb> Users { get; set; }
}
