using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Authentication.Api.Data.Models
{
    internal class BaseDbM
    {
        [Key, Column("id")]
        public int Id { get; set; }
    }
}
