using System.Collections.Generic;
using System.Threading.Tasks;
using Insurances.Dto;

namespace Insurances.Dal
{
    public interface ICoveringTypeDal
    {
        Task<List<CoveringTypeDto>> GetAllCoveringTypes();
    }
}