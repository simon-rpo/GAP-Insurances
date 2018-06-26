using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insurances.Model
{
    [Table("ConvertingTypes")]
    public class CoveringType
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Column(TypeName = "nvarchar", Order = 2)]
        [MaxLength(150)]
        public string Name { get; set; }

        public virtual ICollection<Policy> Policy { get; set; }
    }
}
