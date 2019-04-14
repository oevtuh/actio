using System;
using System.Collections.Generic;
using System.Text;

namespace Actio.Common.Events
{
    public class UserAuthenticatedRejected : IRejectedEvent
    {
        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }

        protected UserAuthenticatedRejected()
        {
        }

        public UserAuthenticatedRejected(string email, string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}
