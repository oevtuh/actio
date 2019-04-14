using System;
using System.Collections.Generic;
using System.Text;

namespace Actio.Common.Events
{
    public class ActivityCreatedRejected : IRejectedEvent
    {
        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }

        protected ActivityCreatedRejected()
        {
        }

        public ActivityCreatedRejected(string email, string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}
