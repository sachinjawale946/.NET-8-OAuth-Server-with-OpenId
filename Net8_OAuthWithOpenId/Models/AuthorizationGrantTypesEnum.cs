using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net8_OAuthWithOpenId.Models
{
    internal enum AuthorizationGrantTypesEnum : byte
    {
        [Description("code")]
        Code,

        [Description("Implicit")]
        Implicit,

        [Description("ClientCredentials")]
        ClientCredentials,

        [Description("ResourceOwnerPassword")]
        ResourceOwnerPassword
    }

}
