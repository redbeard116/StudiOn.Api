using DatabaseModelsBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Services.Data.Models;

[Table("markets", Schema = "market")]
internal class MarketDb: BaseDbM
{
    [Column("user_id"), Required]
    public Guid UserId { get; set; }

    [Column("name"), Required]
    public string Name { get; set; }

    [Column("created_date"), Required]
    public DateTime CreatedDate { get; set; }
}
