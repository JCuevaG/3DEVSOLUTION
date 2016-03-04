using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _3DEV.MODELS
{
    [ScaffoldTable(false)]
    public class OAuthMembershipMetadata { }

    [MetadataType(typeof(OAuthMembershipMetadata))]
    public class OAuthMembership
    {
        public string Provider { get; set; }
        public string ProviderUserId { get; set; }
        public int UserId { get; set; }
    }
}
