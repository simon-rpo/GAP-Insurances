using System.Collections.Generic;
using System.Threading.Tasks;
using Insurances.Dto;

namespace Insurances.Dal
{
    public interface IPolicyDal
    {
        Task<bool> SavePolicy(PolicyDto dto);
        Task<bool> UpdatePolicy(PolicyDto dto);
        Task<bool> CancelPolicy(PolicyDto dto);
        Task<List<PolicyDto>> GetPoliciesByClientId(int ClientId);
    }
}