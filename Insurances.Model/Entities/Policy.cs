using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insurances.Model
{

    [Table("Policies")]
    public class Policy
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Column(TypeName = "nvarchar", Order = 2)]
        [MaxLength(200)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar", Order = 3)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Column(Order = 4)]
        public int CoveringTypeId { get; set; }
        [ForeignKey("CoveringTypeId")]
        public virtual CoveringType CoveringType { get; set; }

        [Column(Order = 5)]
        public decimal CoveringPercentage { get; set; }

        [Column(Order = 6)]
        public DateTime PolicyStart { get; set; }

        [Column(Order = 7)]
        public int Period { get; set; }

        [Column(Order = 8)]
        public decimal Price { get; set; }

        [Column(Order = 9)]
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        [Column(Order = 10)]
        public RiskEnum Risk { get; set; }

        [Column(Order = 11)]
        public StatusEnum Status { get; set; }
    }
}
