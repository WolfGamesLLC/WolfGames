using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WGCodeLanguageAPI.System.Collections.Generic
{
    public class WGGenericCollectionsFactory
    {
        public IList CreateList<T>()
        {
            return new List<T>();
        }
    }
}
