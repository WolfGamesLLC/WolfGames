using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WGSystem.Collections.Generic
{
    public class WGGenericCollectionsFactory
    {
        public IList<T> CreateList<T>()
        {
            return new List<T>();
        }
    }
}
