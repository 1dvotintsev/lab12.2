using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    public class Point<TKey, TValue>
    {
        public bool isDeleted;
        TValue? data;
        TKey? key;

        public TKey? Key
        {
            get { return key; }
            set { key = value; }
        }

        public TValue? Value
        {
            get { return data; }
            set { data = value; }
        }

        public Point()
        {
            isDeleted = false;
            Value = default;
            Key = default;
        }

        public Point(TKey key, TValue value)
        {
            isDeleted = false;
            Value = value;
            Key = key;
        }

        public Point<TKey, TValue> Clone() 
        {
            Point<TKey, TValue> temp = new Point<TKey, TValue> (Key, Value);
            return temp;
        }

        public Point<TKey, TValue> Remove() 
        {
            Point<TKey, TValue> temp = new Point<TKey, TValue>();
            temp.isDeleted = true;
            return temp;
        }
    }
}
