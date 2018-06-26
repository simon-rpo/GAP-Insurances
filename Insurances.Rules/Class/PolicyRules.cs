using Insurances.Dal;
using Insurances.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurances.Rules.Class
{
    public class PolicyRules : IPolicyRules
    {
        #region Vars & Props
        private readonly IPolicyDal PolicyDal;
        #endregion

        #region Constructor
        public PolicyRules(IPolicyDal PolicyDal)
        {
            this.PolicyDal = PolicyDal;
        }
        #endregion

        #region Public Methods
        public async Task<MessageDto> SavePolicy(PolicyDto Policy)
        {
            await PolicyDal.SavePolicy(Policy);
            return new MessageDto { Code = 1, Message = "Policy saved successfully!" };
        }
        #endregion
    }
}
