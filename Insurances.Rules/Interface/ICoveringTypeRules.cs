using System.Collections.Generic;
using System.Threading.Tasks;
using Insurances.Dto;

namespace Insurances.Rules
{
    public interface ICoveringTypeRules
    {
        Task<List<CoveringTypeDto>> GetAllCoveringTypes();
    }
}