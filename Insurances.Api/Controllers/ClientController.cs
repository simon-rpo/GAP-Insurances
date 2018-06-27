using Insurances.Dto;
using Insurances.Rules;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Insurances.Api.Controllers
{
    public class ClientController : ApiController
    {

        #region Properties
        private readonly IClientRules ClientRules;
        #endregion

        #region Constructor
        public ClientController(IClientRules ClientRules)
        {
            this.ClientRules = ClientRules;
        }
        #endregion

        #region API
        [Route("api/Client/GetClients")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetClients()
        {
            try
            {
                List<ClientDto> lData = await ClientRules.GetAllClients();
                return Request.CreateResponse(HttpStatusCode.OK, new { ModelData = lData, Message = string.Empty });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new MessageDto
                {
                    Code = (int)MessageEnum.Error,
                    Message = ex.Message
                });
            }
        }

        [Route("api/Client/GetClientById")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetClientById(int ClientId)
        {
            try
            {
                ClientDto lData = await ClientRules.GetClientById(ClientId);
                return Request.CreateResponse(HttpStatusCode.OK, new { ModelData = lData, Message = string.Empty });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new MessageDto
                {
                    Code = (int)MessageEnum.Error,
                    Message = ex.Message
                });
            }
        }
        #endregion

    }
}