using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfGamesSite.DAL
{
    public interface IOAuthAppData
    {
        string Id { get; }
        string Secret { get; }
    }
}
