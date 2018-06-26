using Insurances.Dto;
using Insurances.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Insurances.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PolicyController : ApiController
    {

        #region Properties
        private readonly IPolicyRules PolicyRules;
        #endregion

        #region Constructor
        public PolicyController(IPolicyRules PolicyRules)
        {
            this.PolicyRules = PolicyRules;
        }
        #endregion

        #region API
        [Route("api/Policy/SavePolicy")]
        [HttpPost]
        public async Task<HttpResponseMessage> SavePolicy(PolicyDto Policy)
        {
            try
            {
                MessageDto lData = await PolicyRules.SavePolicy(Policy);
                return Request.CreateResponse(HttpStatusCode.OK, new { ModelData = lData, Message = string.Empty });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

    }
}