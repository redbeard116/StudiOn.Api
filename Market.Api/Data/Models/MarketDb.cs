using DatabaseModelsBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Api.Data.Models
{
    [Table("markets", Schema = "market")]
    internal class MarketDb: BaseDbM
    {
        [Column("user_id"), Required]
        public int UserId { get; set; }

        [Column("name"), Required]
        public string Name { get; set; }

        [Column("is_deleted"), Required]
        public bool IsDeleted { get; set; } = false;

        [Column("created_date"), Required]
        public DateTime CreatedDate { get; set; }
    }
}
