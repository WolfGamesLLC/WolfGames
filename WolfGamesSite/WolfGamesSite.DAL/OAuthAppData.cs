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

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            OAuthAppData o = obj as OAuthAppData;
            if ((Object)o == null) return false;

            if (id != o.id) return false;
            if (secret != o.secret) return false;
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return id.GetHashCode() + secret.GetHashCode();
        }
    }
}
