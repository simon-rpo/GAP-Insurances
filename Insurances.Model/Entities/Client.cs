using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insurances.Model
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar", Order = 2)]
        [MaxLength(150)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar", Order = 3)]
        [MaxLength(150)]
        public string Identification { get; set; }

        [InverseProperty("Client")]
        public virtual ICollection<Policy> Policy { get; set; }
    }
}
