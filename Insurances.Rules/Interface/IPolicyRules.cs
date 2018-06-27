using System.Collections.Generic;
using System.Threading.Tasks;
using Insurances.Dto;

namespace Insurances.Rules
{
    public interface IPolicyRules
    {
        Task<MessageDto> SavePolicy(PolicyDto Policy);
        Task<MessageDto> UpdatePolicy(PolicyDto Policy);
        Task<MessageDto> CancelPolicy(PolicyDto Policy);
        Task<List<PolicyDto>> GetPoliciesByClientId(int ClientId);
    }
}