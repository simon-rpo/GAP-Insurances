using System.Threading.Tasks;
using Insurances.Dto;

namespace Insurances.Rules
{
    public interface IPolicyRules
    {
        Task<MessageDto> SavePolicy(PolicyDto Policy);
    }
}