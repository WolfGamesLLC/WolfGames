using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfGamesSite.DAL
{
    public class OAuthAppData : IOAuthAppData
    {
        private string id;
        private string secret;

        public OAuthAppData(string id, string secret)
        {
            this.id = id;
            this.secret = secret;   
        }

        public string Id
        {
            get
            {
                return id;
            }
        }

        public string Secret
        {
            get
            {
                return secret;
            }
        }
    }
}
