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
    public class CoveringTypeController : ApiController
    {
        #region Properties
        private readonly ICoveringTypeRules CoveringTypeRules;
        #endregion

        #region Constructor
        public CoveringTypeController(ICoveringTypeRules CoveringTypeRules)
        {
            this.CoveringTypeRules = CoveringTypeRules;
        }
        #endregion

        #region API
        [Route("api/CoveringType/GetCoveringTypes")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetCoveringTypes()
        {
            try
            {
                List<CoveringTypeDto> lData = await CoveringTypeRules.GetAllCoveringTypes();
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