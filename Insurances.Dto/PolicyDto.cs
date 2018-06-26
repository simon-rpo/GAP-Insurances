using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurances.Dto
{
    public class PolicyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoveringTypeId { get; set; }
        public decimal CoveringPercentage { get; set; }
        public DateTime PolicyStart { get; set; }
        public int Period { get; set; }
        public decimal Price { get; set; }
        public int ClientId { get; set; }
        public ClientDto Client { get; set; }
        public int Risk { get; set; }
        public int Status { get; set; }
    }
}
