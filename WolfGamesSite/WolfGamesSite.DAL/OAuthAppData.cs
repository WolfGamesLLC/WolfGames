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
                
        }

        public string Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Secret
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
