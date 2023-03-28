using DatabaseModelsBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Producst.Api.Data.Models
{
    [Table("producst", Schema = "product")]
    internal class ProductDb : BaseDbM
    {
        [Column("market_id"), Required]
        public Guid MarketId { get; set; }

        [Column("name"), Required]
        public string Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("price"), Required]
        public int Price { get; set; }

        [Column("details"), Required]
        public string Details { get; set; }

        [Column("category_id"), Required]
        public Guid CategoryId { get; set; }
    }
}
