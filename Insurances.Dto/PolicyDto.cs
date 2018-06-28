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
        public string RiskName
        {
            get { return GetRiskName(Risk); }
            set { value = GetRiskName(Risk); }
        }
        public int Status { get; set; }

        private string GetRiskName(int Risk)
        {
            switch (Risk)
            {
                case 1:
                    return RiskEnum.Lower.ToString();
                case 2:
                    return RiskEnum.Medium.ToString();
                case 3:
                    return RiskEnum.MidHigher.ToString();
                case 4:
                    return RiskEnum.Higher.ToString();
                default:
                    return string.Empty;
            }
        }
    }
}
