using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModelsBase
{
    public class BaseDbM
    {

        [Key, Column("id")]
        public Guid Id { get; set; }
    }
}
