using System.Threading.Tasks;
using Insurances.Dto;

namespace Insurances.Dal
{
    public interface IPolicyDal
    {
        Task<bool> SavePolicy(PolicyDto dto);
    }
}