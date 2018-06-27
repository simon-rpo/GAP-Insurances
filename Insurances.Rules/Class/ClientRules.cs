using Insurances.Dal;
using Insurances.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurances.Rules
{
    public class ClientRules : IClientRules
    {
        #region Vars & Props
        private readonly IClientDal ClientDal;
        #endregion

        #region Constructor
        public ClientRules(IClientDal ClientDal)
        {
            this.ClientDal = ClientDal;
        }
        #endregion

        #region Public Methods
        public async Task<List<ClientDto>> GetAllClients()
        {
            try
            {
                return await ClientDal.GetAllClients();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClientDto> GetClientById(int ClientId)
        {
            try
            {
                return await ClientDal.GetAllClientsById(ClientId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
