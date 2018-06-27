using System.Collections.Generic;
using System.Threading.Tasks;
using Insurances.Dto;

namespace Insurances.Rules
{
    public interface IClientRules
    {
        Task<List<ClientDto>> GetAllClients();
        Task<ClientDto> GetClientById(int ClientId);
    }
}